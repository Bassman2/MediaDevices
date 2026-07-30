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
        this.readonlyTestFilePath = @"\Wechselmedien\DCIM\101___06\IMG_0477.JPG";

        

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
