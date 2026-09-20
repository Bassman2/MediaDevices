namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Vendor

    public string? VendorExtentionDescription => mediaDevice?.VendorExtentionDescription();

    public List<OpCodes> VendorOpcodes => [.. mediaDevice!.VendorOpcodes()];

    #endregion
}
