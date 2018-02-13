using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaDevices;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MediaDevicesUnitTest
{
    [TestClass]
    public class Nexus7UnitTest : WritableUnitTest
    {
        public Nexus7UnitTest()
        {
            // Device Test
            this.deviceDescription = "Nexus 7";
            this.deviceFriendlyName = "My Nexus 7";
            this.deviceManufacture = "asus";
            this.deviceFirmwareVersion = "1.0";
            this.deviceModel = "Nexus 7";
            this.deviceSerialNumber = "09ecf73a";
            this.deviceDeviceType = DeviceType.MediaPlayer;
            this.deviceTransport = DeviceTransport.USB;
            this.devicePowerSource = PowerSource.Battery;

            // Capability Test
            this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded };
            this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
            this.supportedContents = new List<ContentType> { ContentType.Image, ContentType.Audio, ContentType.Playlist, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder };

            // ContentLocation Test
            this.contentLocations = new List<string> { @"\SD card\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" };


            this.workingFolder = @"\Internal storage\Download";

            // Exists Test
            this.existingFile = @"\Internal storage\Ringtones\hangouts_message.ogg";

            

            this.infoDirectoryName = "Ringtones";
            this.infoDirectoryPath = @"\Internal storage\Ringtones";
            this.infoDirectoryCreationTime = null; 
            this.infoDirectoryLastWriteTime = new DateTime(2015, 10, 06, 13, 41, 07);

            this.infoDirectoryParentName = "Internal storage";
            this.infoDirectoryParentPath = @"\Internal storage";
            this.infoDirectoryParentCreationTime = null;
            this.infoDirectoryParentLastWriteTime = null;

            this.infoFileName = "hangouts_video_call.ogg";
            this.infoFilePath = @"\Internal storage\Ringtones\hangouts_video_call.ogg";
            this.infoFileLength = 70149ul;
            this.infoFileCreationTime = null;
            this.infoFileLastWriteTime = new DateTime(2015, 10, 06, 13, 34, 47);

            this.infoFileParentName = "Ringtones";
            this.infoFileParentPath = @"\Internal storage\Ringtones";
            this.infoFileParentCreationTime = null;
            this.infoFileParentLastWriteTime = new DateTime(2015, 10, 06, 13, 41, 07);

            this.enumDirectory = @"\Internal storage\Download\UnitTest";
            this.enumFolderMask = "x_*";
            this.enumFilesmask = "p_*";
            this.enumItemMask = "x_*";

            this.enumAllFolders = new List<string> { @"\Internal storage\Download\UnitTest\Sub", @"\Internal storage\Download\UnitTest\x_sub" };
            this.enumMaskFolders = new List<string> { @"\Internal storage\Download\UnitTest\x_sub" };

            this.enumAllFiles = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\p-06g.jpg", @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_avatar.png" };
            this.enumMaskFiles = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg" };
            this.enumMaskRecursiveFiles = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\Sub\p_Android_x.jpg" };

            this.enumAllItems = new List<string> { @"\Internal storage\Download\UnitTest\Sub", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\p-06g.jpg", @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_avatar.png" };
            this.enumMaskItems = new List<string> { @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\x_avatar.png" };
            this.enumMaskRecursiveItems = new List<string> { @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\x_sub\x_5890017.png", @"\Internal storage\Download\UnitTest\x_avatar.png" };
        }
    }
}
