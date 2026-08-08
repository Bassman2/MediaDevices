using System.Net;

namespace MediaDevices;


// C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\propkey.h

/// <summary>
/// MediaDevice service class
/// </summary>
public class MediaDeviceService : IDisposable
{
    internal MediaDevice? device;
    internal IPortableDeviceService? service;
    //protected IPortableDeviceValues values;
    internal IPortableDeviceServiceCapabilities? capabilities;
    internal IPortableDeviceContent2? content;

    private MediaDeviceService()
    { }

    internal MediaDeviceService(MediaDevice device, string serviceId)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.device = device;
        this.ServiceId = serviceId;

        //Match match = Regex.Match(serviceId, @".*#(?<service>\{.*\})\\(?<name>\{.*\})");
        //if (match.Success)
        //{
        //    string service = match.Groups["service"].Value;
        //    Guid serviceGuid = new Guid(service);
        //    this.Service = serviceGuid.GetEnum<Services>();
        //    string serviceName = match.Groups["name"].Value;
        //    this.ServiceName = $"{this.Service} : {service} : {serviceName}";
        //}
        //else
        //{
        //    this.ServiceName = "Unknown";
        //}
        //this.ServiceName = serviceId.Substring(serviceId.LastIndexOf(@"\") + 1);

        //service = ComHelper.CreateInstance<IPortableDeviceService>(ref CLSID.PortableDeviceService);

        service = ComHelper.CreateInstance<IPortableDeviceService>();
        

        //IPortableDeviceValues values = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        IPortableDeviceValues values = ComHelper.CreateInstance<IPortableDeviceValues>();

        //err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var values);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));


        this.service.Open(this.ServiceId, values);

        this.service.GetServiceObjectID(out string serviceObjectID);
        this.ServiceObjectID = serviceObjectID;

        this.service.GetPnPServiceID(out string pnPServiceID);
        this.PnPServiceID = pnPServiceID;

        this.service.Capabilities(out capabilities);

        this.service.Content(out content);

        content.Properties(out IPortableDeviceProperties properties);

        properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

        properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

        ComTrace.WriteObject(deviceValues);

        using (var value = new PropVariantFacade())
        {
            deviceValues.GetValue(ref WPD.OBJECT_NAME, out value.Value);
            this.Name = value;
        }

        using (var value = new PropVariantFacade())
        {
            deviceValues.GetValue(ref WPD.FUNCTIONAL_OBJECT_CATEGORY, out value.Value);
            
            var serviceGuid = new Guid((string)value);
            //this.Service = serviceGuid.GetEnum<MediaDeviceServices>();
            this.Service = serviceGuid.FindMediaDeviceServicesEnum();
            this.ServiceName = this.Service != MediaDeviceServices.Unknown ? this.Service.ToString() : serviceGuid.ToString();
        }

        using (var value = new PropVariantFacade())
        {
            deviceValues.GetValue(ref WPD.SERVICE_VERSION, out value.Value);
            this.ServiceVersion = value;
        }

        Update();

