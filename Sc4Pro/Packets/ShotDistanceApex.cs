namespace Sc4Pro.Packets;

/// <summary>Shot sub-packet seq=4. Total distance, apex height, and total spin.</summary>
/// <param name="TotalDistance">Total distance (carry + roll) in the configured unit (yards or metres).</param>
/// <param name="Apex">Maximum ball height (apex) in the configured unit.</param>
/// <param name="TotalSpin">Total ball spin in RPM.</param>
public record ShotDistanceApex(float TotalDistance, float Apex, float TotalSpin)
    : ShotData;
