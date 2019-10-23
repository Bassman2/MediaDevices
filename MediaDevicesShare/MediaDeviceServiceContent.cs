using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    /// <summary>
    /// Content service class
    /// </summary>
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

        /// <summary>
        /// Object ID of teh content
        /// </summary>
        public string ObjectId { get; private set; }

        /// <summary>
        /// Parent ID of the content
        /// </summary>
        public string ParentId { get; private set; }

        /// <summary>
        /// Name of the content
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Get the content
        /// </summary>
        /// <returns>Content list</returns>
        public IEnumerable<MediaDeviceServiceContent> GetContent()
        {
            return this.service.GetContent(this.ObjectId);
        }

        /// <summary>
        /// Get all properties of the content
        /// </summary>
        /// <returns>List of properties</returns>
        public IEnumerable<KeyValuePair<string, string>> GetAllProperties()
        {
            return this.service.GetAllProperties(this.ObjectId);
        }
        
    }
}
