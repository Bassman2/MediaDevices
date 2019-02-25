using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{

    // C:\Program Files (x86)\Windows Kits\10\Include\10.0.17763.0\um\propkey.h

    public class MediaDeviceService
    {
        protected MediaDevice device;
        private IPortableDeviceService service = (IPortableDeviceService)new PortableDeviceService();
        //protected IPortableDeviceValues values;

        private MediaDeviceService()
        { }

        internal MediaDeviceService(MediaDevice device, string serviceId)
        {
            this.device = device;
            this.ServiceId = serviceId;
            this.ServiceName = serviceId.Substring(serviceId.LastIndexOf(@"\") + 1);
        }

        public string ServiceId { get; private set; }

        public string ServiceName { get; private set; }

        public string ServiceObjectID { get; private set; }

        public string PnPServiceID { get; private set; }

        public void Open()
        {
            IPortableDeviceValues values = (IPortableDeviceValues)new PortableDeviceValues();
            this.service.Open(this.ServiceId, values);

            this.service.GetServiceObjectID(out string serviceObjectID);
            this.ServiceObjectID = serviceObjectID;

            this.service.GetPnPServiceID(out string pnPServiceID);
            this.PnPServiceID = pnPServiceID;

            Update();
        }

        internal IPortableDeviceValues GetProperties(IPortableDeviceKeyCollection keyCol)
        {
            this.service.Content(out IPortableDeviceContent2 content);
            content.Properties(out IPortableDeviceProperties properties);

            properties.GetValues(this.ServiceObjectID, keyCol, out IPortableDeviceValues deviceValues);

            return deviceValues;
        }

            
        protected virtual void Update()
        { }

        public void Close()
        {
            this.service.Close();
        }

        public void Capabilities()
        {
            this.service.Capabilities(out IPortableDeviceServiceCapabilities capabilities);

            capabilities.GetSupportedMethods(out IPortableDevicePropVariantCollection methods);
            ComTrace.WriteObject(methods);

            capabilities.GetSupportedCommands(out IPortableDeviceKeyCollection commands);
            ComTrace.WriteObject(commands);

            capabilities.GetSupportedEvents(out IPortableDevicePropVariantCollection events);
            ComTrace.WriteObject(events);

            capabilities.GetSupportedFormats(out IPortableDevicePropVariantCollection formats);
            ComTrace.WriteObject(formats);

            //capabilities.GetInheritedServices(out IPortableDevicePropVariantCollection inhiritedServices);
            //ComTrace.WriteObject(inhiritedServices);
        }

        public void Content()
        {
            this.service.Content(out IPortableDeviceContent2 content);

            //content.Properties(out IPortableDeviceProperties properties);

            //ComTrace.WriteObject(properties);

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
