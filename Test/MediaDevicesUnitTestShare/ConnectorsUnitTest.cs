using System;
using System.Linq;
using MediaDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class ConnectorsUnitTest
    {
        [TestMethod]
        public void ConnectorsTest()
        {
            var connectors = MediaDeviceConnectors.Connectors()?.ToList();
        }
    }
}
