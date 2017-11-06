using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaDevices;
using System.Linq;
using System.Collections.Generic;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class MicrosoftVolumeUnitTest : UnitTest
    {
        public MicrosoftVolumeUnitTest()
        {
            this.deviceDescription = "WPD-Dateisystem-Volumetreiber";
            this.deviceFriendlyName = "";
            this.deviceManufacture = "Microsoft";
            this.deviceFirmwareVersion = "";
            this.deviceModel = "";
            this.deviceSerialNumber = "";
            this.deviceDeviceType = DeviceType.Generic;
            this.deviceTransport = DeviceTransport.NotSupported;
            this.devicePowerSource = PowerSource.External;
            this.devicePnPDeviceID = @"";

            this.workingFolder = @"\Phone\Documents";

            this.existingDirectory = @"\Phone\Music\Artist";
            this.existingFile = @"\Phone\Music\Artist\OMD";

            this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated };
            this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
            this.supportedContents = new List<ContentType> { ContentType.Image };

            this.contentLocations = new List<string> { @"\SD card\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" };

            this.infoDirectoryName = "Pictures";
            this.infoDirectoryPath = @"\SD card\Pictures";
            this.infoDirectoryCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
            this.infoDirectoryLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

            this.infoDirectoryParentName = "SD card";
            this.infoDirectoryParentPath = @"\SD card";
            this.infoDirectoryParentCreationTime = null;
            this.infoDirectoryParentLastWriteTime = null;

            this.infoFileName = "Frank2.jpg";
            this.infoFilePath = @"\SD card\Pictures\Frank2.jpg";
            this.infoFileLength = 232663ul;
            this.infoFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
            this.infoFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

            this.infoFileParentName = "Pictures";
            this.infoFileParentPath = @"\SD card\Pictures";
            this.infoFileParentCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
            this.infoFileParentLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

            this.enumDirectory = @"\Phone\Pictures";
            this.enumFolderMask = "S*";
            this.enumFilesmask = "desk*";
            this.enumItemMask = "*es*";

            this.enumAllFolders = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };
            this.enumMaskFolders = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };

            this.enumAllFiles = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
            this.enumMaskFiles = new List<string> { @"\Phone\Pictures\desktop.ini" };
            this.enumMaskRecursiveFiles = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

            this.enumAllItems = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
            this.enumMaskItems = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
            this.enumMaskRecursiveItems = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
        }
    }
}
