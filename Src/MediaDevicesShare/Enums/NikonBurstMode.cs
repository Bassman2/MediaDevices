namespace MediaDevices;

public enum NikonBurstMode : ushort
{
    /// <summary>
    /// One photograph per shutter click.
    /// </summary>
    SingleFrame = 0,

    /// <summary>
    /// Slow burst rate. Frame rate is bounded by custom settings inside the camera menu.
    /// </summary>
    ContinuousLow = 1,

    /// <summary>
    /// Maximum native frame rate supported by the mechanical/electronic shutter.
    /// </summary>
    ContinuousHigh = 2,

    /// <summary>
    /// Delay before capture sequence initiates.
    /// </summary>
    SelfTimer = 3,

    /// <summary>
    /// Quiet Shutter (Q)Dampens mirror movement sound (DSLRs only).
    /// </summary>
    QuietShutter = 4
}
