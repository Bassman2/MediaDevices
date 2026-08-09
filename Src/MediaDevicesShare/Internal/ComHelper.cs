using System.Reflection;

namespace MediaDevices.Internal;

internal static partial class ComHelper
{
    private const int CLSCTX_ALL = 23;


    public static T CreateInstance<T>(
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "") 
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        string guid = typeof(T).GetCustomAttribute<CLSIDAttribute>()?.Value ?? throw new InvalidOperationException($"Type {typeof(T).Name} must have a CLSIDAttribute");

        Guid clsid = Guid.Parse(guid);

        int err = NativeMethods.CoCreateInstance(clsid, 0, CLSCTX_ALL, typeof(T).GUID, out var insta);
        if (err < 0)
        {
            string errorMessage = Marshal.GetExceptionForHR(err)?.Message ?? "unknown error";
            string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
            string message = $"COM Error 0x{err:x8} {errorMessage} in CoCreateInstance {typeof(T).Name} {errorPosition}";
            Debug.WriteLine(message);
            throw new MediaDeviceException(message);
        }
        return (T)insta;
    }

    //public static int CreateInstance<T>(ref Guid clsid, out T inst)
    //{
    //    ThreadSafeWorkerException.ThrowIfNotInside();

    //    int err = NativeMethods.CoCreateInstance(clsid, 0, CLSCTX_ALL, typeof(T).GUID, out var insta);
    //    inst = (T)insta;
    //    return err;
    //}

    public static void Release(
        this PropVariant propVariant,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);
        int err = NativeMethods.PropVariantClear(ref propVariant);
        if (err < 0)
        {
            string errorMessage = Marshal.GetExceptionForHR(err)?.Message ?? "unknown error";
            string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
            string message = $"COM Error 0x{err:x8} in PropVariantClear {errorMessage} at {errorPosition}";
            Debug.WriteLine(message);
            throw new MediaDeviceException(message);
        }
    }

    
        public static void Release(
        this IPortableDeviceValues deviceValues,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);
        
        // TODO
        ////Marshal.GetObjectForIUnknown(deviceValues);
        //object obj = deviceValues;
        ////int err = Marshal.ReleaseComObject(obj);
        //int err = Marshal.FinalReleaseComObject(obj);
        //if (err < 0)
        //{
        //    string errorMessage = Marshal.GetExceptionForHR(err)?.Message ?? "unknown error";
        //    string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
        //    string message = $"COM Error 0x{err:x8} in ReleaseComObject {errorMessage} at {errorPosition}";
        //    Debug.WriteLine(message);
        //    throw new MediaDeviceException(message);
        //}
    }

    private partial class NativeMethods
    {
        [PreserveSig, LibraryImport("ole32")]
        public static partial int CoCreateInstance(in Guid rclsid, nint pUnkOuter, int dwClsContext, in Guid riid, [MarshalUsing(typeof(UniqueComInterfaceMarshaller<object>))] out object ppv);

        [PreserveSig, LibraryImport("ole32.dll")]
        public static partial int PropVariantClear(ref PropVariant val);
    }
       


    public static bool HasKeyValue(this IPortableDeviceValues values, PropertyKey findKey)
    {
        uint num = 0;
        values.GetCount(ref num);
        for (uint i = 0; i < num; i++)
        {
            using PropVariantFacade val = new();
            values.GetAt(i, ref val.Key, ref val.Value);
            if (val.Key == findKey)
            {
                return val.VariantType != PropVariantType.VT_ERROR;
            }

        }
        
        return false;
    }

    //public static PropVariantType GetVarType(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    using PropVariantFacade val = new();
    //    values.GetValue(ref key, out val.Value);
    //    return val.VariantType;
    //}

    //internal static bool TryGetValue(this IPortableDeviceValues values, PropertyKey key, out PropVariantFacade? value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        PropVariantFacade val = new();
    //        values.GetValue(ref key, out val.Value);
    //        value = val;
    //        return true;
    //    }
    //    value = null;
    //    return false;
    //}
    //public static DateTime? GetDateTimeValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        using PropVariantFacade val = new();
    //        values.GetValue(ref key, out val.Value);
    //        return val.ToDate();
    //    }
    //    return null;
    //}

    //public static bool TryGetDateTimeValue(this IPortableDeviceValues values, PropertyKey key, out DateTime? value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        using PropVariantFacade val = new();
    //        values.GetValue(ref key, out val.Value);
    //        value = val.ToDate();
    //        return true;
    //    }
    //    value = null;
    //    return false;
    //}

    public static string? GetStringValue(this IPortableDeviceValues values, PropertyKey key)
    {
        if (values.HasKeyValue(key))
        {
            values.GetStringValue(ref key, out string value);
            return value;
        }
        return null;
    }

    public static bool TryGetStringValue(this IPortableDeviceValues values, PropertyKey key, out string value)
    {
        if (values.HasKeyValue(key))
        {
            values.GetStringValue(ref key, out value);
            return true;
        }
        value = string.Empty;
        return false;            
    }

    //public static bool TryGetGuidValue(this IPortableDeviceValues values, PropertyKey key, out Guid value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetGuidValue(ref key, out value);
    //        return true;
    //    }
    //    value = Guid.Empty;
    //    return false;
    //}

    //public static bool? GetBoolValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetBoolValue(ref key, out int val);
    //        return val != 0;
    //    }
    //    return null;
    //}
    //public static bool TryGetBoolValue(this IPortableDeviceValues values, PropertyKey key, out bool value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetBoolValue(ref key, out int val);
    //        value = val != 0;
    //        return true;
    //    }
    //    value = false;
    //    return false;
    //}

    //public static uint? GetUnsignedIntegerValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetUnsignedIntegerValue(ref key, out uint value);
    //        return value;
    //    }
    //    return null;
    //}

    //public static bool TryGetUnsignedIntegerValue(this IPortableDeviceValues values, PropertyKey key, out uint value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetUnsignedIntegerValue(ref key, out value);
    //        return true;
    //    }
    //    value = 0;
    //    return false;
    //}

    //public static ulong? GetUnsignedLargeIntegerValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetUnsignedLargeIntegerValue(ref key, out ulong value);
    //        return value;
    //    }
    //    return null;
    //}

    //public static bool TryGetUnsignedLargeIntegerValue(this IPortableDeviceValues values, PropertyKey key, out ulong value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetUnsignedLargeIntegerValue(ref key, out value);
    //        return true;
    //    }
    //    value = 0;
    //    return false;
    //}

    //public static int? GetSignedIntegerValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetSignedIntegerValue(ref key, out int value);
    //        return value;
    //    }
    //    return null;
    //}

    //public static bool TryGetSignedIntegerValue(this IPortableDeviceValues values, PropertyKey key, out int value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetSignedIntegerValue(ref key, out value);
    //        return true;
    //    }
    //    value = 0;
    //    return false;
    //}

    //public static bool TryGetIUnknownValue(this IPortableDeviceValues values, PropertyKey key, out object value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        values.GetIUnknownValue(ref key, out value);
    //        return true;
    //    }
    //    value = null;
    //    return false;
    //}

    //public static byte[]? GetByteArrayValue(this IPortableDeviceValues values, PropertyKey key)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        using PropVariantFacade val = new();
    //        values.GetValue(ref key, out val.Value);
    //        return val.ToByteArray();
    //    }
    //    return null;
    //}

    //public static bool TryByteArrayValue(this IPortableDeviceValues values, PropertyKey key, out byte[]? value)
    //{
    //    if (values.HasKeyValue(key))
    //    {
    //        using PropVariantFacade val = new();
    //        values.GetValue(ref key, out val.Value);
    //        value = val.ToByteArray();
    //        return true;
    //    }
    //    value = null;
    //    return false;
    //}

    //private static class NativeMethods
    //{
    //    // http://www.pinvoke.net/default.aspx/iprop/PropVariantClear.html
    //    // https://social.msdn.microsoft.com/Forums/windowsserver/en-US/ec242718-8738-4468-ae9d-9734113d2dea/quotipropdllquot-seems-to-be-missing-in-windows-server-2008-and-x64-systems?forum=winserver2008appcompatabilityandcertification
    //    [DllImport("ole32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    //    static extern public int PropVariantClear(ref PropVariant val);
    //}



    //private static readonly Guid CLSID_PortableDeviceFTM = new("9B174B33-40FF-11D2-A27E-00C04FC30871");
    //public static int Test(Guid guid)
    //{ 
    //    return guid switch
    //    {
    //        CLSID_PortableDeviceFTM => 1,
    //        _ => 0
    //    };  

    //}

    public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePair(this IPortableDeviceValues values)
    {
        uint num = 0;
        int err = values.GetCount(ref num);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetCount));
        for (uint i = 0; i < num; i++)
        {
            //var key = new PropertyKey();
            using var val = new PropVariantFacade();

            err = values.GetAt(i, ref val.Key, ref val.Value);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues), nameof(IPortableDeviceValues.GetAt));

            //string fieldName = string.Empty;
            //FieldInfo? propField = ComTrace.FindPropertyKeyField(key);
            //if (propField != null)
            //{
            //    fieldName = propField.Name;
            //}
            //else
            //{
            //    FieldInfo? guidField = ComTrace.FindGuidField(key.fmtid);
            //    fieldName = guidField != null ? $"{guidField.Name}, {key.pid}" : $"{key.fmtid}, {key.pid}";
            //}
            string fieldValue = val.VariantType switch
            {
                //PropVariantType.VT_CLSID => ComTrace.FindGuidField(val!.ToGuid()!)?.Name ?? val.ToString(),
                _ => val.ToDebugString(),
            };
            yield return new KeyValuePair<string, string>(val.KeyName, fieldValue);
        }
    }
}
