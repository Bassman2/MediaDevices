namespace MediaDevicesUnitTest;

public abstract class SamsungUnitTest(string testPath) : WritableUnitTest(testPath)
{
    protected List<OpCodesSamsung> deviceVendorOpcodes = [];

    [TestMethod]
    [Description("Samsung Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();

        ISamsungMediaDevice intf = device; 
        List<OpCodesSamsung> opcodes = [..intf.VendorOpcodes()];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

}
