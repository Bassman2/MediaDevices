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
        this.deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.deviceSupportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.deviceSupportedContents = [ContentType.Image];

        // ContentLocation Test
        this.deviceContentLocationsImages = [""];


        // Exists Test
        this.readonlyFilePath = @"\SD\DCIM\100CANON\IMG_2568.JPG";
                    

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
