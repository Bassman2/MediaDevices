namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Apple")]
public class AppleiPodNanoUnitTest : ReadonlyUnitTest
{
    public AppleiPodNanoUnitTest()
    {
        // Device Test
        this.deviceDescription = "iPod";
        this.deviceFriendlyName = "AVALON";
        this.deviceManufacture = "Apple";
        this.deviceFirmwareVersion = "1.62";
        this.deviceModel = "iPod";
        this.deviceSerialNumber = "YM8382LQ5BD";
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated] ;
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];

        // ContentLocation Test
        this.contentLocations = [""];

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
