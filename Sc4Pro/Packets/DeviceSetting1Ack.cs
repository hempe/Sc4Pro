namespace Sc4Pro.Packets;

/// <summary>Acknowledgement for a DeviceSetting1 command (cmd 0x6F).</summary>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record DeviceSetting1Ack(string Raw) : Sc4ProPacket(0x6F, Raw);
