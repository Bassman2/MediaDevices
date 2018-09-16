using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaDevices;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Text;

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

        // Capability Test
        protected List<Events> supportedEvents;
        protected List<Commands> supportedCommands;
        protected List<ContentType> supportedContents;
        protected List<FunctionalCategory> functionalCategories;

        // ContentLocation Test
        protected List<string> contentLocations;

        

        public UnitTest()
        {
            this.deviceSelect = device => device.Description == this.deviceDescription;
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


        

        

        
    }
}
