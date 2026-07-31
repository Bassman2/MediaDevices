namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonPowerShotSX30UnitTest : ReadonlyUnitTest
{
    public CanonPowerShotSX30UnitTest()
    {
        // Device Test
        this.deviceDescription = "Canon PowerShot SX30 IS";
        this.deviceFriendlyName = "Canon PowerShot SX30 IS";
        this.deviceManufacture = "Canon Inc.";
        this.deviceFirmwareVersion = "1-9.0.1.0";
        this.deviceModel = "Canon PowerShot SX30 IS";
        this.deviceSerialNumber = "03A7D5F390E344A39B4B43A463DB3882";
        this.deviceDeviceType = DeviceType.Camera;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];

        // ContentLocation Test
        this.contentLocations = [""];




        // Exists Test
        this.readonlyFilePath = @"\Wechselmedien\DCIM\101___06\IMG_0477.JPG";

        

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
        this.readonlyEnumFolderSearchPattern = "*";
        this.readonlyEnumFileSearchPattern = "*_0002*";
        this.readonlyEnumItemSearchPattern = "*_0003*";

        this.readonlyEnumFoldersAll = [];
        this.readonlyEnumFoldersSearchPattern = [];

        this.readonlyEnumFilesAll = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumFilesSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];
        this.readonlyEnumFilesSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];

        this.readonlyEnumItemsAll = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
    }
}
