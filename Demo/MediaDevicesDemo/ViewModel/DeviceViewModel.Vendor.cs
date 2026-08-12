namespace MediaDevicesDemo.ViewModel;

partial class DeviceViewModel
{
    #region Vendor

    public string? VendorExtentionDescription => mediaDevice?.VendorExtentionDescription();

    public List<string>? VendorOpcodes => mediaDevice?.VendorOpcodes().Select(i => i.ToString()).ToList();

    #endregion
}
