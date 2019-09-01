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

        private MediaDeviceServiceContent()
        { }

        internal MediaDeviceServiceContent(MediaDeviceService service, string objectId)
        {
            this.service = service;
            this.ObjectId = objectId;

            UpdateProperties();
        }

        internal virtual void UpdateProperties()
        {
            this.service.content.Properties(out IPortableDeviceProperties properties);

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

        public IEnumerable<MediaDeviceServiceContent> GetContent()
        {
            return this.service.GetContent(this.ObjectId);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllProperties()
        {
            return this.service.GetAllProperties(this.ObjectId);
        }
        
    }
}
