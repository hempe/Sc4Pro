namespace Shinobi.Sc4Pro.Packets;

/// <summary>
/// Bitmask indicating which fields are being set in a DeviceSetting2 command.
/// Only flagged fields are acted on by the device.
/// </summary>
[Flags]
public enum DS2Flags : byte
{
    /// <summary>Display language.</summary>
    Language = 1 << 0,
    /// <summary>Sensor sensitivity / volume level.</summary>
    Volume = 1 << 1,
    /// <summary>Vertical display offset.</summary>
    VerticalOffset = 1 << 2,
    /// <summary>Horizontal display offset.</summary>
    HorizontalOffset = 1 << 3,
    /// <summary>Active app/display index (1 = idle/home, 2 = game active).</summary>
    AppIndex = 1 << 4,
    /// <summary>Toggles whether the app index change takes effect.</summary>
    AppIndexOnOff = 1 << 5
}
