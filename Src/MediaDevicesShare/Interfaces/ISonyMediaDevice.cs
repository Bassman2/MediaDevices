namespace MediaDevices;

public interface ISonyMediaDevice
{
    IEnumerable<OpCodesSony> VendorOpcodes();
    
    #region Standard Base Registers(Shared with Standard PTP)

    SonyCompression? Compression { get; set; }

    #endregion

    #region Proprietary Sony Custom Extension Registers(0xD200 Block)

    #endregion

    #region Remote Programmatic Button Intercepts(Control Handshakes)

    #endregion
}
