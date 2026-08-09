namespace MediaDevices.Internal;

// to enable COM traces add "COMTRACE" to the Build Conditional compilation symbols of the MediaDevice project.

internal static class ComTrace
{
    #region IPortableDeviceValues

    [Conditional("DEBUG")]
    public static void WriteObject(
        IPortableDeviceValues values,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    => MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(values, lineNumber, filePath, memberName), lineNumber, filePath, memberName);
    
    [Conditional("DEBUG")]
    public static void WriteObjectIntern(
        IPortableDeviceValues values,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        string caller = $"{filePath} ({lineNumber}) {memberName}";
        Debug.WriteLine($"############################### {caller}");
        uint num = 0;

        int err = values.GetCount(ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));

        for (uint i = 0; i < num; i++)
        {
            //PropertyKey key = new();
            PropVariantFacade val = new();
            err = values.GetAt(i, ref val.Key, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));


            //string fieldName = val.Key.GetName();
            /*
            string fieldName = string.Empty;
            FieldInfo? propField = FindPropertyKeyField(key);
            if (propField != null)
            {
                fieldName = propField.Name;
            }
            else
            {
                FieldInfo? guidField = FindGuidField(key.fmtid);
                if (guidField != null)
                {
                    fieldName = $"{guidField.Name}, {key.pid}";
                }
                else
                {
                    fieldName = $"{key.fmtid}, {key.pid}";
                }
            }
            */
            switch (val.VariantType)
            {
            case PropVariantType.VT_CLSID:
                // TODO
                Debug.WriteLine($"##### {val.KeyName} = {val.ToDebugString()}"); // FindGuidField(val.ToGuid())?.Name ?? val.ToString()}");
                break;
            default:
                Debug.WriteLine($"##### {val.KeyName} = {val.ToDebugString()}");
                break;
            }
        }
    }

    #endregion

    #region IPortableDeviceProperties

    [Conditional("DEBUG")]
    public static void WriteObject(
        IPortableDeviceProperties deviceProperties, 
        string objectId,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    => MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(deviceProperties, objectId, lineNumber, filePath, memberName), lineNumber, filePath, memberName);

    [Conditional("DEBUG")]
    public static void WriteObjectIntern(
        IPortableDeviceProperties deviceProperties,
        string objectId,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        string caller = $"{filePath} ({lineNumber}) {memberName}";
        Debug.WriteLine($"############################### {caller}");

        deviceProperties.GetSupportedProperties(objectId, out IPortableDeviceKeyCollection keys);

        deviceProperties.GetValues(objectId, keys, out IPortableDeviceValues values);
    }

    #endregion

    #region IPortableDevicePropVariantCollection

    [Conditional("DEBUG")]
    public static void WriteObject(
        IPortableDevicePropVariantCollection collection,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    => MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(collection, lineNumber, filePath, memberName), lineNumber, filePath, memberName);


    [Conditional("DEBUG")]
    public static void WriteObjectIntern(
        IPortableDevicePropVariantCollection collection,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        string caller = $"{filePath} ({lineNumber}) {memberName}";
        Debug.WriteLine($"############################### {caller}");
        uint num = 0;
        collection.GetCount(ref num);
        for (uint index = 0; index < num; index++)
        {
            using PropVariantFacade val = new();
            collection.GetAt(index, ref val.Value);

            Debug.WriteLine($"##### {val.ToDebugString()}");

        }
    }

    #endregion 

    #region IPortableDeviceKeyCollection

    [Conditional("DEBUG")]
    public static void WriteObject(
        IPortableDeviceKeyCollection collection,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    => MediaDeviceManager.MainWorker.Invoke(() => WriteObjectIntern(collection, lineNumber, filePath, memberName), lineNumber, filePath, memberName);

    [Conditional("DEBUG")]
    public static void WriteObjectIntern(
        IPortableDeviceKeyCollection collection,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);

        Debug.WriteLine("###############################");
        uint num = 0;
        collection.GetCount(ref num);
        for (uint index = 0; index < num; index++)
        {
            PropertyKey key = new();
            collection.GetAt(index, ref key);

            //PropertyKeys? propertyKey = key.GetEnumFromAttrKey<PropertyKeys>();

            PropertyKeys propertyKey = key.FindPropertyKeysEnum();

            Debug.WriteLine($"##### {propertyKey}");
        }
    }

    #endregion

    //[Conditional("COMTRACE")]
    //public static void WriteObject(IPortableDeviceProperties deviceProperties, string objectId, [CallerMemberName] string? caller = null)
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
