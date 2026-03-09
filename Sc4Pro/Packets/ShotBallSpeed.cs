namespace Sc4Pro.Packets;

/// <summary>Shot sub-packet seq=2. Atmospheric conditions and measured ball speed.</summary>
/// <param name="Pressure_hPa">Barometric pressure in hPa at the time of the shot.</param>
/// <param name="Temperature_C">Ambient temperature in °C at the time of the shot.</param>
/// <param name="BallSpeed">Ball speed in the configured unit (mph or m/s).</param>
public record ShotBallSpeed(float Pressure_hPa, float Temperature_C, float BallSpeed)
    : ShotData;
