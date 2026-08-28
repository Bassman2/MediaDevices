namespace MediaDevices;

public interface INikonMediaDevice
{
    IEnumerable<OpCodesNikon> VendorOpcodes();

    // (0 = A, 1 = B, 2 = C, 3 = D)
    int? ShootingMode { get; set; }
    string? ShootingBankNameA { get; set; }
    string? ShootingBankNameB { get; set; }
    string? ShootingBankNameC { get; set; }
    string? ShootingBankNameD { get; set; }

    void ResetCurrentBank();

    NikonRawCompression? RawCompression { get; set; }
}
