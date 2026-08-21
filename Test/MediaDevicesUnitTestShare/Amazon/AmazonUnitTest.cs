namespace MediaDevicesUnitTest;

public abstract class AmazonUnitTest(string testPath) : ReadonlyUnitTest(testPath)
{
    protected List<OpCodes> deviceVendorOpcodes = [];

    [TestMethod]
    [Description("Amazon Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();

        List<OpCodes> opcodes = [.. device.VendorOpcodes()];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

}

