namespace MediaDevices;

/// <summary>
/// Event argument class for the media mediaDevice object added event.
/// </summary>
public class ObjectAddedEventArgs : MediaDeviceEventArgs
{
    private const int OK = 0;

    internal ObjectAddedEventArgs(Events eventEnum, IDevice device) 
        : base(eventEnum, device)
    {
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_ID, out string objectId) == OK)
        //{
        //    ObjectId = objectId;
        //}
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_PERSISTENT_UNIQUE_ID, out string objectPersistentUniqueId) == OK)
        //{
        //    this.ObjectPersistentUniqueId = objectPersistentUniqueId;
        //}
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_NAME, out string objectName) == OK)
        //{
        //    this.ObjectName = objectName;
        //}
        //if (eventParameters.GetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, out Guid objectContentType) == OK)
        //{
        //    this.ObjectContentType = objectContentType.ToContentTypeEnum();
        //}
        //if (eventParameters.GetGuidValue(ref WPD.FUNCTIONAL_OBJECT_CATEGORY, out Guid functionalObjectCategory) == OK)
        //{
        //    this.FunctionalObjectCategory = functionalObjectCategory.ToFunctionalCategoryEnum();
        //}
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, out string objectOriginalFileName) == OK)
        //{
        //    this.ObjectOriginalFileName = objectOriginalFileName;
        //}
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_PARENT_ID, out string objectParentId) == OK)
        //{
        //    this.ObjectParentId = objectParentId;
        //}
        //if (eventParameters.GetStringValue(ref WPD.OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID, out string objectContainerFuntionalObjectId) == OK)
        //{
        //    this.ObjectContainerFuntionalObjectId = objectContainerFuntionalObjectId;
        //}
    }

    /// <summary>
    /// Id of the added object.
    /// </summary>
    public string? ObjectId { get; private set; }

    /// <summary>
    /// Persistent unique id of the added object.
    /// </summary>
    public string? ObjectPersistentUniqueId { get; private set; }

    /// <summary>
    /// Name of the added object.
    /// </summary>
    public string? ObjectName { get; private set; }

    /// <summary>
    /// Content type of the added object.
    /// </summary>
    public ContentType? ObjectContentType { get; private set; }

    /// <summary>
    /// Functional category of the added object
    /// </summary>
    public FunctionalCategory? FunctionalObjectCategory { get; private set; }

    /// <summary>
    /// Original file name of the added object
    /// </summary>
    public string? ObjectOriginalFileName { get; private set; }

    /// <summary>
    /// Parent id of the added object.
    /// </summary>
    public string? ObjectParentId { get; private set; }

    /// <summary>
    /// Container functional id of the added object. 
    /// </summary>
    public string? ObjectContainerFuntionalObjectId { get; private set; }

    ///// <summary>
    ///// Full file name of the added object
    ///// </summary>
    //public string ObjectFullFileName => WpdItem.Create(this.MediaDevice, this.ObjectId!).FullName;
        
    ///// <summary>
    ///// Read stream of the added object
    ///// </summary>
    //public Stream ObjectFileStream => WpdItem.Create(this.MediaDevice, this.ObjectId!).OpenRead();
}
