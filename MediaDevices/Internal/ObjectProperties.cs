using PortableDeviceApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    internal class ObjectProperties
    {
        private IPortableDeviceValues values;

        public ObjectProperties(IPortableDeviceProperties deviceProperties, string objectId)
        {
            IPortableDeviceKeyCollection keys;
            deviceProperties.GetSupportedProperties(objectId, out keys);
            deviceProperties.GetValues(objectId, keys, out this.values);
        }

        public Guid ContentType
        {
            get
            {
                Guid value;
                this.values.GetGuidValue(WPD.OBJECT_CONTENT_TYPE, out value);
                return value;
            }
        }

        public string Name
        {
            get
            {
                string value;
                this.values.GetStringValue(WPD.OBJECT_NAME, out value);
                return value;
            }
        }

        public string OriginalFileName
        {
            get
            {
                string value;
                this.values.GetStringValue(WPD.OBJECT_ORIGINAL_FILE_NAME, out value);
                return value;
            }
        }

        public ulong Size
        {
            get
            {
                ulong value = 0;
                try
                { 
                    this.values.GetUnsignedLargeIntegerValue(WPD.OBJECT_SIZE, out value);
                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return value;
            }
        }

        public DateTime? DateCreated
        {
            get
            {
                DateTime? res = null;
                try
                {
                    PROPVARIANT value;
                    this.values.GetValue(WPD.OBJECT_DATE_CREATED, out value);
                    res = ((PropVariant)value).ToDate();
                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return res;
            }
        }

        public DateTime? DateModified
        {
            get
            {
                DateTime? res = null;
                try
                {
                    PROPVARIANT value;
                    this.values.GetValue(WPD.OBJECT_DATE_MODIFIED, out value);
                    res = ((PropVariant)value).ToDate();

                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return res;
            }
        }

        public DateTime? DateAuthored
        {
            get
            {
                DateTime? res = null;
                try
                {
                    PROPVARIANT value;
                    this.values.GetValue(WPD.OBJECT_DATE_AUTHORED, out value);
                    res = ((PropVariant)value).ToDate();

                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return res;
            }
        }

        public bool CanDelete
        {
            get
            {
                int value;
                this.values.GetBoolValue(WPD.OBJECT_CAN_DELETE, out value);
                return value != 0;
            }
        }

        public bool IsSystem
        {
            get
            {
                int value = 0;
                try
                {
                    this.values.GetBoolValue(WPD.OBJECT_ISSYSTEM, out value);
                }
                catch(COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return value != 0;
            }
        }

        public bool IsHidden
        {
            get
            {
                int value = 0;
                try
                {
                    this.values.GetBoolValue(WPD.OBJECT_ISHIDDEN, out value);
                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return value != 0;
            }
        }

        public bool IsDRMProtected
        {
            get
            {
                int value = 0;
                try
                {
                    this.values.GetBoolValue(WPD.OBJECT_IS_DRM_PROTECTED, out value);
                }
                catch (COMException ex)
                {
                    if ((uint)ex.HResult != (uint)HResult.ERROR_NOT_FOUND)
                    {
                        throw;
                    }
                }
                return value != 0;
            }
        }

        public string ParentId
        {
            get
            {
                string value;
                this.values.GetStringValue(WPD.OBJECT_PARENT_ID, out value);
                return value;
            }
        }

        //private bool Contains(PropertyKey key)
        //{

        //}
    }
}
