namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Nokia")]
public class NokiaLumia630UnitTest : WritableUnitTest
{
    public NokiaLumia630UnitTest()
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;

        // Device Test
        this.deviceDescription = "Lumia 630 Dual SIM";
        this.deviceFriendlyName = "Ralf Phone";
        this.deviceManufacture = "NOKIA";
        this.deviceFirmwareVersion = "8.10.14234.0";
        this.deviceModel = "Lumia 630 Dual SIM";
        this.deviceSerialNumber = "29918575d76ae110111b8ced6429e399";
        this.deviceDeviceType = DeviceType.Phone;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.External;

        // Capability Test
        this.supportedEvents = [ Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated ];
        this.supportedCommands = [ Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects ];
        this.supportedContents = [ ContentType.Image ];

        // ContentLocation Test
        this.contentLocations = [ @"\SD card\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" ];

        this.workingFolder = @"\Phone\Documents";

        // Exists Test
        //this.existingFile = @"\Phone\Music\Artist\OMD";

        //this.infoDirectoryName = "Pictures";
        //this.infoDirectoryPath = @"\SD card\Pictures";
        //this.infoDirectoryCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.infoDirectoryLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.infoDirectoryParentName = "SD card";
        //this.infoDirectoryParentPath = @"\SD card";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFileName = "Frank2.jpg";
        //this.infoFilePath = @"\SD card\Pictures\Frank2.jpg";
        //this.readonlyFileLength = 232663ul;
        //this.readonlyFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
        //this.readonlyFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

        //this.infoFileParentName = "Pictures";
        //this.infoFileParentPath = @"\SD card\Pictures";
        //this.readonlyFolderCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.readonlyFolderLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.readonlyEnumPath = @"\Phone\Pictures";
        //this.readonlyEnumFolderSearchPattern = "S*";
        //this.readonlyEnumFileSearchPattern = "desk*";
        //this.readonlyEnumItemSearchPattern = "*es*";

        //this.readonlyEnumFoldersAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };

        //this.readonlyEnumFilesAll = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyEnumItemsAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
    }
}
