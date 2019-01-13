using MediaDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MediaDevicesUnitTest
{
    public abstract class UnitTest
    {
        // Device Select
        protected Func<MediaDevice, bool> deviceSelect;

        // Device Test
        protected string deviceDescription;
        protected string deviceFriendlyName;
        protected string deviceManufacture;
        protected string deviceFirmwareVersion;
        protected string deviceModel;
        protected string deviceSerialNumber;
        protected DeviceType deviceDeviceType;
        protected DeviceTransport deviceTransport;
        protected PowerSource devicePowerSource;
        protected string deviceProtocol;

        // Capability Test
        protected List<Events> supportedEvents;
        protected List<Commands> supportedCommands;
        protected List<ContentType> supportedContents;
        protected List<FunctionalCategory> functionalCategories;

        // ContentLocation Test
        protected List<string> contentLocations;

        // PersistentUniqueId
        protected string FolderPersistentUniqueId;
        protected string FolderPersistentUniqueIdPath;
        protected string FilePersistentUniqueId;
        protected string FilePersistentUniqueIdPath;

        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        public UnitTest()
        {
            this.deviceSelect = d => d.Description == this.deviceDescription && d.FriendlyName == this.deviceFriendlyName;
        }

        [TestMethod]
        [Description("Basic device tests")]
        public void DeviceTest()
        {
            var devices = MediaDevice.GetDevices().ToArray();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");

            string description = device.Description;
            string friendlyName = device.FriendlyName;
            string manufacture = device.Manufacturer;

            device.Connect();
            string firmwareVersion = device.FirmwareVersion;
            PowerSource powerSource = device.PowerSource;
            int powerLevel = device.PowerLevel;
            string model = device.Model;
            string serialNumber = device.SerialNumber;
            DeviceType deviceType = device.DeviceType;
            DeviceTransport transport = device.Transport;
            string protocol = device.Protocol;
            device.Disconnect();

            Assert.AreEqual(this.deviceDescription, description, "Description");
            Assert.AreEqual(this.deviceFriendlyName, friendlyName, "FriendlyName");
            Assert.AreEqual(this.deviceManufacture, manufacture, "Manufacture");

            Assert.AreEqual(this.deviceFirmwareVersion, firmwareVersion, "FirmwareVersion");
            Assert.AreEqual(this.deviceModel, model, "Model");
            Assert.AreEqual(this.deviceSerialNumber, serialNumber, "SerialNumber");
            Assert.AreEqual(this.deviceDeviceType, deviceType, "DeviceType");
            Assert.AreEqual(this.deviceTransport, transport, "Transport");
            Assert.AreEqual(this.devicePowerSource, powerSource, "PowerSource");
            Assert.AreEqual(this.deviceProtocol, protocol, "Protocol");
            Assert.IsTrue(powerLevel > 0, "PowerLevel");
        }

        [TestMethod]
        [Description("Check compatibility informations.")]
        public void CapabilityTest()
        {
            var devices = MediaDevice.GetDevices().ToList();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var events = device.SupportedEvents()?.ToList();
            var commands = device.SupportedCommands()?.ToList();
            var contents = device.SupportedContentTypes(FunctionalCategory.All)?.ToList();
            var categories = device.FunctionalCategories()?.ToList();

            var stillImageCaptureObjects = device.FunctionalObjects(FunctionalCategory.StillImageCapture).ToList();
            var storageObjects = device.FunctionalObjects(FunctionalCategory.Storage).ToList();
            var smsObjects = device.FunctionalObjects(FunctionalCategory.SMS).ToList();

            device.Disconnect();

            CollectionAssert.IsSubsetOf(supportedEvents, events, "Events");
            CollectionAssert.IsSubsetOf(supportedCommands, commands, "Commands");
            CollectionAssert.IsSubsetOf(supportedContents, contents, "Contents");
            CollectionAssert.AreEquivalent(functionalCategories, categories, "Categories");
        }

        [TestMethod]
        [Description("Check content locations functionality.")]
        public void ContentLocationTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var locations = device.GetContentLocations(ContentType.Image).ToList();

            device.Disconnect();

            CollectionAssert.AreEquivalent(this.contentLocations, locations, "Locations");
        }

        [TestMethod]
        [Description("Check persistent unique id functionality.")]
        public void PersistentUniqueIdTest()
        {
                var devices = MediaDevice.GetDevices();
                var device = devices.FirstOrDefault(this.deviceSelect);
                Assert.IsNotNull(device, "Device");
                device.Connect();

                MediaDirectoryInfo dir = device.GetFileSystemInfoFromPersistentUniqueId(this.FolderPersistentUniqueId) as MediaDirectoryInfo;

                MediaFileInfo file = device.GetFileSystemInfoFromPersistentUniqueId(this.FilePersistentUniqueId) as MediaFileInfo;
                device.Disconnect();

                Assert.IsNotNull(dir, "Dir");
                Assert.IsTrue(dir.Attributes.HasFlag(MediaFileAttributes.Directory), "dir.IsDirectory");
                Assert.AreEqual(this.FolderPersistentUniqueIdPath, dir.FullName, "dir.FullName");

                Assert.IsNotNull(file, "File");
                Assert.IsTrue(file.Attributes.HasFlag(MediaFileAttributes.Normal), "file.IsFile");
                Assert.AreEqual(this.FilePersistentUniqueIdPath, file.FullName, "file.FullName");
        }

        [TestMethod]
        [Description("Check persistent unique id functionality.")]
        public void FriendlyNameTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");

            string disconnectedFriendlyName = device.FriendlyName;

            device.Connect();

            string connectedFriendlyName = device.FriendlyName;

            // some devices use only upper letters in friendly names
            device.FriendlyName = "DUMMY";

            string dummyFriendlyName = device.FriendlyName;

            device.Disconnect();

            string disconnectedDummyFriendlyName = device.FriendlyName;

            device.Connect();

            string connectedDummyFriendlyName = device.FriendlyName;

            device.FriendlyName = connectedFriendlyName;

            device.Disconnect();


            Assert.AreEqual(this.deviceFriendlyName, disconnectedFriendlyName, "disconnectedFriendlyName");
            Assert.AreEqual(this.deviceFriendlyName, connectedFriendlyName, "connectedFriendlyName");
            Assert.AreEqual("DUMMY", dummyFriendlyName, "dummyFriendlyName");
            Assert.AreEqual("DUMMY", disconnectedDummyFriendlyName, "disconnectedDummyFriendlyName");
            Assert.AreEqual("DUMMY", connectedDummyFriendlyName, "connectedDummyFriendlyName");
        }

        [TestMethod]
        [Description("Speed test.")]
        public void SpeedTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var root = device.GetRootDirectory();
            var stopwatch = Stopwatch.StartNew();

            var list = root.EnumerateFileSystemInfos("*", SearchOption.AllDirectories).ToList();

            stopwatch.Stop();

            device.Disconnect();

            double milliseconds = ((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;

            //Assert.AreEqual(0.0, milliseconds, "time");
        }

        [TestMethod]
        [Description("Architecture test.")]
        public void ArchitectureTest()
        {
            int size = IntPtr.Size;
            TestContext.WriteLine($"Pointer size if {size}");
        }
    }
}
