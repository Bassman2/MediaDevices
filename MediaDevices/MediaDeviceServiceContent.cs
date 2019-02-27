using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    public class MediaDeviceServiceContent
    {
        private MediaDeviceService service;
        private IPortableDeviceContent2 content;

        private MediaDeviceServiceContent()
        { }

        internal MediaDeviceServiceContent(MediaDeviceService service, IPortableDeviceContent2 content, string objectId)
        {
            this.service = service;
            this.content = content;
            this.ObjectId = objectId;

            UpdateProperties();
        }

        internal virtual void UpdateProperties()
        {
            content.Properties(out IPortableDeviceProperties properties);

            //IPortableDeviceKeyCollection keyCol = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();

            properties.GetSupportedProperties(this.ObjectId, out IPortableDeviceKeyCollection keyCol);

            properties.GetValues(this.ObjectId, keyCol, out IPortableDeviceValues deviceValues);

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.ParentId, out value.Value);
                this.ParentId = value;
            }

            using (PropVariantFacade value = new PropVariantFacade())
            {
                deviceValues.GetValue(ref WPD.Name, out value.Value);
                this.Name = value;
            }

            ComTrace.WriteObject(deviceValues);

        }

        public string ObjectId { get; private set; }

        public string ParentId { get; private set; }

        public string Name { get; private set; }
    }
}
