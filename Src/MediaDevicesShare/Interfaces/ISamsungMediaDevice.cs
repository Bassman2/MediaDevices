namespace MediaDevices;

public interface ISamsungMediaDevice
{
    IEnumerable<OpCodesSamsung> VendorOpcodes();
}
