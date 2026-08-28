namespace MediaDevices;

public enum NikonRawCompression : ushort
{
    /// <summary>
    /// Reversible compression algorithm. 
    /// Saves roughly 20-40% card space with absolutely zero image quality degradation when opened.
    /// </summary>
    LosslessCompressed = 0,

    /// <summary>
    /// Non-reversible algorithm. 
    /// Discards imperceptible highlight data to reduce file sizes by roughly 40-50%.
    /// </summary>
    Compressed = 1,

    /// <summary>
    /// Raw data is written to the buffer exactly as read off the sensor matrix. 
    /// Results in maximum file sizes and slower write speeds.
    /// </summary>
    Uncompressed = 2,

    /// <summary>
    /// Found on newer Z-series bodies (like Z8, Z9). 
    /// Uses advanced hardware codecs (TicoRAW) to drastically compress files while maintaining high fidelity.
    /// </summary>
    HighEfficiency = 3,

    /// <summary>
    /// Found on newer Z-series bodies (like Z8, Z9). 
    /// Uses advanced hardware codecs (TicoRAW) to drastically compress files while maintaining high fidelity.
    /// </summary>
    HighEfficiency2 = 4

    
}
