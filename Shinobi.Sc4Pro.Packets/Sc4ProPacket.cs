namespace Shinobi.Sc4Pro.Packets;

/// <summary>Base record for all packets received from the SC4Pro device.</summary>
/// <param name="Cmd">Command byte identifying the packet type.</param>
/// <param name="Raw">Hex-encoded raw bytes of the original BLE notification (colon-separated).</param>
public abstract record Sc4ProPacket(byte Cmd, string Raw);
