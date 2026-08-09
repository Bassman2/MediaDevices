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
        this IPortableDevicePropVariantCollection _,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        //ThreadSafeWorkerException.ThrowIfNotInside(lineNumber, filePath, memberName);
        //int err = NativeMethods.PropVariantClear(ref propVariantCollection);
        //if (err < 0)
        //{
        //    string errorMessage = Marshal.GetExceptionForHR(err)?.Message ?? "unknown error";
        //    string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
        //    string message = $"COM Error 0x{err:x8} in PropVariantClear {errorMessage} at {errorPosition}";
        //    Debug.WriteLine(message);
        //    throw new MediaDeviceException(message);
        //}
    }


    public static void Release(
         this IPortableDeviceValues _,
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

    #region IPortableDeviceValues

    public static int GetStringArrayValue(this IPortableDeviceValues values, ref PropertyKey key, out string[] value)
    {
        value = [];
        int err = values.GetIPortableDevicePropVariantCollectionValue(ref key, out var propVariantCollection);
        if (err != 0) return err;

        uint count = 0;
        err = propVariantCollection.GetCount(ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDevicePropVariantCollection), nameof(IPortableDevicePropVariantCollection.GetCount));

        if (count <= 0)
        {
            List<string> list = [];
            for (uint i = 0; i < count; i++)
            {
                using PropVariantFacade val = new();
                propVariantCollection.GetAt(i, ref val.Value);
                list.Add(val);
            }
            value = [.. list];

        }
        propVariantCollection.Release();
        return 0;
    }
    #endregion
}
