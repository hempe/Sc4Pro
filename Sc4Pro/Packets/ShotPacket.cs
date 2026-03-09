namespace Sc4Pro.Packets;

/// <summary>
/// Shot notification packet (cmd 0x73). Each physical shot produces six sequential
/// sub-packets sharing the same <see cref="Index"/> but with different <see cref="Seq"/>
/// values (1–6), each carrying a different <see cref="ShotData"/> subtype.
/// </summary>
/// <param name="Index">Shot counter, incremented by the device for each new shot.</param>
/// <param name="Seq">Sub-packet sequence number (1–6).</param>
/// <param name="Data">Parsed payload; runtime type depends on <see cref="Seq"/>.</param>
/// <param name="Raw">Hex-encoded raw bytes.</param>
public record ShotPacket(uint Index, uint Seq, ShotData Data, string Raw)
    : Sc4ProPacket(0x73, Raw);
