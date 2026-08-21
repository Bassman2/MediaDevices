using System;
using System.Collections.Generic;
using System.Text;

namespace MediaDevicesUnitTest;

public abstract class CanonEosUnitTest(string testPath) : ReadonlyUnitTest(testPath)
{
    protected List<OpCodesCanon> deviceVendorOpcodes = [];
        

    [TestMethod]
    [Description("Canon Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();

        ICanonMediaDevice intf = device;
        List<OpCodesCanon> opcodes = [.. intf.VendorOpcodes()];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

}
