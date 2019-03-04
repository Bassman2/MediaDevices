using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaDevices
{

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\propkey.h

    public class MediaDeviceService : IDisposable
    {
        protected MediaDevice device;
        private IPortableDeviceService service = (IPortableDeviceService)new PortableDeviceService();
        //protected IPortableDeviceValues values;
        internal IPortableDeviceServiceCapabilities capabilities;

        private MediaDeviceService()
        { }

        internal MediaDeviceService(MediaDevice device, string serviceId)
        {
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

            IPortableDeviceValues values = (IPortableDeviceValues)new PortableDeviceValues();
            this.service.Open(this.ServiceId, values);

            this.service.GetServiceObjectID(out string serviceObjectID);
            this.ServiceObjectID = serviceObjectID;

            this.service.GetPnPServiceID(out string pnPServiceID);
            this.PnPServiceID = pnPServiceID;

            this.service.Capabilities(out capabilities);

            this.service.Content(out IPortableDeviceContent2 content);
            content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            ComTrace.WriteObject(deviceValues);

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.OBJECT_NAME, out value.Value);
                this.Name = value;
            }

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.FUNCTIONAL_OBJECT_CATEGORY, out value.Value);
                
                Guid serviceGuid = new Guid((string)value);
                this.Service = serviceGuid.GetEnum<MediaDeviceServices>();
                this.ServiceName = this.Service != MediaDeviceServices.Unknown ? this.Service.ToString() : serviceGuid.ToString();
            }

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.SERVICE_VERSION, out value.Value);
                this.ServiceVersion = value;
            }
            //Update();

            //var x = GetContent().ToArray();

            
        }

        public void Dispose()
        {
            if (this.service != null)
            { 
                this.service.Close();
                this.service = null;
            }
        }

        public string ServiceId { get; private set; }

        public MediaDeviceServices Service { get; private set; }

        public string Name { get; private set; }

        public string ServiceName { get; private set; }

        public string ServiceVersion { get; private set; }

        public string ServiceObjectID { get; private set; }

        public string PnPServiceID { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} : {this.ServiceName} : {this.ServiceVersion}";
        }

        public IEnumerable<MediaDeviceServiceContent> GetContent()
        {
            this.service.Content(out IPortableDeviceContent2 content);

            return LoopContent(content, "DEVICE");
        }

        internal IEnumerable<MediaDeviceServiceContent> LoopContent(IPortableDeviceContent2 content, string objectID)
        {
            content.EnumObjects(0, objectID, null, out IEnumPortableDeviceObjectIDs enumerator);

            uint num = 0;
            string[] objectIdArray = new string[20];
            enumerator.Next(20, objectIdArray, ref num);

            return objectIdArray.Take((int)num).Select(o => new MediaDeviceServiceContent(this, content, o));
        }

        internal IPortableDeviceValues GetProperties(IPortableDeviceKeyCollection keyCol)
        {
            this.service.Content(out IPortableDeviceContent2 content);
            content.Properties(out IPortableDeviceProperties properties);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            return deviceValues;
        }

            
        protected virtual void Update()
        {
            this.service.Content(out IPortableDeviceContent2 content);
            content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            ComTrace.WriteObject(deviceValues);

        }

        public IEnumerable<KeyValuePair<string,string>> GetProperties()
        {
            this.service.Content(out IPortableDeviceContent2 content);
            content.Properties(out IPortableDeviceProperties properties);

            properties.GetSupportedProperties(this.ServiceObjectID, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            return deviceValues.ToKeyValuePair();
        }

        public IEnumerable<Methods> GetSupportedMethods()
        {
            capabilities.GetSupportedMethods(out IPortableDevicePropVariantCollection methods);
            ComTrace.WriteObject(methods);
            return methods.ToEnum<Methods>();
        }

        public IEnumerable<Commands> GetSupportedCommands()
        {
            capabilities.GetSupportedCommands(out IPortableDeviceKeyCollection commands);
            ComTrace.WriteObject(commands);
            return commands.ToEnum<Commands>();
        }

        public IEnumerable<Events> GetSupportedEvents()
        {
            capabilities.GetSupportedEvents(out IPortableDevicePropVariantCollection events);
            ComTrace.WriteObject(events);
            return events.ToEnum<Events>();
        }

        public IEnumerable<Formats> GetSupportedFormats()
        {
            capabilities.GetSupportedFormats(out IPortableDevicePropVariantCollection formats);
            ComTrace.WriteObject(formats);
            return formats.ToEnum<Formats>();
        }
       
        public void CallMethod(Guid method, object[] parameters)
        {
            this.service.Methods(out IPortableDeviceServiceMethods methods);

            IPortableDeviceValues values = (IPortableDeviceValues)new PortableDeviceValues();
            //values.SetStringValue();
            IPortableDeviceValues results = (IPortableDeviceValues)new PortableDeviceValues();
            methods.Invoke(ref method, ref values, ref results);
        }

        internal void SendCommand(PropertyKey commandKey)
        {
            IPortableDeviceValues values = (IPortableDeviceValues)new PortableDeviceValues();
            values.SetGuidValue(ref WPD.PROPERTY_COMMON_COMMAND_CATEGORY, ref commandKey.fmtid);
            values.SetUnsignedIntegerValue(ref WPD.PROPERTY_COMMON_COMMAND_ID, commandKey.pid);

            this.service.SendCommand(0, ref values, out IPortableDeviceValues results);
        }

        
    }
}
