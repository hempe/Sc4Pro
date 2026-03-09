namespace Sc4Pro.Packets;

/// <summary>Fallback shot payload for unrecognized sequence numbers.</summary>
/// <param name="Seq">The unrecognized sequence number.</param>
/// <param name="PayloadLength">Length of the raw payload in bytes.</param>
public record UnknownShotData(uint Seq, int PayloadLength) : ShotData;
