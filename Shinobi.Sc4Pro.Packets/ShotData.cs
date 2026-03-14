namespace Shinobi.Sc4Pro.Packets;

/// <summary>Base record for the typed payload carried inside a <see cref="ShotPacket"/>.</summary>
public abstract record ShotData
{
    /// <summary>Any payload bytes beyond the known fields, preserved for future analysis.</summary>
    public byte[] Tail { get; init; } = [];
}
