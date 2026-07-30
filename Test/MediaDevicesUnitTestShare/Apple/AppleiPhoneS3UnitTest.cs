namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Apple")]
public class AppleiPhoneS3UnitTest : ReadonlyUnitTest
{
    public AppleiPhoneS3UnitTest()
    {
        // Find function
        this.deviceSelect = d => d.Description == this.deviceDescription;

        // Device Test
        this.deviceDescription = "Apple iPhone";
        this.deviceFriendlyName = "iPhone von Egon";
        this.deviceManufacture = "Apple Inc.";
        this.deviceFirmwareVersion = "4.2.1";
        this.deviceModel = "Apple iPhone";
        this.deviceSerialNumber = "889155UBY7H";
        this.deviceDeviceType = DeviceType.Camera;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;
        this.deviceProtocol = "PTP: 1.10";

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];
        this.functionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.contentLocations = [];

        // PersistentUniqueId
        this.FolderPersistentUniqueId = "{00430045-0049-004D-0100-010000000000}";
        this.FolderPersistentUniqueIdPath = @"\Internal Storage\DCIM";
        this.FilePersistentUniqueId = "{00070064-0015-0018-3100-3100D6213600}";
        this.FilePersistentUniqueIdPath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";

        // Exists Test
        this.readonlyTestFilePath = @"Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";

        

        //this.infoDirectoryName = "DCIM";
        //this.infoDirectoryPath = @"\Internal Storage\DCIM";
        //this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        //this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoDirectoryParentName = "Internal Storage";
        //this.infoDirectoryParentPath = @"\Internal Storage";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
        this.readonlyTestFileLength = 467430ul;
        this.readonlyTestFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyTestFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoFileParentName = "800AAAAA";
        //this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyTestFolderCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyTestFolderLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.readonlyTestEnumPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyTestEnumFolderSearchPattern = "*";
        this.readonlyTestEnumFileSearchPattern = "*_0002*";
        this.readonlyTestEnumItemSearchPattern = "*_0003*";

        this.readonlyTestEnumFoldersAll = [];
        this.readonlyTestEnumFoldersSearchPattern = [];

        this.readonlyTestEnumFilesAll = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyTestEnumFilesSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];
        this.readonlyTestEnumFilesSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];

        this.readonlyTestEnumItemsAll = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyTestEnumItemsSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyTestEnumItemsSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
    }
}
