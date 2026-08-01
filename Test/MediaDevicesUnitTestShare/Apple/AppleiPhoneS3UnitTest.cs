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
        this.deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.deviceSupportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.deviceSupportedContents = [ContentType.Image];
        this.deviceFunctionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.deviceContentLocationsImages = [];

        // PersistentUniqueId
        //this.FolderPersistentUniqueId = "{00430045-0049-004D-0100-010000000000}";
        //this.FolderPersistentUniqueIdPath = @"\Internal Storage\DCIM";
        //this.FilePersistentUniqueId = "{00070064-0015-0018-3100-3100D6213600}";
        //this.FilePersistentUniqueIdPath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";

        // Exists Test
        this.readonlyFilePath = @"Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";

        

        //this.infoDirectoryName = "DCIM";
        //this.infoDirectoryPath = @"\Internal Storage\DCIM";
        //this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        //this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoDirectoryParentName = "Internal Storage";
        //this.infoDirectoryParentPath = @"\Internal Storage";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
        this.readonlyFileLength = 467430ul;
        this.readonlyFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoFileParentName = "800AAAAA";
        //this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyFolderCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFolderLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.readonlyEnumPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyEnumSearchPatternFolders = "*";
        this.readonlyEnumSearchPatternFiles = "*_0002*";
        this.readonlyEnumSearchPatternItems = "*_0003*";

        this.readonlyEnumFolders = [];
        this.readonlyEnumFoldersSearchPattern = [];

        this.readonlyEnumFiles = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumFilesSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];
        this.readonlyEnumFilesSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];

        this.readonlyEnumItems = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
    }
}
