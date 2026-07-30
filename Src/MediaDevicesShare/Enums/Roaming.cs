namespace MediaDevices;

/// <summary>
/// Roaming values
/// </summary>
public enum Roaming : byte
{
    /// <summary>
    /// The mobile mediaDevice is on its home network.
    /// </summary>
    HomeNetwork = 0,

    /// <summary>
    /// The mediaDevice is roaming.
    /// </summary>
    Roaming = 1,

    /// <summary>
    /// The roaming status is unknown.
    /// </summary>
    Unknown = 2
}
