namespace MediaDevicesUnitTest;

[TestClass]
public class CanonEOS60DUnitTest : ReadonlyUnitTest
{
    public CanonEOS60DUnitTest()
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
        this.supportedEvents = new List<Events> { Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated };
        this.supportedCommands = new List<Commands> { Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects };
        this.supportedContents = new List<ContentType> { ContentType.Image };
        
        // ContentLocation Test
        this.contentLocations = new List<string> { "" };


        // Exists Test
        this.existingFile = @"\SD\DCIM\100CANON\IMG_2568.JPG";
                    

        this.infoDirectoryName = "DCIM";
        this.infoDirectoryPath = @"\Internal Storage\DCIM";
        this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.infoDirectoryParentName = "Internal Storage";
        this.infoDirectoryParentPath = @"\Internal Storage";
        this.infoDirectoryParentCreationTime = null;
        this.infoDirectoryParentLastWriteTime = null;

        this.infoFileName = "IMG_0001.JPG";
        this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
        this.infoFileLength = 467430ul;
        this.infoFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.infoFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.infoFileParentName = "800AAAAA";
        this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
        this.infoFileParentCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.infoFileParentLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.enumDirectory = @"\Internal Storage\DCIM\800AAAAA";
        this.enumFolderMask = "*";
        this.enumFilesmask = "*_0002*";
        this.enumItemMask = "*_0003*";

        this.enumAllFolders = new List<string> { };
        this.enumMaskFolders = new List<string> { };

        this.enumAllFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
        this.enumMaskFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG" };
        this.enumMaskRecursiveFiles = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG" };

        this.enumAllItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
        this.enumMaskItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
        this.enumMaskRecursiveItems = new List<string> { @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG" };
    }
}
