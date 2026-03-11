using System.Text.Json;
using System.Text.Json.Serialization;
using Shinobi.Sc4Pro.Packets;

namespace Shinobi.Sc4Pro.Tests;

public class WsCommandsTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() },
    };

    private static WsCommand? Deserialize(string json)
        => JsonSerializer.Deserialize<WsCommand>(json, Options);

    [Fact]
    public void SetClub_Deserializes()
    {
        var cmd = Deserialize("""{"type":"setClub","club":"W5"}""");
        Assert.IsType<SetClubCommand>(cmd);
        Assert.Equal(ClubType.W5, ((SetClubCommand)cmd!).Club);
    }

    [Theory]
    [InlineData("W1")]  [InlineData("W3")]  [InlineData("I9")]
    [InlineData("PW")]  [InlineData("SW")]  [InlineData("PT")]
    public void SetClub_AllClubValues(string club)
    {
        var cmd = Deserialize($$"""{"type":"setClub","club":"{{club}}"}""");
        Assert.IsType<SetClubCommand>(cmd);
        Assert.Equal(Enum.Parse<ClubType>(club), ((SetClubCommand)cmd!).Club);
    }

    [Fact]
    public void SetMode_SwingSpeed_Deserializes()
    {
        var cmd = Deserialize("""{"type":"setMode","mode":"SwingSpeed"}""");
        Assert.IsType<SetModeCommand>(cmd);
        Assert.Equal(DeviceMode.SwingSpeed, ((SetModeCommand)cmd!).Mode);
    }

    [Fact]
    public void SetMode_Practice_Deserializes()
    {
        var cmd = Deserialize("""{"type":"setMode","mode":"Practice"}""");
        Assert.IsType<SetModeCommand>(cmd);
        Assert.Equal(DeviceMode.Practice, ((SetModeCommand)cmd!).Mode);
    }

    [Fact]
    public void SetMode_Sim_Deserializes()
    {
        var cmd = Deserialize("""{"type":"setMode","mode":"Sim"}""");
        Assert.IsType<SetModeCommand>(cmd);
        Assert.Equal(DeviceMode.Sim, ((SetModeCommand)cmd!).Mode);
    }

    [Fact]
    public void ShotReady_Deserializes()
    {
        var cmd = Deserialize("""{"type":"shotReady"}""");
        Assert.IsType<ShotReadyCommand>(cmd);
    }

    [Fact]
    public void SetMode_MissingModeField_Throws()
    {
        Assert.Throws<JsonException>(() =>
            Deserialize("""{"type":"setMode","swingSpeed":true}"""));
    }

    [Fact]
    public void SetClub_MissingClubField_Throws()
    {
        Assert.Throws<JsonException>(() =>
            Deserialize("""{"type":"setClub"}"""));
    }

    [Fact]
    public void UnknownType_Throws()
    {
        Assert.Throws<JsonException>(() =>
            Deserialize("""{"type":"unknownCommand"}"""));
    }
}
