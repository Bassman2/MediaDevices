namespace MediaDevices;

public enum NikonLiveViewDriveMode : ushort
{
    /// <summary>
    /// Optimizes the stream for the full sensor aspect ratio (usually 3:2). 
    /// Frames focus on giving the cleanest preview for capture framing.
    /// </summary>
    StillMode = 0,

    /// <summary>
    /// Letterboxes or crops the sensor readout to match the active video aspect ratio (typically 16:9). 
    /// Configures internal pipelines to allow immediate video recording.
    /// </summary>
    MovieMode = 1
}
