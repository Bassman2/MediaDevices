namespace MediaDevicesUnitTest;

public abstract class NikonUnitTest(string testPath) : ReadonlyUnitTest(testPath)
{
    protected List<OpCodesNikon> deviceVendorOpcodes = [];

    [TestMethod]
    [Description("Nikon Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();


        INikonMediaDevice intf = device;

        List<OpCodesNikon> opcodes = [.. intf.VendorOpcodes()];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

}