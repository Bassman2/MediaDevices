namespace MediaDevices;

public interface ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> VendorOpcodes();
}
