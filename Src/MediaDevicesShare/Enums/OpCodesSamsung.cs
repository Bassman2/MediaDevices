namespace MediaDevices;

public enum OpCodesSamsung
{
    #region Samsung

    /// <summary>
    /// Samsung vendor-specific opcode (0x9501).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown1 = 0x9501,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9502).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown2 = 0x9502,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9503).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown3 = 0x9503,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9504).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown4 = 0x9504,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9201).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown5 = 0x9201,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9202).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Unknown6 = 0x9202,

    #endregion
}
