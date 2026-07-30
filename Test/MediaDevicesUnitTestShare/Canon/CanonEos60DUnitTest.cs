namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonEos60DUnitTest : ReadonlyUnitTest
{
    public CanonEos60DUnitTest()
    {
        

        // Device Test
        this.deviceDescription = "Canon EOS 60D";
        this.deviceFriendlyName = "Canon EOS 60D";
        this.deviceManufacture = "Canon Inc.";
        this.deviceFirmwareVersion = "3-1.0.9";
        this.deviceModel = "Canon EOS 60D";
        this.deviceSerialNumber = "ff76057ad3e84a228e406f41cdd778a6";
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
        this.readonlyTestFilePath = @"\SD\DCIM\100CANON\IMG_2568.JPG";
                    

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
