namespace MediaDevicesUnitTest;

[TestClass]
public class ConnectorsUnitTest
{
    [TestMethod]
    public void ConnectorsTest()
    {
        var connectors = MediaDeviceConnectors.Connectors()?.ToList();
    }
}
