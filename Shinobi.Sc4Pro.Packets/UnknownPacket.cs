namespace Shinobi.Sc4Pro.Packets;

/// <summary>Fallback packet for unrecognized command bytes.</summary>
/// <param name="Cmd">The unrecognized command byte.</param>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record UnknownPacket(byte Cmd, string Raw) : Sc4ProPacket(Cmd, Raw);
