namespace MediaDevices;

public enum OpCodesMicrosoft : ushort
{
    #region Microsoft Zune (0x9204)

    /// <summary>
    /// Represents an undefined Microsoft Zune operation code.
    /// </summary>
    /// <remarks>
    /// This is a vendor-specific opcode used by Microsoft Zune devices. The exact functionality
    /// of this operation is not documented or is device-specific. This opcode should be handled
    /// with care as its behavior may vary depending on the device implementation.
    /// </remarks>
    Zune_GetUndefined001 = 0x9204,

    #endregion
}
