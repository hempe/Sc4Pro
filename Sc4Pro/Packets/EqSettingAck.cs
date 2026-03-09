namespace Sc4Pro.Packets;

/// <summary>Acknowledgement for an EqSetting command (cmd 0x76).</summary>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record EqSettingAck(string Raw) : Sc4ProPacket(0x76, Raw);
