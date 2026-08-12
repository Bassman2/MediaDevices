namespace MediaDevices.Internal;

internal static class ComTrace
{
    private const string line = "################################################################################";

    #region IPortableDeviceValues
    
    [Conditional("DEBUG")]
    public static void WriteValues(
        IPortableDeviceValues values,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);
        
        Debug.WriteLine(line);
        Debug.WriteLine($"##  at {filePath} ({lineNumber}) {memberName}");

        uint num = 0;
        int err = values.GetCount(ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));

        for (uint i = 0; i < num; i++)
        {
            PropVariantFacade val = new();
            err = values.GetAt(i, ref val.Key, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));

            switch (val.VariantType)
            {
            case PropVariantType.VT_CLSID:
                // TODO
                Debug.WriteLine($"## {val.KeyName} = {val.ToDebugString()}"); // FindGuidField(val.ToGuid())?.Name ?? val.ToString()}");
                break;
            default:
                Debug.WriteLine($"## {val.KeyName} = {val.ToDebugString()}");
                break;
            }
        }
        Debug.WriteLine(line);
    }

    #endregion

    #region IPortableDeviceProperties

    [Conditional("DEBUG")]
    public static void WriteSupportedProperties(
        IPortableDeviceProperties deviceProperties,
        string objectId,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        Debug.WriteLine(line);
        Debug.WriteLine($"## SupportedProperties for {objectId} at {filePath} ({lineNumber}) {memberName}");

        int err = deviceProperties.GetSupportedProperties(objectId, out IPortableDeviceKeyCollection collection);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetSupportedProperties), objectId, lineNumber, filePath, memberName);
        
        uint num = 0;
        collection.GetCount(ref num);
        for (uint index = 0; index < num; index++)
        {
            PropertyKey key = new();
            collection.GetAt(index, ref key);

            PropertyKeys propertyKey = key.FindPropertyKeysEnum();

            Debug.WriteLine($"## {propertyKey}");
        }
        Debug.WriteLine(line);

    }

    [Conditional("DEBUG")]
    public static void WriteValues(
        IPortableDeviceProperties deviceProperties,
        string objectId,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        Debug.WriteLine(line);
        Debug.WriteLine($"## Values for {objectId} at {filePath} ({lineNumber}) {memberName}");

        int err = deviceProperties.GetValues(objectId, null, out IPortableDeviceValues values);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceProperties), nameof(IPortableDeviceProperties.GetValues), objectId, lineNumber, filePath, memberName);

        uint num = 0;
        err = values.GetCount(ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));

        for (uint i = 0; i < num; i++)
        {
            PropVariantFacade val = new();
            err = values.GetAt(i, ref val.Key, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));

            switch (val.VariantType)
            {
            case PropVariantType.VT_CLSID:
                // TODO
                Debug.WriteLine($"## {val.KeyName} = {val.ToDebugString()}"); // FindGuidField(val.ToGuid())?.Name ?? val.ToString()}");
                break;
            default:
                Debug.WriteLine($"## {val.KeyName} = {val.ToDebugString()}");
                break;
            }
        }
        Debug.WriteLine(line);

    }




    //[Conditional("DEBUG")]
    //public static void WriteValues(
    //    IPortableDeviceProperties deviceProperties, 
    //    string objectId,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //=> MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(deviceProperties, objectId, lineNumber, filePath, memberName), lineNumber, filePath, memberName);

    //[Conditional("DEBUG")]
    //public static void WriteObjectIntern(
    //    IPortableDeviceProperties deviceProperties,
    //    string objectId,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

    //    string caller = $"{filePath} ({lineNumber}) {memberName}";
    //    Debug.WriteLine($"############################### {caller}");

    //    deviceProperties.GetSupportedProperties(objectId, out IPortableDeviceKeyCollection keys);

    //    deviceProperties.GetValues(objectId, keys, out IPortableDeviceValues values);
    //}

    #endregion

    #region IPortableDevicePropVariantCollection

    //[Conditional("DEBUG")]
    //public static void WriteValues(
    //    IPortableDevicePropVariantCollection collection,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //=> MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(collection, lineNumber, filePath, memberName), lineNumber, filePath, memberName);


    //[Conditional("DEBUG")]
    //public static void WriteObjectIntern(
    //    IPortableDevicePropVariantCollection collection,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

    //    string caller = $"{filePath} ({lineNumber}) {memberName}";
    //    Debug.WriteLine($"############################### {caller}");
    //    uint num = 0;
    //    collection.GetCount(ref num);
    //    for (uint index = 0; index < num; index++)
    //    {
    //        using PropVariantFacade val = new();
    //        collection.GetAt(index, ref val.Value);

    //        Debug.WriteLine($"##### {val.ToDebugString()}");

    //    }
    //}

    #endregion

    #region IPortableDeviceKeyCollection

    //[Conditional("DEBUG")]
    //public static void WriteValues(
    //    IPortableDeviceKeyCollection collection,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //=> MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(collection, lineNumber, filePath, memberName), lineNumber, filePath, memberName);

    //[Conditional("DEBUG")]
    //public static void WriteObjectIntern(
    //    IPortableDeviceKeyCollection collection,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerFilePath] string filePath = "",
    //    [CallerMemberName] string memberName = "")
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

    //    Debug.WriteLine("###############################");
    //    uint num = 0;
    //    collection.GetCount(ref num);
    //    for (uint index = 0; index < num; index++)
    //    {
    //        PropertyKey key = new();
    //        collection.GetAt(index, ref key);

    //        //PropertyKeys? propertyKey = key.GetEnumFromAttrKey<PropertyKeys>();

    //        PropertyKeys propertyKey = key.FindPropertyKeysEnum();

    //        Debug.WriteLine($"##### {propertyKey}");
    //    }
    //}

    #endregion

    //[Conditional("COMTRACE")]
    //public static void WriteValues(IPortableDeviceProperties deviceProperties, string objectId, [CallerMemberName] string? caller = null)
    //{
    //    deviceProperties.GetSupportedProperties(objectId, out IPortableDeviceKeyCollection keys);

    //    deviceProperties.GetValues(objectId, keys, out IPortableDeviceValues values);

    //    InternalWriteObject(values, caller);
    //}



    //[Conditional("COMTRACE")]




    //[Conditional("COMTRACE")]
    //public static void WriteError(int error, string interf, string function)
    //{
    //    string errorMessage = Marshal.GetExceptionForHR(error)?.Message ?? "unknown error";  //new Win32Exception(error).Message;
    //    Debug.WriteLine($"COM Error in {interf}.{function}: {errorMessage}");
    //}
}
