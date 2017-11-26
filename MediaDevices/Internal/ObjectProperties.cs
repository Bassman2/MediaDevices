using PortableDeviceApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MediaDevices.Internal
{
    internal class ObjectProperties
    {
        private IPortableDeviceValues values;

        public ObjectProperties(IPortableDeviceProperties deviceProperties, string objectId)
        {
            try
            {
                IPortableDeviceKeyCollection keys;
                deviceProperties.GetSupportedProperties(objectId, out keys);
                deviceProperties.GetValues(objectId, keys, out this.values);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            //ComTrace.WriteObject(this.values);
        }

        public Guid ContentType
        {
            get
            {
                Guid value;
                this.values.TryGetGuidValue(WPD.OBJECT_CONTENT_TYPE, out value);
                return value;
            }
        }

        public string Name
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_NAME, out value);
                return value;
            }
        }

        public string OriginalFileName
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out value);
                return value;
            }
        }

        public ulong Size
        {
            get
            {
                ulong value = 0;
                this.values.TryGetUnsignedLargeIntegerValue(WPD.OBJECT_SIZE, out value);
                return value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_CREATED, out value);
                return value;
            }
        }

        public DateTime? DateModified
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_MODIFIED, out value);
                return value;
            }
        }

        public DateTime? DateAuthored
        {
            get
            {
                DateTime? value = null;
                this.values.TryGetDateTimeValue(WPD.OBJECT_DATE_AUTHORED, out value);
                return value;
            }
        }

        public bool CanDelete
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_CAN_DELETE, out value);
                return value;
            }
        }

        public bool IsSystem
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_ISSYSTEM, out value);
                return value;
            }
        }

        public bool IsHidden
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_ISHIDDEN, out value);
                return value;
            }
        }

        public bool IsDRMProtected
        {
            get
            {
                bool value;
                this.values.TryGetBoolValue(WPD.OBJECT_IS_DRM_PROTECTED, out value);
                return value;
            }
        }

        public string ParentId
        {
            get
            {
                string value;
                this.values.TryGetStringValue(WPD.OBJECT_PARENT_ID, out value);
                return value;
            }
        }
    }
}
