using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaDevices;
using System.Collections.Generic;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class NiconCoolpixA300 : ReadonlyUnitTest
    {
        public NiconCoolpixA300()
        {
            // Device Test
            this.deviceDescription = "A300";
            this.deviceFriendlyName = "A300";
            this.deviceManufacture = "NIKON";
            this.deviceFirmwareVersion = "COOLPIX A300 V1.2";
            this.deviceModel = "A300";
            this.deviceSerialNumber = "";
            this.deviceDeviceType = DeviceType.Camera;
            this.deviceTransport = DeviceTransport.USB;
            this.devicePowerSource = PowerSource.Battery;
            this.deviceProtocol = "MTP: 1.00";

            // Capability Test
            this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated };
            this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
            this.supportedContents = new List<ContentType> { ContentType.Image };
            this.functionalCategories = new List<FunctionalCategory> { FunctionalCategory.Storage, FunctionalCategory.StillImageCapture };

            // ContentLocation Test
            this.contentLocations = new List<string> { };

            // PersistentUniqueId
            this.FolderPersistentUniqueId = "{00000003-0000-0000-0000-000000000000}";
            this.FolderPersistentUniqueIdPath = @"\A300\DCIM\100NIKON";
            this.FilePersistentUniqueId = "{00000004-0000-0000-0000-000000000000}";
            this.FilePersistentUniqueIdPath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";

            // Exists Test
            this.existingFile = @"\A300\DCIM\100NIKON\DSCN0005.JPG";


            // Directory Info Test
            this.infoDirectoryName = "DCIM";
            this.infoDirectoryPath = @"\A300\DCIM";
            this.infoDirectoryCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoDirectoryLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoDirectoryAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

            this.infoDirectoryParentName = "A300";
            this.infoDirectoryParentPath = @"\A300";
            this.infoDirectoryParentCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoDirectoryParentLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoDirectoryParentAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

            // File InfoTest
            this.infoFileName = "DSCN0005.JPG";
            this.infoFilePath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";
            this.infoFileLength = 4784013ul;
            this.infoFileCreationTime = new DateTime(2017, 11, 15, 20, 55, 54); 
            this.infoFileLastWriteTime = new DateTime(2017, 11, 15, 20, 55, 54);
            this.infoFileAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

            this.infoFileParentName = "100NIKON";
            this.infoFileParentPath = @"\A300\DCIM\100NIKON";
            this.infoFileParentCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoFileParentLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
            this.infoFileParentAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

            this.enumDirectory = @"\A300\DCIM\100NIKON";
            this.enumFolderMask = "*";
            this.enumFilesmask = "*_0002*";
            this.enumItemMask = "*_0003*";

            this.enumAllFolders = new List<string> { };
            this.enumMaskFolders = new List<string> { };

            this.enumAllFiles = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG", @"\A300\DCIM\100NIKON\DSCN0006.JPG", @"\A300\DCIM\100NIKON\DSCN0007.JPG" };
            this.enumMaskFiles = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG" };
            this.enumMaskRecursiveFiles = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG" };

            this.enumAllItems = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG", @"\A300\DCIM\100NIKON\DSCN0006.JPG", @"\A300\DCIM\100NIKON\DSCN0007.JPG" };
            this.enumMaskItems = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG" };
            this.enumMaskRecursiveItems = new List<string> { @"\A300\DCIM\100NIKON\DSCN0005.JPG" };
        }
    }
}
