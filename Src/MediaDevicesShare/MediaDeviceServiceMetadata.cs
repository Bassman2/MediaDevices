namespace MediaDevices;

/// <summary>
/// Metadata service class
/// </summary>
public class MediaDeviceServiceMetadata : MediaDeviceService
{
    internal MediaDeviceServiceMetadata(IDevice device, string serviceId) : base(device, serviceId)
    { }

    /// <summary>
    /// Update service 
    /// </summary>
    protected override void Update()
    {
        IPortableDeviceKeyCollection keyCol = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();

        //(IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();
        //int err = ComHelper.CreateInstance<IPortableDeviceKeyCollection>(ref CLSID.PortableDeviceKeyCollection, out var keyCol);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceKeyCollection));


        keyCol.Add(ref WPD.OBJECT_PARENT_ID);
        keyCol.Add(ref WPD.OBJECT_NAME);
        keyCol.Add(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID);
        keyCol.Add(ref WPD.OBJECT_FORMAT);
        keyCol.Add(ref WPD.OBJECT_SIZE);
        keyCol.Add(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID);
        keyCol.Add(ref WPD.OBJECT_LANGUAGE_LOCALE);
        keyCol.Add(ref WPD.ContentID);
        keyCol.Add(ref WPD.DefaultCAB);
        
        /*
        IPortableDeviceValues values = GetProperties(keyCol);

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_PARENT_ID, out value.Value);
            this.ParentId = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_NAME, out value.Value);
            this.Name = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID, out value.Value);
            this.PUOID = value;
        }


        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_FORMAT, out value.Value);
            this.ObjectFormat = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_SIZE, out value.Value);
            this.ObjectSize = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out value.Value);
            this.StorageID = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.OBJECT_LANGUAGE_LOCALE, out value.Value);
            this.LanguageLocale = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.ContentID, out value.Value);
            this.ContentID = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.DefaultCAB, out value.Value);
            this.DefaultCAB = value;
        }
        */
    }

    /// <summary>
    /// Parent ID.
    /// </summary>
    public string? ParentId { get; private set; }

    /// <summary>
    /// Display name for this object.
    /// </summary>
    public new string? Name { get; private set; }

    /// <summary>
    /// Persistent object unique ID. This must be a GUID.
    /// </summary>
    public string? PUOID { get; private set; }

    /// <summary>
    /// MTP format code that this object represents.
    /// </summary>
    public Guid ObjectFormat { get; private set; }

    /// <summary>
    /// Size of this object in bytes.
    /// </summary>
    public ulong ObjectSize { get; private set; }

    /// <summary>
    /// Storage ID for this object.
    /// </summary>
    public string? StorageID { get; private set; }

    /// <summary>
    /// Locale of the CAB contents. The locale must be composed of valid RFC4646 subtags (for example, “en-US”).
    /// </summary>
    public string? LanguageLocale { get; private set; }

    /// <summary>
    /// ID that uniquely identifies the CAB contents. This ID is a GUID that is assigned by the Windows logo signing process.
    /// </summary>
    public string? ContentID { get; private set; }

    /// <summary>
    /// Boolean value that indicates whether the object is the default Device Metadata CAB object. The Device Metadata service must have only one object that is marked as default.
    /// </summary>
    public bool DefaultCAB { get; private set; }
}
