namespace Sc4Pro.Packets;

/// <summary>
/// Bitmask indicating which fields are being set in a DeviceSetting1 command.
/// Only flagged fields are acted on by the device.
/// </summary>
[Flags]
public enum DS1Flags : byte
{
    /// <summary>Play mode (normal / swing-speed).</summary>
    Mode = 1 << 0,
    /// <summary>Distance unit (metric / imperial).</summary>
    Unit = 1 << 1,
    /// <summary>Tee height setting.</summary>
    TeeHeight = 1 << 2,
    /// <summary>Distance-to-ball setting.</summary>
    DistanceToBall = 1 << 3,
    /// <summary>Target distance setting.</summary>
    TargetDistance = 1 << 4,
    /// <summary>Selected club type.</summary>
    Club = 1 << 5,
    /// <summary>Loft angle override.</summary>
    LoftAngle = 1 << 6,
    /// <summary>Carry/total distance display toggle.</summary>
    CarryTotal = 1 << 7
}
