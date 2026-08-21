namespace MediaDevices;

public interface INikonMediaDevice
{
    IEnumerable<OpCodesNikon> VendorOpcodes();
}
