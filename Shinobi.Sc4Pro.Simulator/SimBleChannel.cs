using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

using Shinobi.Sc4Pro.Bluetooth;

namespace Shinobi.Sc4Pro.Bluetooth;

/// <summary>
/// IBleChannel implementation that connects to the SC4Pro Simulator WebSocket server
/// instead of real BLE hardware. Drop-in replacement for the Linux BleChannel.
/// </summary>
public sealed class SimBleChannel : IBleChannel
{
    // Fake GATT config returned by ReadConfigAsync — mirrors what Sc4ProDevice reads.
    private static readonly IReadOnlyDictionary<string, byte[]> _fakeConfig =
        new Dictionary<string, byte[]>
        {
            ["00002a29-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("VCinc"),
            ["00002a24-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("SC4Pro"),
            ["00002a25-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("SC4ProSim-01"),
            ["00002a26-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("1.0.0"),
            ["00002a27-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("1.0"),
            ["00002a19-0000-1000-8000-00805f9b34fb"] = [100], // battery 100 %
            ["00002b02-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("10"),
            ["00002b03-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("110"),
            ["00002b04-0000-1000-8000-00805f9b34fb"] = Encoding.ASCII.GetBytes("008,008,008,008,008"),
        };

    private readonly string _url;
    private ClientWebSocket? _ws;
    private CancellationTokenSource? _cts;

    public event Func<byte[], Task>? Received;

    public SimBleChannel(string url = "ws://localhost:8081/ble")
        => _url = url;

    public async Task<string> ConnectAsync(string serviceUuid, string txUuid, string rxUuid)
    {
        _ws = new ClientWebSocket();
        _cts = new CancellationTokenSource();
        await _ws.ConnectAsync(new Uri(_url), _cts.Token);
        _ = ReceiveLoopAsync(_cts.Token);
        return "SC4Pro Simulator";
    }

    public async Task SendAsync(byte[] packet)
    {
        var json = JsonSerializer.Serialize(new { type = "tx", data = Convert.ToBase64String(packet) });
        await _ws!.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, CancellationToken.None);
    }

    public Task<IReadOnlyDictionary<string, byte[]>> ReadConfigAsync()
        => Task.FromResult(_fakeConfig);

    private async Task ReceiveLoopAsync(CancellationToken ct)
    {
        var buffer = new byte[4096];
        try
        {
            while (_ws?.State == WebSocketState.Open && !ct.IsCancellationRequested)
            {
                var result = await _ws.ReceiveAsync(buffer, ct);
                if (result.MessageType == WebSocketMessageType.Close) break;

                using var doc = JsonDocument.Parse(Encoding.UTF8.GetString(buffer, 0, result.Count));
                if (doc.RootElement.GetProperty("type").GetString() == "rx")
                {
                    var data = Convert.FromBase64String(doc.RootElement.GetProperty("data").GetString()!);
                    if (Received != null) await Received(data);
                }
            }
        }
        catch (OperationCanceledException) { }
        catch (WebSocketException) { }
    }

    public async ValueTask DisposeAsync()
    {
        _cts?.Cancel();
        if (_ws?.State == WebSocketState.Open)
            await _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, null, CancellationToken.None);
        _ws?.Dispose();
        _cts?.Dispose();
    }
}
