namespace MediaDevices.WindowsPortableDevices;

partial class WpdDevice
{
    public static void ResetDevice(MediaDevice mediaDevice)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command.Create(WPD.COMMAND_COMMON_RESET_DEVICE).Send(mediaDevice.device!);
    }

    public static IEnumerable<string> GetContentLocations(MediaDevice mediaDevice, ContentType contentType)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command cmd = Command.Create(WPD.COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION);
        cmd.Add(WPD.PROPERTY_DEVICE_HINTS_CONTENT_TYPE, contentType.ToGuid());
        if (!cmd.Send(mediaDevice.device!))
        {
            return [];
        }
        return cmd.GetPropVariants(WPD.PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS).Select(c => Item.Create(mediaDevice, c).FullName);
    }

    //public staticvoid Supported(MediaDevice mediaDevice, string id)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();


    //        var values = (IPortableDeviceValues)new PortableDeviceValues();
    //        IPortableDeviceValues result;
    //        values.SetGuidValue(WPD.PROPERTY_COMMON_COMMAND_CATEGORY, WPD.COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED.fmtid);
    //        values.SetUnsignedIntegerValue(WPD.PROPERTY_COMMON_COMMAND_ID, WPD.COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED.pid);

    //        values.SetStringValue(WPD.PROPERTY_OBJECT_PROPERTIES_OBJECT_ID, id);
    //        mediaDevice.mediaDevice.SendCommand(0, values, out result);

    //        object keys = null;
    //        result.GetIUnknownValue(WPD.PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS, out keys);
    //        CommandCheckResult(result);
    //}

    public static bool EjectPath(MediaDevice mediaDevice, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.FindFolder(mediaDevice, path);
        Command cmd = Command.Create(WPD.COMMAND_STORAGE_EJECT);
        cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, item!.Id);
        return cmd.Send(mediaDevice.device!);
    }

    public static bool EjectId(MediaDevice mediaDevice, string id)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command cmd = Command.Create(WPD.COMMAND_STORAGE_EJECT);
        cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, id);
        return cmd.Send(mediaDevice.device!);
    }

    public static void FormatPath(MediaDevice mediaDevice, string path)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Item? item = Item.FindFolder(mediaDevice, path);
        Command cmd = Command.Create(WPD.COMMAND_STORAGE_FORMAT);
        cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, item!.Id);
        cmd.Send(mediaDevice.device!);
    }

    internal static void FormatId(MediaDevice mediaDevice, string id)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command cmd = Command.Create(WPD.COMMAND_STORAGE_FORMAT);
        cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, id);
        cmd.Send(mediaDevice.device!);
    }

    public static bool SendTextSMS(MediaDevice mediaDevice, string functionalObject, string recipient, string text)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command cmd = Command.Create(WPD.COMMAND_SMS_SEND);
        cmd.Add(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
        cmd.Add(WPD.PROPERTY_SMS_RECIPIENT, recipient);
        cmd.Add(WPD.PROPERTY_SMS_MESSAGE_TYPE, (uint)SmsMessageType.Text);
        cmd.Add(WPD.PROPERTY_SMS_TEXT_MESSAGE, text);
        return cmd.Send(mediaDevice.device!);
    }

    public static bool StillImageCaptureInitiate(MediaDevice mediaDevice, string functionalObject)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        Command cmd = Command.Create(WPD.COMMAND_STILL_IMAGE_CAPTURE_INITIATE);
        cmd.Add(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
        return cmd.Send(mediaDevice.device!);
    }

    //internal static Events CallEvent(MediaDevice mediaDevice, IPortableDeviceValues eventParameters)
    //{
    //    eventParameters.GetGuidValue(ref WPD.EVENT_PARAMETER_EVENT_ID, out Guid eventGuid);
    //    return eventGuid.FindEventsEnum();
    //}
    
    public static MediaStorageInfo? GetStorageInfo(MediaDevice mediaDevice, string storageObjectId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();
        
        IPortableDeviceKeyCollection keys = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();
        keys.Add(ref WPD.STORAGE_TYPE);
        keys.Add(ref WPD.STORAGE_FILE_SYSTEM_TYPE);
        keys.Add(ref WPD.STORAGE_CAPACITY);
        keys.Add(ref WPD.STORAGE_FREE_SPACE_IN_BYTES);
        keys.Add(ref WPD.STORAGE_FREE_SPACE_IN_OBJECTS);
        keys.Add(ref WPD.STORAGE_DESCRIPTION);
        keys.Add(ref WPD.STORAGE_SERIAL_NUMBER);
        keys.Add(ref WPD.STORAGE_MAX_OBJECT_SIZE);
        keys.Add(ref WPD.STORAGE_CAPACITY_IN_OBJECTS);
        keys.Add(ref WPD.STORAGE_ACCESS_CAPABILITY);

        var info = new MediaStorageInfo();

        ComTrace.WriteSupportedProperties(mediaDevice.deviceProperties!, storageObjectId);
        ComTrace.WriteValues(mediaDevice.deviceProperties!, storageObjectId);

        int err = mediaDevice.deviceProperties!.GetValues(storageObjectId, keys, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues), storageObjectId);

        if (values.GetUnsignedIntegerValue(ref WPD.STORAGE_TYPE, out uint type) == OK)
        {
            info.Type = (StorageType)type;
        }
        if (values.GetStringValue(ref WPD.STORAGE_FILE_SYSTEM_TYPE, out string fileSystemType) == OK)
        {
            info.FileSystemType = fileSystemType;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.STORAGE_CAPACITY, out ulong capacity) == OK)
        {
            info.Capacity = capacity;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.STORAGE_FREE_SPACE_IN_BYTES, out ulong freeBytes) == OK)
        {
            info.FreeSpaceInBytes = freeBytes;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.STORAGE_FREE_SPACE_IN_OBJECTS, out ulong freeObjects) == OK)
        {
            info.FreeSpaceInObjects = freeObjects;
        }
        if (values.GetStringValue(ref WPD.STORAGE_DESCRIPTION, out string description) == OK)
        {
            info.Description = description;
        }
        if (values.GetStringValue(ref WPD.STORAGE_SERIAL_NUMBER, out string serialNumber) == OK)
        {
            info.SerialNumber = serialNumber;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.STORAGE_MAX_OBJECT_SIZE, out ulong maxObjectSize) == OK)
        {
            info.MaxObjectSize = maxObjectSize;
        }
        if (values.GetUnsignedLargeIntegerValue(ref WPD.STORAGE_CAPACITY_IN_OBJECTS, out ulong capacityInObjects) == OK)
        {
            info.CapacityInObjects = capacityInObjects;
        }
        if (values.GetUnsignedIntegerValue(ref WPD.STORAGE_ACCESS_CAPABILITY, out uint accessCapability) == OK)
        {
            info.AccessCapability = (StorageAccessCapability)accessCapability;
        }

        return info;
    }
}
