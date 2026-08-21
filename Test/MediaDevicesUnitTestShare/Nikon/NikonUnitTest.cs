namespace MediaDevicesUnitTest;

public abstract class NikonUnitTest(string testPath) : ReadonlyUnitTest(testPath)
{
    protected List<OpCodes> deviceVendorOpcodes = [];

    [TestMethod]
    [Description("Nikon Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();


        List<OpCodes> opcodes = [.. device.VendorOpcodes()];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

}