        //var x = GetContent().ToArray();

        
    }

    /// <summary>
    /// Dispose service
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose service
    /// </summary>
    /// <param name="disposing">Disposing flag</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            device?.mainWorker.Invoke(() =>
            {
                if (this.service != null)
                {
                    int err = this.service.Close();
                    MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceService), nameof(IPortableDeviceService.Close));
                }
            });
        }
    }

    /// <summary>
    /// ID of the service
    /// </summary>
    public string? ServiceId { get; private set; }

    /// <summary>
    /// Get services
    /// </summary>
    public MediaDeviceServices Service { get; private set; }

    /// <summary>
    /// Name of the service
    /// </summary>
    public string? Name { get; private set; }

    /// <summary>
    /// Servicename
    /// </summary>
    public string? ServiceName { get; private set; }

    /// <summary>
    /// Version of the service
    /// </summary>
    public string? ServiceVersion { get; private set; }

    /// <summary>
    /// OhjectID of the service
    /// </summary>
    public string? ServiceObjectID { get; private set; }

    /// <summary>
    /// PnP service ID
    /// </summary>
    public string? PnPServiceID { get; private set; }

    /// <summary>
    /// Info of the service
    /// </summary>
    /// <returns>String with the info</returns>
    public override string ToString()
    {
        return $"{this.Name} : {this.ServiceName} : {this.ServiceVersion}";
    }

    /// <summary>
    /// Get content of the service
    /// </summary>
    /// <returns>List of content services</returns>
    public IEnumerable<MediaDeviceServiceContent> GetContent()
    {
        return GetContent("DEVICE");
    }

    internal IEnumerable<MediaDeviceServiceContent> GetContent(string objectID)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.content!.EnumObjects(0, objectID, null, out IEnumPortableDeviceObjectIDs enumerator);

        uint num = 0;
        string[] objectIdArray = new string[20];
        enumerator.Next(20, objectIdArray, ref num);

        return objectIdArray.Take((int)num).Select(o => new MediaDeviceServiceContent(this, o));
    }

    internal IEnumerable<KeyValuePair<string, string>> GetAllProperties(string objectID)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.content!.Properties(out IPortableDeviceProperties properties);

        properties.GetSupportedProperties(objectID, out IPortableDeviceKeyCollection keyCol);

        properties.GetValues(objectID, keyCol, out IPortableDeviceValues deviceValues);

        return deviceValues.ToKeyValuePair();
    }
           
    internal IPortableDeviceValues GetProperties(IPortableDeviceKeyCollection keyCol)
    {
        ThreadSafeWorkerException.ThrowIfNotInside();

        this.content!.Properties(out IPortableDeviceProperties properties);

        properties.GetValues(this.ServiceObjectID!, keyCol, out IPortableDeviceValues deviceValues);

        return deviceValues;
    }
    
    /// <summary>
    /// Update service
    /// </summary>
    protected virtual void Update()
    { 
        ThreadSafeWorkerException.ThrowIfNotInside();
    
        this.content!.Properties(out IPortableDeviceProperties properties);

        properties.GetSupportedProperties(this.ServiceObjectID!, out IPortableDeviceKeyCollection keyCol);

        properties.GetValues(this.ServiceObjectID!, keyCol, out IPortableDeviceValues deviceValues);

        ComTrace.WriteObject(deviceValues);
    }

    /// <summary>
    /// Get all properties
    /// </summary>
    /// <returns>List of properties</returns>
    public IEnumerable<KeyValuePair<string,string>> GetAllProperties()
    {
        return GetAllProperties(this.ServiceObjectID!);
    }

    /// <summary>
    /// Get supported methods
    /// </summary>
    /// <returns>List of supported methods</returns>
    public IEnumerable<Methods> GetSupportedMethods()
    {
        return device!.mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedMethods(capabilities!));
    }

    /// <summary>
    /// Get supported commands
    /// </summary>
    /// <returns>List of supported commands</returns>
    public IEnumerable<Commands> GetSupportedCommands()
    {
        return device!.mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedCommands(capabilities!));
    }

    /// <summary>
    /// Get supported events
    /// </summary>
    /// <returns>list of supported events</returns>
    public IEnumerable<Events> GetSupportedEvents()
    {
        return device!.mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedEvents(capabilities!));
    }

    /// <summary>
    /// Get supported formats
    /// </summary>
    /// <returns>List of supported formats</returns>
    public IEnumerable<Formats> GetSupportedFormats()
    {
        return device!.mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedFormats(capabilities!));
    }
   
    /// <summary>
    /// Call a service method
    /// </summary>
    /// <param name="method">Method GUID</param>
    /// <param name="parameters">Method parameters</param>
    public void CallMethod(Guid method, object[] _)
    {
        // TODO check?
        this.service!.Methods(out IPortableDeviceServiceMethods methods);

        //IPortableDeviceValues values = 
        //    ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);

        var values = ComHelper.CreateInstance<IPortableDeviceValues>();

        //int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var values);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        //(IPortableDeviceValues)new PortableDeviceValues();
        //values.SetStringValue();
        //IPortableDeviceValues results = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);
        //(IPortableDeviceValues)new PortableDeviceValues();

        //err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var results);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        var results = ComHelper.CreateInstance<IPortableDeviceValues>();

        methods.Invoke(ref method, ref values, ref results);
    }

    internal void SendCommand(PropertyKey commandKey)
    {
        ////IPortableDeviceValues values = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues);
        //int err = ComHelper.CreateInstance<IPortableDeviceValues>(ref CLSID.PortableDeviceValues, out var values);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceValues));

        IPortableDeviceValues values = ComHelper.CreateInstance<IPortableDeviceValues>();


        values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
        values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);

        this.service!.SendCommand(0, ref values, out IPortableDeviceValues _);
    }
}
