namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Kingston")]
public class KingstonFCRHS219UnitTest : WritableUnitTest
{
    public KingstonFCRHS219UnitTest()
    {
        // Device Test
        this.deviceDescription = "FCR-HS219/1     ";
        this.deviceFriendlyName = "T_ASGAR";
        this.deviceManufacture = "Kingston";
        this.deviceFirmwareVersion = "9722";
        this.deviceModel = "FCR-HS219/1     ";
        this.deviceSerialNumber = "";
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.Unspecified;
        this.devicePowerSource = PowerSource.External;

        // Capability Test
        this.supportedEvents = [ Events.ObjectAdded, Events.ObjectRemoved, Events.ObjectUpdated ];
        this.supportedCommands = [ Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects ];
        this.supportedContents = [ ContentType.Unspecified, ContentType.Folder, ContentType.Audio, ContentType.Video, ContentType.Image, ContentType.Contact ];
        this.functionalCategories = [ FunctionalCategory.Storage ];

        // ContentLocation Test
        this.contentLocations = []; // [ @"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" ];

        // PersistentUniqueId
        //this.FolderPersistentUniqueId = "K%3B%5CTest";
        //this.FolderPersistentUniqueIdPath = @"\K:\Test";
        //this.FilePersistentUniqueId = "K%3B%5CTest%5Cdesctop.ini";
        //this.FilePersistentUniqueIdPath = @"\K:\Test\desctop.ini";

        // Writable Tests
        this.workingFolder = @"\K:\Test";


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
        //this.readonlyFileLength = 232663ul;
        //this.readonlyFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
        //this.readonlyFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

        //this.infoFileParentName = "Pictures";
        //this.infoFileParentPath = @"\SD card\Pictures";
        //this.readonlyFolderCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.readonlyFolderLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.readonlyEnumPath = @"\Phone\Pictures";
        //this.readonlyEnumSearchPatternFolders = "S*";
        //this.readonlyEnumSearchPatternFiles = "desk*";
        //this.readonlyEnumSearchPatternItems = "*es*";

        //this.readonlyEnumFolders = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

        //this.readonlyEnumFiles = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyEnumItems = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };


    }
}
