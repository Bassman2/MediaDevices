using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaDevices;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class AppleiPodNanoUnitTest : UnitTest
    {
        public AppleiPodNanoUnitTest()
        {
            this.deviceDescription = "iPod";
            this.deviceFriendlyName = "AVALON";
            this.deviceManufacture = "Apple";
            this.deviceFirmwareVersion = "1.62";
            this.deviceModel = "iPod";
            this.deviceSerialNumber = "YM8382LQ5BD";
            this.deviceDeviceType = DeviceType.Generic;
            this.deviceTransport = DeviceTransport.USB;
            this.devicePowerSource = PowerSource.Battery;
            this.devicePnPDeviceID = @"";

            this.workingFolder = @"\Internal Storage\DCIM";

            this.existingDirectory = @"\Internal Storage\DCIM";
            this.existingFile = @"Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";

            this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated };
            this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
            this.supportedContents = new List<ContentType> { ContentType.Image };

            this.contentLocations = new List<string> { "" };

            this.infoDirectoryName = "DCIM";
            this.infoDirectoryPath = @"\Internal Storage\DCIM";
            this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
            this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

            this.infoDirectoryParentName = "Internal Storage";
            this.infoDirectoryParentPath = @"\Internal Storage";
            this.infoDirectoryParentCreationTime = null;
            this.infoDirectoryParentLastWriteTime = null;

            this.infoFileName = "IMG_0001.JPG";
            this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
            this.infoFileLength = 467430ul;
            this.infoFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
            this.infoFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

            this.infoFileParentName = "800AAAAA";
            this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
            this.infoFileParentCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
            this.infoFileParentLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

            this.enumDirectory = @"\Internal Storage\DCIM\800AAAAA";
            this.enumFolderMask = "*";
            this.enumFilesmask = "*_0002*";
            this.enumItemMask = "*_0003*";

            this.enumAllFolders = new List<string> { };
            this.enumMaskFolders = new List<string> { };

            this.enumAllFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
            this.enumMaskFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG" };
            this.enumMaskRecursiveFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG" };

            this.enumAllItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
            this.enumMaskItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
            this.enumMaskRecursiveItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
        }
    }
}
