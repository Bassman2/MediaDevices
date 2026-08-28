namespace MediaDevices;

public enum NikonCompressionNL
{

    /// <summary>
    /// The camera applies uniform compression variables to deliver predictable, fixed file sizes. 
    /// This saves storage but can cause compression artifacts in complex, highly detailed textures.
    /// </summary>
    SizePriority = 0,

    /// <summary>
    /// The camera dynamically expands or relaxes the compression algorithm to safeguard subtle details. 
    /// File sizes will vary radically depending on scene complexity and high-ISO noise levels.
    /// </summary>
    OptimalQuality = 1
}
