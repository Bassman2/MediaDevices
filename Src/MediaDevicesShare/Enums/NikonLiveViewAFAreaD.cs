namespace MediaDevices;

/// <summary>
/// Legacy DSLR Generation (e.g., Nikon D850, D7500, D4S)
/// </summary>
public enum NikonLiveViewAFAreaD : ushort
{
    /// <summary>
    /// Prioritizes human bone structures/eyes in portrait framings.
    /// </summary>
    FacePriority = 0,

    /// <summary>
    /// Larger tracking box for hand-held landscape snapshots.
    /// </summary>
    WideArea = 1,

    /// <summary>
    /// Precision single-box point for standard tripod composition workflows.
    /// </summary>
    NormalArea = 2,

    /// <summary>
    /// Lock-and-follow metric utilizing manual registration.
    /// </summary>
    SubjectTracking = 3
}