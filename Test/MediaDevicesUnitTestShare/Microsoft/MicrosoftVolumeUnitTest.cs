namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Microsoft")]
public class MicrosoftVolumeUnitTest : WritableUnitTest
{
    public MicrosoftVolumeUnitTest()
    {
        // Device Test
        this.deviceDescription = "WPD-Dateisystem-Volumetreiber";
        this.deviceFriendlyName = "";
        this.deviceManufacture = "Microsoft";
        this.deviceFirmwareVersion = "";
        this.deviceModel = "";
        this.deviceSerialNumber = "";
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.NotSupported;
        this.devicePowerSource = PowerSource.External;

        // Capability Test
        this.deviceSupportedEvents = [ Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated ];
        this.deviceSupportedCommands = [ Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects ];
        this.deviceSupportedContents = [ ContentType.Image ];

        // ContentLocation Test
        this.deviceContentLocationsImages = [ @"\SD card\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" ];


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
        //this.readonlyEnumSearchPatternFolders = "S*";
        //this.readonlyEnumSearchPatternFiles = "desk*";
        //this.readonlyEnumSearchPatternItems = "*es*";

        //this.readonlyEnumFolders = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots" };

        //this.readonlyEnumFiles = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyEnumItems = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
    }
}
