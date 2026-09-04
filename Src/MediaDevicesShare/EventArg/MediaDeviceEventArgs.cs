namespace MediaDevices;

/// <summary>
/// Event argument class for media mediaDevice events
/// </summary>
public class MediaDeviceEventArgs : EventArgs
{
    private const int OK = 0;

    internal MediaDeviceEventArgs(Events eventEnum, IDevice device)
    {
        this.device = device;
        this.Event = eventEnum;

        //if (eventParameters.GetStringValue(ref WPD.EVENT_PARAMETER_PNP_DEVICE_ID, out string pnpDeviceId) == OK)
        //{
        //    PnpDeviceId = pnpDeviceId;
        //}
        //if (eventParameters.GetUnsignedIntegerValue(ref WPD.EVENT_PARAMETER_OPERATION_STATE, out uint operationState) == OK)
        //{
        //    OperationState = (OperationState)operationState; 
        //}
        //if (eventParameters.GetUnsignedIntegerValue(ref WPD.EVENT_PARAMETER_OPERATION_PROGRESS, out uint operationProgress) == OK)
        //{
        //    this.OperationProgress = operationProgress;
        //}
        //if (eventParameters.GetStringValue(ref WPD.EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID, out string objectParentPersistanceUniqueId) == OK)
        //{
        //    this.ObjectParentPersistanceUniqueId = objectParentPersistanceUniqueId;
        //}
        //if (eventParameters.GetStringValue(ref WPD.EVENT_PARAMETER_OBJECT_CREATION_COOKIE, out string objectCreationCookie) == OK)
        //{
        //    this.ObjectCreationCookie = objectCreationCookie;
        //}
        //if (eventParameters.GetBoolValue(ref WPD.EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED, out int childHierarchyChanged) == OK)
        //{
        //    this.ChildHierarchyChanged = childHierarchyChanged != 0;
        //}
        //if (eventParameters.GetStringValue(ref WPD.EVENT_PARAMETER_SERVICE_METHOD_CONTEXT, out string serviceMethodContext) == OK)
        //{
        //    this.ServiceMethodContext = serviceMethodContext;
        //}
    }

    /// <summary>
    /// Corresponding media mediaDevice
    /// </summary>
    private IDevice device;

    /// <summary>
    /// Indicates the event sent.
    /// </summary>
    public Events Event { get; private set; }

    /// <summary>
    /// Indicates the mediaDevice that originated the event.
    /// </summary>
    public string? PnpDeviceId { get; private set; }
    
    /// <summary>
    /// Indicates the current state of the operation (e.g. started, running, stopped etc.).
    /// </summary>
    public OperationState? OperationState { get; private set; }

    /// <summary>
    /// Indicates the progress of a currently executing operation. Value is from 0 to 100, with 100 indicating that the operation is complete.
    /// </summary>
    public uint? OperationProgress { get; private set; }

    /// <summary>
    /// Uniquely identifies the parent object, similar to WPD_OBJECT_PARENT_ID, but this ID will not change between sessions.
    /// </summary>
    public string? ObjectParentPersistanceUniqueId { get; private set; }

    /// <summary>
    /// This is the cookie handed back to a client when it requested an object creation using the IPortableDeviceContent::CreateObjectWithPropertiesAndData method.
    /// </summary>
    public string? ObjectCreationCookie { get; private set; }

    /// <summary>
    /// Indicates that the child hierarchy for the object has changed.
    /// </summary>
    public bool? ChildHierarchyChanged { get; private set; }

    /// <summary>
    /// Indicates the service method invocation context.
    /// </summary>
    public string? ServiceMethodContext { get; private set; }
}
