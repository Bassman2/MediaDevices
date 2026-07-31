namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Microsoft")]
public class MicrosoftLumia650UnitTest : WritableUnitTest
{
    public MicrosoftLumia650UnitTest()
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;

        // Device Test
        this.deviceDescription = "Lumia 650 Dual SIM";
        this.deviceFriendlyName = "Ralf Phone";
        this.deviceManufacture = "Microsoft";
        this.deviceFirmwareVersion = "10.0.15254.0";
        this.deviceModel = "Lumia 650 Dual SIM";
        this.deviceSerialNumber = "9aaa36ebd8901685d39337ced4b30893";
        this.deviceDeviceType = DeviceType.Phone;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;
        this.deviceProtocol = "MTP: 1.00";

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];
        this.functionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // ContentLocation Test
        this.contentLocations = [@"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures"];

        // PersistentUniqueId
        //this.FolderPersistentUniqueId = "{CF527675-97D8-3DEF-0000-000000000000}";
        //this.FolderPersistentUniqueIdPath = @"\Phone\Music\Album";
        //this.FilePersistentUniqueId = "{FDFF71F3-E0BD-D98E-0000-000000000000}";
        //this.FilePersistentUniqueIdPath = @"\Phone\Videos\desktop.ini";

        this.workingFolder = @"\Phone\Documents";

        // Exists Test
        //this.existingFile = @"\Phone\Music\Artist\05 - Decoupage.mp3";

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

        //this.readonlyEnumFoldersAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

        //this.readonlyEnumFilesAll = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyEnumItemsAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
    }
}
