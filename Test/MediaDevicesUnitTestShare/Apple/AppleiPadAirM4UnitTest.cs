namespace MediaDevicesUnitTest;


[TestClass]
[TestCategory("Apple")]
public class AppleiPadAirM4UnitTest : ReadonlyUnitTest
{
    public AppleiPadAirM4UnitTest()
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;

        // Ignore tests
        this.ignoreTests = Ignore.FriendlyName;

        // Device Test
        this.deviceDescription = "Apple iPad";
        this.deviceFriendlyName = "Apple iPad";
        this.deviceManufacture = "Apple Inc."; 
        this.deviceFirmwareVersion = "26.5.2";
        this.deviceModel = "Apple iPad";
        this.deviceSerialNumber = "DC62X123XW";
        this.deviceSupportsNonConsumable = false;
        this.deviceDateTimeHasValue = false;
        this.deviceSupportedFormatsAreOrdered = null;
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;
        this.deviceProtocol = "MTP: 1.00";

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];
        this.functionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.contentLocations = [];

        // PersistentUniqueId
        this.FolderPersistentUniqueId = "{052BDC9B-08B6-A6AB-5591-E52A8B782B74}"; // "{ CF527675-97D8-3DEF-0000-000000000000}";
        this.FolderPersistentUniqueIdPath = @"\Phone\Music";
        this.FilePersistentUniqueId = "{25606D91-C12C-CF74-93A6-34E88717AD11}"; // "{FDFF71F3-E0BD-D98E-0000-000000000000}";
        this.FilePersistentUniqueIdPath = @"\Phone\Samsung\Music\Over_the_Horizon.mp3"; // @"\Phone\Videos\desktop.ini"; Directory = "\\Phone\\Samsung\\Music"

        //this.workingFolder = @"\Card\Test";

        this.drives = ["Internal Storage"];

        // Exists Test
        //this.existingFile = @"\Phone\Music\Artist\05 - Decoupage.mp3";

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