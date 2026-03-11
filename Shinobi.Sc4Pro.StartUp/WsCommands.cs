using System.Text.Json;
using System.Text.Json.Serialization;

using Shinobi.Sc4Pro.Packets;

[JsonConverter(typeof(WsCommandConverter))]
public abstract record WsCommand;

public record SetClubCommand([property: JsonRequired] ClubType Club) : WsCommand;
public record SetModeCommand([property: JsonRequired] DeviceMode Mode) : WsCommand;
public record ShotReadyCommand() : WsCommand;

public sealed class WsCommandConverter : JsonConverter<WsCommand>
{
    public override WsCommand? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        return root.GetProperty("type").GetString() switch
        {
            "setClub"   => root.Deserialize<SetClubCommand>(options),
            "setMode"   => root.Deserialize<SetModeCommand>(options),
            "shotReady" => new ShotReadyCommand(),
            var t       => throw new JsonException($"Unknown command type: {t}"),
        };
    }

    public override void Write(Utf8JsonWriter writer, WsCommand value, JsonSerializerOptions options)
        => throw new NotSupportedException("WsCommand is receive-only.");
}
