namespace MediaDevices.Internal;

internal static class ComEnumerable
{
    public static IEnumerable<KeyValuePair<string, string>> ToKeyValuePair(this IPortableDeviceValues values)
    {
        uint num = 0;
        values?.GetCount(ref num);
        for (uint i = 0; i < num; i++)
        {
            var key = new PropertyKey();
            using (var val = new PropVariantFacade()) 
            {
                values?.GetAt(i, ref key, ref val.Value);


                string fieldName = string.Empty;
                FieldInfo? propField = ComTrace.FindPropertyKeyField(key);
                if (propField != null)
                {
                    fieldName = propField.Name;
                }
                else
                {
                    FieldInfo? guidField = ComTrace.FindGuidField(key.fmtid);
                    if (guidField != null)
                    {
                        fieldName = $"{guidField.Name}, {key.pid}";
                    }
                    else
                    {
                        fieldName = $"{key.fmtid}, {key.pid}";
                    }
                }
                string fieldValue = string.Empty;
                switch (val.VariantType)
                {
                    case PropVariantType.VT_CLSID:
                        fieldValue = ComTrace.FindGuidField(val.ToGuid())?.Name ?? val.ToString();
                        break;
                    default:
                        fieldValue = val.ToDebugString();
                        break;
                }

                yield return new KeyValuePair<string, string>(fieldName, fieldValue);
            }
        }

    }

    public static Guid Guid(this Enum e)
    {
        FieldInfo? fi = e.GetType().GetField(e.ToString());

        EnumGuidAttribute attribute = fi?.GetCustomAttribute<EnumGuidAttribute>()!;
        return attribute!.Guid;
    }

    //public static IEnumerable<PropertyKey> ToEnum(this IPortableDeviceKeyCollection col) 
    //{
    //    uint count = 0;
    //    col.GetCount(ref count);
    //    for (uint i = 0; i < count; i++)
    //    {
    //        PropertyKey key = new PropertyKey();
    //        col.GetAt(i, ref key);
    //        yield return key;
    //    }
    //}

    //public static IEnumerable<TEnum> ToEnum<TEnum>(this IPortableDeviceKeyCollection col) where TEnum : struct // enum
    //{
    //    uint count = 0;
    //    col.GetCount(ref count);
    //    for (uint i = 0; i < count; i++)
    //    {
    //        PropertyKey key = new PropertyKey();
    //        col.GetAt(i, ref key);
    //        yield return GetEnumFromAttrKey<TEnum>(key);
    //    }
    //}

