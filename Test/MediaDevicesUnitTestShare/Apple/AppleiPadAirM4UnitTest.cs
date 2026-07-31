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
        this.ignoreTests = Ignore.FriendlyName | Ignore.DownloadIcon;

        #region Device Tests

        // Device Test
        deviceDescription = "Apple iPad";
        deviceFriendlyName = "Apple iPad";
        deviceManufacture = "Apple Inc."; 
        deviceFirmwareVersion = "26.5.2";
        deviceModel = "Apple iPad";
        deviceSerialNumber = "DC62X123XW";
        deviceSupportsNonConsumable = false;
        deviceDateTimeHasValue = false;
        deviceSupportedFormatsAreOrdered = null;
        deviceDeviceType = DeviceType.Generic;
        deviceTransport = DeviceTransport.USB;
        devicePowerSource = PowerSource.Battery;
        deviceProtocol = "MTP: 1.00";

        // Capability Test
        supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        supportedContents = [ContentType.Image];
        functionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        contentLocations = [];

        // PersistentUniqueId
        //FolderPersistentUniqueId = "{052BDC9B-08B6-A6AB-5591-E52A8B782B74}"; // "{ CF527675-97D8-3DEF-0000-000000000000}";
        //FolderPersistentUniqueIdPath = @"\Phone\Music";
        //FilePersistentUniqueId = "{25606D91-C12C-CF74-93A6-34E88717AD11}"; // "{FDFF71F3-E0BD-D98E-0000-000000000000}";
        //FilePersistentUniqueIdPath = @"\Phone\Samsung\Music\Over_the_Horizon.mp3"; // @"\Phone\Videos\desktop.ini"; Directory = "\\Phone\\Samsung\\Music"

        //this.workingFolder = @"\Card\Test";

        drives = ["Internal Storage"];

        #endregion

        #region Enumerable & List tests

        // file
        readonlyFilePath = @"\Internal Storage\201407_a\BQME4521.JPG";
        readonlyFileLength = 1202261ul;
        readonlyFileCreationTime = new DateTime(2014, 07, 24, 12, 55, 42);
        readonlyFileLastWriteTime = new DateTime(2014, 07, 24, 12, 55, 42);
        readonlyFileAuthoredTime = new DateTime(0001, 01, 01, 00, 00, 00);

        readonlyFileParentPath = @"\Internal Storage\201407_a";
        readonlyFileParentCreationTime = new DateTime(2014, 07, 01, 00, 00, 00);
        readonlyFileParentLastWriteTime = new DateTime(2014, 07, 01, 00, 00, 00);
        readonlyFileParentAuthoredTime = new DateTime(0001, 01, 01, 00, 00, 00);

        // folder
        readonlyFolderPath = @"\Internal Storage\201407_a";
        readonlyFolderCreationTime = new DateTime(2014, 07, 01, 00, 00, 00);
        readonlyFolderLastWriteTime = new DateTime(2014, 07, 01, 00, 00, 00);
        readonlyFolderAuthoredTime = new DateTime(0001, 01, 01, 00, 00, 00);
        
        readonlyFolderParentPath = "\\DCIM";
        readonlyFolderParentCreationTime = new DateTime(2026, 07, 31, 19, 53, 45);
        readonlyFolderParentLastWriteTime = new DateTime(2026, 07, 31, 19, 53, 45);
        readonlyFolderParentAuthoredTime = new DateTime(0001, 01, 01, 00, 00, 00);

        // Enumerable
        readonlyEnumPath = "\\Internal Storage";
        readonlyEnumFolderSearchPattern = "2022S*";
        readonlyEnumFileSearchPattern = "*0713*";
        readonlyEnumItemSearchPattern = "202*";

        readonlyEnumFoldersAll = [];
        readonlyEnumFoldersSearchPattern = [];

        readonlyEnumFilesAll = [];
        readonlyEnumFilesSearchPattern = [];
        readonlyEnumFilesSearchPatternRecursive = [];

        readonlyEnumItemsAll = [];
        readonlyEnumItemsSearchPattern = [];
        readonlyEnumItemsSearchPatternRecursive = [];

        #endregion
    }
}