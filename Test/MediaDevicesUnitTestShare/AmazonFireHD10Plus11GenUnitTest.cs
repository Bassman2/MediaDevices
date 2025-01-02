﻿using MediaDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class AmazonFireHD10Plus11GenUnitTest : WritableUnitTest
    {
        public AmazonFireHD10Plus11GenUnitTest()
        {
            // Device Select
            this.deviceSelect = device => device.Description == this.deviceDescription;

            // Device Test
            this.deviceDescription = "Fire";
            this.deviceFriendlyName = "Fire10Gen11";
            this.deviceManufacture = "Amazon";
            this.deviceFirmwareVersion = "1.0";
            this.deviceModel = "Fire";
            this.deviceSerialNumber = "G001MG0613460HLU";
            this.deviceDeviceType = DeviceType.Generic;
            this.deviceTransport = DeviceTransport.USB;
            this.devicePowerSource = PowerSource.Battery;
            this.deviceProtocol = "MTP: 1.00";

            // Capability Test
            this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated };
            this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
            this.supportedContents = new List<ContentType> { ContentType.Image };
            this.functionalCategories = new List<FunctionalCategory> { FunctionalCategory.Storage };

            // ContentLocation Test
            this.contentLocations = new List<string>(); // new List<string> { @"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" };

            // PersistentUniqueId
            this.FolderPersistentUniqueId = "{00000023-0001-0001-0000-000000000000}";
            this.FolderPersistentUniqueIdPath = @"\Interner Speicher\Download";
            this.FilePersistentUniqueId = "{0000002B-0001-0001-0000-000000000000}";
            this.FilePersistentUniqueIdPath = @"\Interner Speicher\Android\data\com.amazon.ags.app\files\cardcache\version";

            // Writable Tests
            this.workingFolder = @"\Interner Speicher\tmp";


            // Exists Test
            //this.existingFile = @"\Interner Speicher\Download\14.jpg";

            //this.infoDirectoryName = "Pictures";
            //this.infoDirectoryPath = @"\SD card\Pictures";
            //this.infoDirectoryCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
            //this.infoDirectoryLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

            //this.infoDirectoryParentName = "SD card";
            //this.infoDirectoryParentPath = @"\SD card";
            //this.infoDirectoryParentCreationTime = null;
            //this.infoDirectoryParentLastWriteTime = null;

            //this.infoFileName = "Frank2.jpg";
            //this.infoFilePath = @"\SD card\Pictures\Frank2.jpg";
            //this.infoFileLength = 232663ul;
            //this.infoFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
            //this.infoFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

            //this.infoFileParentName = "Pictures";
            //this.infoFileParentPath = @"\SD card\Pictures";
            //this.infoFileParentCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
            //this.infoFileParentLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

            //this.enumDirectory = @"\Phone\Pictures";
            //this.enumFolderMask = "S*";
            //this.enumFilesmask = "desk*";
            //this.enumItemMask = "*es*";

            //this.enumAllFolders = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
            //this.enumMaskFolders = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

            //this.enumAllFiles = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
            //this.enumMaskFiles = new List<string> { @"\Phone\Pictures\desktop.ini" };
            //this.enumMaskRecursiveFiles = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

            //this.enumAllItems = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
            //this.enumMaskItems = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
            //this.enumMaskRecursiveItems = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        }
    }
}