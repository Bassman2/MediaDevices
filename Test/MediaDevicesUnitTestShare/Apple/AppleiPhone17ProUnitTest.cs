namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Apple")]
public class AppleiPhone17ProUnitTest : ReadonlyUnitTest
{

    public AppleiPhone17ProUnitTest()
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;
        // Device Test
        this.deviceDescription = "Apple iPhone";
        this.deviceFriendlyName = "Apple iPhone";
        this.deviceManufacture = "Apple Inc.";
        this.deviceFirmwareVersion = "26.5.2";
        this.deviceModel = "Apple iPhone";
        this.deviceSerialNumber = "KT2HQKH5CF";
        this.deviceDeviceType = DeviceType.Generic;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;
        this.deviceProtocol = "MTP: 1.00";
        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [
            ContentType.Image,
            ContentType.Audio,
            ContentType.Video,
            ContentType.Unspecified,
            ContentType.Folder];
        this.functionalCategories = [
            FunctionalCategory.Storage];
        // ContentLocation Test
        this.contentLocations = [];
    }
}
