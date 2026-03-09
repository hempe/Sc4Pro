namespace Sc4Pro.Packets;

/// <summary>Club type identifier used in device commands and shot metadata.</summary>
public enum ClubType : byte
{
    /// <summary>Driver (1-Wood).</summary>
    W1 = 0,
    /// <summary>3-Wood.</summary>
    W3 = 1,
    /// <summary>4-Wood.</summary>
    W4 = 2,
    /// <summary>5-Wood.</summary>
    W5 = 3,
    /// <summary>6-Wood.</summary>
    W6 = 4,
    /// <summary>7-Wood.</summary>
    W7 = 5,
    /// <summary>3-Hybrid.</summary>
    U3 = 6,
    /// <summary>4-Hybrid.</summary>
    U4 = 7,
    /// <summary>5-Hybrid.</summary>
    U5 = 8,
    /// <summary>6-Hybrid.</summary>
    U6 = 9,
    /// <summary>7-Hybrid.</summary>
    U7 = 10,
    /// <summary>3-Iron.</summary>
    I3 = 11,
    /// <summary>4-Iron.</summary>
    I4 = 12,
    /// <summary>5-Iron.</summary>
    I5 = 13,
    /// <summary>6-Iron.</summary>
    I6 = 14,
    /// <summary>7-Iron.</summary>
    I7 = 15,
    /// <summary>8-Iron.</summary>
    I8 = 16,
    /// <summary>9-Iron.</summary>
    I9 = 17,
    /// <summary>Pitching Wedge.</summary>
    PW = 18,
    /// <summary>Gap Wedge.</summary>
    GW = 19,
    /// <summary>Sand Wedge.</summary>
    SW = 20,
    /// <summary>Lob Wedge.</summary>
    LW = 21,
    /// <summary>Putter.</summary>
    PT = 22,
}
