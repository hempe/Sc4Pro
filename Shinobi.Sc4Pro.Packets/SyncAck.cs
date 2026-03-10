namespace Shinobi.Sc4Pro.Packets;

/// <summary>Acknowledgement for the Sync command (cmd 0x74). Contains the device serial number.</summary>
/// <param name="Serial">ASCII serial number of the device (e.g. "SC40B250038-03").</param>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record SyncAck(string Serial, string Raw) : Sc4ProPacket(0x74, Raw);
