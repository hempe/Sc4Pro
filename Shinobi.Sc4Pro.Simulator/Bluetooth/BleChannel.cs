namespace Shinobi.Sc4Pro.Bluetooth;

// This should host the simulator and let the startup connect.
public sealed class BleChannel : IBleChannel
{
    public event Func<byte[], Task>? Received;

    public Task<string> ConnectAsync(string serviceUuid, string txUuid, string rxUuid)
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public Task<IReadOnlyDictionary<string, byte[]>> ReadConfigAsync()
    {
        throw new NotImplementedException();
    }

    public Task SendAsync(byte[] packet)
    {
        throw new NotImplementedException();
    }
}
