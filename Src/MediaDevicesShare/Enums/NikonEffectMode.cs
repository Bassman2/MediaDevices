namespace MediaDevices;

public enum NikonEffectMode : ushort
{
    /// <summary>
    /// Forces high ISO amplification and drop-renders color pixels into a monochrome layout.
    /// </summary>
    NightVision = 0,

    /// <summary>
    /// Detects sharp contrast edges and sketch-lines textures while down-sampling color fields.
    /// </summary>
    ColorSketch = 1,

    /// <summary>
    /// Applies a top-and-bottom Gaussian blur graduation field to simulate a tilt-shift look.
    /// </summary>
    MiniatureEffect = 2,

    /// <summary>
    /// Drops all pixel color arrays down to zero saturation, isolating only a singular designated color hue.
    /// </summary>
    SelectiveColor = 3,

    /// <summary>
    /// Shapes high contrast matrices to clip shadow tones directly to black.
    /// </summary>
    Silhouette = 4,

    /// <summary>
    /// Over-biases the sensor exposure lookup curves to yield bright, highly luminous tones.
    /// </summary>
    HighKey = 5,

    /// <summary>
    /// Drops highlight limits to darken tone curves for somber compositions.
    /// </summary>
    LowKey = 6
}
