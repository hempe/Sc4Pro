namespace Shinobi.Sc4Pro.Packets;

/// <summary>Fallback shot payload for unrecognized or too-short sequence numbers.</summary>
/// <param name="Seq">The unrecognized sequence number.</param>
/// <param name="Payload">Raw payload bytes.</param>
public record UnknownShotData(uint Seq, byte[] Payload) : ShotData;
