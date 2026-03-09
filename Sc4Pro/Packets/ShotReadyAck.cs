namespace Sc4Pro.Packets;

/// <summary>Acknowledgement for a ShotReady command (cmd 0x77). Indicates the device is armed for the next shot.</summary>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record ShotReadyAck(string Raw) : Sc4ProPacket(0x77, Raw);
