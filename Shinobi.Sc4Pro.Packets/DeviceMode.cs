namespace Shinobi.Sc4Pro.Packets;

/// <summary>Operating mode of the SC4Pro device.</summary>
public enum DeviceMode
{
    /// <summary>Normal / practice mode. DS2(appIndex=1) + DS1(mode=0).</summary>
    Practice,

    /// <summary>Swing speed measurement mode. DS2(appIndex=1) + DS1(mode=2) + ShotReady.</summary>
    SwingSpeed,

    /// <summary>
    /// SIM home screen. DS1(mode=0) + DS2(appIndex=2).
    /// Observed as the "back from swing speed" transition; also the state the app
    /// restores on connect when the device was last in simulator mode.
    /// </summary>
    Sim,
}
