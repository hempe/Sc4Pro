namespace Sc4Pro.Packets;

/// <summary>Shot sub-packet seq=5. Lateral launch direction, tilt, and internal calibration angles.</summary>
/// <param name="LaunchDirection">Horizontal launch direction in degrees (negative = left, positive = right).</param>
/// <param name="Tilt">Ball tilt angle in degrees.</param>
/// <param name="CalAngleC">Internal calibration angle C (purpose not yet confirmed).</param>
/// <param name="CalAngleD">Internal calibration angle D (purpose not yet confirmed).</param>
/// <param name="Equalizer">Equalizer value (purpose not yet confirmed).</param>
public record ShotDirection(
    float LaunchDirection, float Tilt,
    int CalAngleC, int CalAngleD, uint Equalizer) : ShotData;
