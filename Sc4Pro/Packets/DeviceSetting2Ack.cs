namespace Sc4Pro.Packets;

/// <summary>Acknowledgement for a DeviceSetting2 command (cmd 0x6E).</summary>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record DeviceSetting2Ack(string Raw) : Sc4ProPacket(0x6E, Raw);
