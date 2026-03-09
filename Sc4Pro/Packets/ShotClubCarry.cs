namespace Sc4Pro.Packets;

/// <summary>Shot sub-packet seq=3. Club head speed, launch angle, and carry distance.</summary>
/// <param name="ClubSpeed">Club head speed in the configured unit (mph or m/s).</param>
/// <param name="LaunchAngle">Vertical launch angle in degrees.</param>
/// <param name="Carry">Carry distance in the configured unit (yards or metres).</param>
public record ShotClubCarry(float ClubSpeed, float LaunchAngle, float Carry)
    : ShotData;