    public static IEnumerable<Commands> ToCommands(this IPortableDeviceKeyCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            var key = new PropertyKey();
            col.GetAt(i, ref key);
            yield return GetCommand(key);
        }
    }

    public static IEnumerable<Events> ToEvents(this IPortableDevicePropVariantCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using (var val = new PropVariantFacade())
            {
                col.GetAt(i, ref val.Value);
                yield return GetEvent(val.ToGuid());
            }
        }
    }

    public static IEnumerable<FunctionalCategory> ToFunctionalCategories(this IPortableDevicePropVariantCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using (var val = new PropVariantFacade())
            {
                col.GetAt(i, ref val.Value);
                yield return GetFunctionalCategory(val.ToGuid());
            }
        }
    }

    public static IEnumerable<ContentType> ToContentTypes(this IPortableDevicePropVariantCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using (var val = new PropVariantFacade())
            {
                col.GetAt(i, ref val.Value);
                yield return GetContentType(val.ToGuid());
            }
        }
    }

    public static IEnumerable<Methods> ToMethods(this IPortableDevicePropVariantCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using (var val = new PropVariantFacade())
            {
                col.GetAt(i, ref val.Value);
                yield return GetMethod(val.ToGuid());
            }
        }
    }

    public static IEnumerable<Formats> ToFormats(this IPortableDevicePropVariantCollection col)
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using (var val = new PropVariantFacade())
            {
                col.GetAt(i, ref val.Value);
                yield return GetFormat(val.ToGuid());
            }
        }
    }

    //public static T GetEnum<T>(this Guid guid) where T : struct
    //{
    //    T en = Enum.GetValues(typeof(T)).Cast<T>().Where(e =>
    //    {
    //        // changed for .net framework 4.0
    //        // EnumGuidAttribute ea = e.GetType().GetField(e.ToString()).GetCustomAttribute<EnumGuidAttribute>();
    //        EnumGuidAttribute ea = Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString()), typeof(EnumGuidAttribute)) as EnumGuidAttribute;
    //        return ea.Guid == guid;
    //    }).FirstOrDefault();
    //    return en;
    //}

    public static MediaDeviceServices GetMediaDeviceServices(this Guid guid) 
    {
        MediaDeviceServices en = Enum.GetValues<MediaDeviceServices>().Where(e =>
        {
            EnumGuidAttribute ea = e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!;
            return ea.Guid == guid;
        }).FirstOrDefault();
        return en;
    }


    //public static T GetEnumFromAttrKey<T>(this PropertyKey key) where T : struct // enum
    //{
    //    T en = Enum.GetValuesAsUnderlyingType(typeof(T)).Cast<T>().Where(e =>
    //    {
    //        // changed for .net framework 4.0
    //        KeyAttribute attr = e.GetType().GetField(e.ToString()).GetCustomAttribute<KeyAttribute>();
    //        //KeyAttribute attr = Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString()), typeof(KeyAttribute)) as KeyAttribute;
    //        return attr.PropertyKey == key;
    //    }).FirstOrDefault();
    //    if (en.Equals(default(T)))
    //    {
    //        Trace.TraceWarning($"Unknown {typeof(T).Name} Key {key.fmtid}  {key.pid}");
    //    }
    //    return en;
    //}

    public static Commands GetCommand(this PropertyKey key) 
    {

        Commands en = Enum.GetValues<Commands>().Where(e =>
        {
            
            //KeyAttribute attr = e.GetType().GetField(e.ToString()).GetCustomAttribute<KeyAttribute>();
            KeyAttribute attr = (KeyAttribute)Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString())!, typeof(KeyAttribute))!;
            return attr.PropertyKey == key;
        }).FirstOrDefault();
        if (en.Equals(default(Commands)))
        {
            Trace.TraceWarning($"Unknown {typeof(Commands).Name} Key {key.fmtid}  {key.pid}");
        }
        return en;
    }

    public static PropertyKeys GetPropertyKey(this PropertyKey key) 
    {

        PropertyKeys en = Enum.GetValues<PropertyKeys>().Where(e =>
        {
            KeyAttribute attr = e.GetType().GetField(e.ToString())!.GetCustomAttribute<KeyAttribute>()!;
            return attr.PropertyKey == key;
        }).FirstOrDefault();
        if (en.Equals(default(PropertyKeys)))
        {
            Trace.TraceWarning($"Unknown {typeof(PropertyKeys).Name} Key {key.fmtid}  {key.pid}");
        }
        return en;
    }

    //public static T GetEnumFromAttrGuid<T>(this Guid guid) where T : struct // enum
    //{
    //    T en = Enum.GetValues<T>().Where(e =>
    //    {
    //        // changed for .net framework 4.0
    //        return e.GetType().GetField(e.ToString()).GetCustomAttribute<EnumGuidAttribute>().Guid == guid;
    //        //return (Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString()), typeof(EnumGuidAttribute)) as EnumGuidAttribute).Guid == guid;
    //    }).FirstOrDefault();
    //    if (en.Equals(default(T)))
    //    {
    //        Trace.TraceWarning($"Unknown {typeof(T).Name} Guid {guid}");
    //    }
    //    return en;
    //}

    public static Events GetEvent(this Guid guid) 
    {
        Events en = Enum.GetValues<Events>().Where(e =>
        {
            return e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!.Guid == guid;
        }).FirstOrDefault();
        if (en.Equals(default(Events)))
        {
            Trace.TraceWarning($"Unknown Events Guid {guid}");
        }
        return en;
    }

    public static FunctionalCategory GetFunctionalCategory(this Guid guid) 
    {
#if !NET
        FunctionalCategory en = Enum.GetValues(typeof(FunctionalCategory)).Cast<FunctionalCategory>().Where(e =>
#else
        FunctionalCategory en = Enum.GetValues<FunctionalCategory>().Where(e =>
#endif
        {
            return e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!.Guid == guid;
        }).FirstOrDefault();
        if (en.Equals(default(FunctionalCategory)))
        {
            Trace.TraceWarning($"Unknown FunctionalCategory Guid {guid}");
        }
        return en;
    }

    public static ContentType GetContentType(this Guid guid)
    {

        ContentType en = Enum.GetValues<ContentType>().Where(e =>
        {
            // changed for .net framework 4.0
            return e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!.Guid == guid;
            //return (Attribute.GetCustomAttribute(e.GetType().GetField(e.ToString()), typeof(EnumGuidAttribute)) as EnumGuidAttribute).Guid == guid;
        }).FirstOrDefault();
        if (en.Equals(default(ContentType)))
        {
            Trace.TraceWarning($"Unknown ContentType Guid {guid}");
        }
        return en;
    }

    public static Methods GetMethod(this Guid guid) 
    {

        Methods en = Enum.GetValues<Methods>().Where(e =>
        {
            return e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!.Guid == guid;
        }).FirstOrDefault();
        if (en.Equals(default(Methods)))
        {
            Trace.TraceWarning($"Unknown Methods Guid {guid}");
        }
        return en;
    }

    public static Formats GetFormat(this Guid guid) 
    {

        Formats en = Enum.GetValues<Formats>().Where(e =>
        {
            return e.GetType().GetField(e.ToString())!.GetCustomAttribute<EnumGuidAttribute>()!.Guid == guid;
        }).FirstOrDefault();
        if (en.Equals(default(Formats)))
        {
            Trace.TraceWarning($"Unknown Formats Guid {guid}");
        }
        return en;
    }

    public static IEnumerable<Guid> ToGuid(this IPortableDevicePropVariantCollection col) 
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using var val = new PropVariantFacade();
            col.GetAt(i, ref val.Value);
            yield return val.ToGuid();
        }
    }

    public static IEnumerable<string> ToStrings(this IPortableDevicePropVariantCollection col)
    {
        uint count = 0;
        col.GetCount(ref count);
        for (uint i = 0; i < count; i++)
        {
            using var val = new PropVariantFacade();
            col.GetAt(i, ref val.Value);
            yield return val.ToString();
        }
    }
}
