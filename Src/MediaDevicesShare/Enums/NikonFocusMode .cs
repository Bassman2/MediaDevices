namespace MediaDevices;

public enum NikonFocusMode : ushort
{
    /// <summary>
    /// Electronic autofocus loops are entirely disabled. 
    /// The camera relies solely on physical ring manipulation on the lens barrel.
    /// </summary>
    Manual = 0,

    /// <summary>
    /// Static target lock. 
    /// The camera locks focus coordinates once when a trigger is initiated and freezes until the capture sequence completes.
    /// </summary>
    SingleServo = 1,

    /// <summary>
    /// Full dynamic tracking.
    /// The lens continually hunts and shifts to keep the target within the focus area sharp as long as the session runs.
    /// </summary>
    ContinuousServo = 2,

    /// <summary>
    /// The camera evaluates scene dynamics and automatically switches between AF-S and AF-C. 
    /// (Mostly available on entry/mid-tier consumer bodies).
    /// </summary>
    AutoServo = 3,

    /// <summary>
    /// Specifically calibrated for live view video workflows. 
    /// The lens tracks continuously without requiring a half-press shutter actuation trigger.
    /// </summary>
    FullTimeServo = 4    
}
