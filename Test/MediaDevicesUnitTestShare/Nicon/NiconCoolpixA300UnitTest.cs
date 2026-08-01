namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Nicon")]
public class NiconCoolpixA300 : ReadonlyUnitTest
{
    public NiconCoolpixA300()
    {
        // Device Test
        this.deviceDescription = "A300";
        this.deviceFriendlyName = "A300";
        this.deviceManufacture = "NIKON";
        this.deviceFirmwareVersion = "COOLPIX A300 V1.4";
        this.deviceModel = "A300";
        this.deviceSerialNumber = "";
        this.deviceDeviceType = DeviceType.Camera;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;
        this.deviceProtocol = "MTP: 1.00";

        // Capability Test
        this.supportedEvents = [ Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated ];
        this.supportedCommands = [ Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects ];
        this.supportedContents = [ ContentType.Image ];
        this.functionalCategories = [ FunctionalCategory.Storage, FunctionalCategory.StillImageCapture ];

        // ContentLocation Test
        this.contentLocations = [];

        // PersistentUniqueId
        //this.FolderPersistentUniqueId = "{00000003-0000-0000-0000-000000000000}";
        //this.FolderPersistentUniqueIdPath = @"\A300\DCIM\100NIKON";
        //this.FilePersistentUniqueId = "{00000004-0000-0000-0000-000000000000}";
        //this.FilePersistentUniqueIdPath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";

        // Exists Test
        this.readonlyFilePath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";


        // Directory Info Test
        //this.infoDirectoryName = "DCIM";
        //this.infoDirectoryPath = @"\A300\DCIM";
        //this.infoDirectoryCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
        //this.infoDirectoryLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
        //this.infoDirectoryAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

        //this.infoDirectoryParentName = "A300";
        //this.infoDirectoryParentPath = @"\A300";
        //this.infoDirectoryParentCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
        //this.infoDirectoryParentLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
        //this.infoDirectoryParentAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

        // File InfoTest
        //this.infoFilePath = @"\A300\DCIM\100NIKON\DSCN0005.JPG";
        this.readonlyFileLength = 4784013ul;
        this.readonlyFileCreationTime = new DateTime(2017, 11, 15, 20, 55, 54); 
        this.readonlyFileLastWriteTime = new DateTime(2017, 11, 15, 20, 55, 54);
        this.readonlyFileAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

        //this.infoFileParentName = "100NIKON";
        //this.infoFileParentPath = @"\A300\DCIM\100NIKON";
        this.readonlyFolderCreationTime = new DateTime(0001, 1, 1, 0, 0, 0);
        this.readonlyFolderLastWriteTime = new DateTime(0001, 1, 1, 0, 0, 0);
        this.readonlyFolderAuthoredTime = new DateTime(0001, 1, 1, 0, 0, 0);

        this.readonlyEnumPath = @"\A300\DCIM\100NIKON";
        this.readonlyEnumSearchPatternFolders = "*";
        this.readonlyEnumSearchPatternFiles = "*_0002*";
        this.readonlyEnumSearchPatternItems = "*_0003*";

        this.readonlyEnumFolders = [];
        this.readonlyEnumFoldersSearchPattern = [];

        this.readonlyEnumFiles = [@"\A300\DCIM\100NIKON\DSCN0005.JPG", @"\A300\DCIM\100NIKON\DSCN0006.JPG", @"\A300\DCIM\100NIKON\DSCN0007.JPG"];
        this.readonlyEnumFilesSearchPattern = [@"\A300\DCIM\100NIKON\DSCN0005.JPG"];
        this.readonlyEnumFilesSearchPatternRecursive =[@"\A300\DCIM\100NIKON\DSCN0005.JPG"];

        this.readonlyEnumItems = [@"\A300\DCIM\100NIKON\DSCN0005.JPG", @"\A300\DCIM\100NIKON\DSCN0006.JPG", @"\A300\DCIM\100NIKON\DSCN0007.JPG"];
        this.readonlyEnumItemsSearchPattern = [@"\A300\DCIM\100NIKON\DSCN0005.JPG"];
        this.readonlyEnumItemsSearchPatternRecursive = [@"\A300\DCIM\100NIKON\DSCN0005.JPG"];
    }
}
