namespace Shinobi.Sc4Pro.Packets;

/// <summary>Shot sub-packet seq=5. Lateral launch direction and tilt.</summary>
/// <param name="LaunchDirection">Horizontal launch direction in degrees (negative = left, positive = right).</param>
/// <param name="Tilt">Ball tilt angle in degrees.</param>
public record ShotDirection(float LaunchDirection, float Tilt) : ShotData;
