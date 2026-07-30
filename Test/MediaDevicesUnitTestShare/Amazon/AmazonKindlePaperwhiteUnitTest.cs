namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Amazon")]
public class AmazonKindlePaperwhiteUnitTest : WritableUnitTest
{
    private string deviceLetter = "E";

    public AmazonKindlePaperwhiteUnitTest()
    {
        // Device Test
        this.deviceDescription = "Internal Storage";
        this.deviceFriendlyName = "KINDLE";
        this.deviceManufacture = "Kindle  ";
        this.deviceFirmwareVersion = "0100";
        this.deviceModel = "Internal Storage";
        this.deviceSerialNumber = ""; // G090G10573570BNQ
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.Unspecified;
        this.devicePowerSource = PowerSource.External;
        this.deviceProtocol = "MSC:";

        // Capability Test
        this.supportedEvents = [Events.ObjectAdded, Events.ObjectRemoved, Events.ObjectUpdated];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectEnumerationFindNext, Commands.ObjectEnumerationEndFind,
            Commands.ObjectManagementDeleteObjects, Commands.ObjectManagementCreateObjectWithPropertiesOnly, Commands.ObjectManagementCreateObjectWithPropertiesAndData,
            Commands.ObjectManagementWriteObjectData, Commands.ObjectManagementCommitObject, Commands.ObjectManagementRevertObject
        ];
        this.supportedContents = [ContentType.Unspecified, ContentType.Folder, ContentType.Audio, ContentType.Video, ContentType.Image, ContentType.Contact];
        this.functionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.contentLocations = [];

        // PersistentUniqueId
        this.FolderPersistentUniqueId = $"{deviceLetter}%3B%5Csystem%5Cstartactions";
        this.FolderPersistentUniqueIdPath = $@"\{deviceLetter}:\system\startactions";
        this.FilePersistentUniqueId = $"{deviceLetter}%3B%5Csystem%5Cversion.txt";
        this.FilePersistentUniqueIdPath = $@"\{deviceLetter}:\system\version.txt";

        // Writable Tests
        this.workingFolder = $@"\{deviceLetter}:\documents";


        // Exists Test
        //this.existingFile = @"\E:\documents\Old Firehand_B004WLCSLC.sdr\Old Firehand_B004WLCSLC.phl";


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
        //this.readonlyTestFileLength = 232663ul;
        //this.readonlyTestFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
        //this.readonlyTestFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

        //this.infoFileParentName = "Pictures";
        //this.infoFileParentPath = @"\SD card\Pictures";
        //this.readonlyTestFolderCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.readonlyTestFolderLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.readonlyTestEnumPath = @"\Phone\Pictures";
        //this.readonlyTestEnumFolderSearchPattern = "S*";
        //this.readonlyTestEnumFileSearchPattern = "desk*";
        //this.readonlyTestEnumItemSearchPattern = "*es*";

        //this.readonlyTestEnumFoldersAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
        //this.readonlyTestEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

        //this.readonlyTestEnumFilesAll = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyTestEnumItemsAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyTestEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
    }
}
