using System;

namespace MediaDevices
{
    /// <summary>
    /// Supported events
    /// </summary>
    public enum Events
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumGuid]
        Unknown,

        /// <summary>
        /// This GUID is used to identify all WPD driver events to the event sub-system. The driver uses this as the GUID identifier when it queues an event with IWdfDevice::PostEvent(). Applications never use this value.
        /// </summary>
        [EnumGuid(0x2BA2E40A, 0x6B4C, 0x4295, 0xBB, 0x43, 0x26, 0x32, 0x2B, 0x99, 0xAE, 0xB2)]
        Notification,

        /// <summary>
        /// This event is sent after a new object is available on the device.
        /// </summary>
        [EnumGuid(0xA726DA95, 0xE207, 0x4B02, 0x8D, 0x44, 0xBE, 0xF2, 0xE8, 0x6C, 0xBF, 0xFC)]
        ObjectAdded,

        /// <summary>
        /// This event is sent after a previously existing object has been removed from the device.
        /// </summary>
        [EnumGuid(0xBE82AB88, 0xA52C, 0x4823, 0x96, 0xE5, 0xD0, 0x27, 0x26, 0x71, 0xFC, 0x38)]
        ObjectRemoved,

        /// <summary>
        /// This event is sent after an object has been updated such that any connected client should refresh its view of that object.
        /// </summary>
        [EnumGuid(0x1445A759, 0x2E01, 0x485D, 0x9F, 0x27, 0xFF, 0x07, 0xDA, 0xE6, 0x97, 0xAB)]
        ObjectUpdated,

        /// <summary>
        /// This event indicates that the device is about to be reset, and all connected clients should close their connection to the device. 
        /// </summary>
        [EnumGuid(0x7755CF53, 0xC1ED, 0x44F3, 0xB5, 0xA2, 0x45, 0x1E, 0x2C, 0x37, 0x6B, 0x27)]
        DeviceReset,

        /// <summary>
        /// This event indicates that the device capabilities have changed. Clients should re-query the device if they have made any decisions based on device capabilities.
        /// </summary>
        [EnumGuid(0x36885AA1, 0xCD54, 0x4DAA, 0xB3, 0xD0, 0xAF, 0xB3, 0xE0, 0x3F, 0x59, 0x99)]
        DeviceCapabilitiesUpdated,

        /// <summary>
        /// This event indicates the progress of a format operation on a storage object.
        /// </summary>
        [EnumGuid(0x3782616B, 0x22BC, 0x4474, 0xA2, 0x51, 0x30, 0x70, 0xF8, 0xD3, 0x88, 0x57)]
        StorageFormat,

        /// <summary>
        /// This event is sent to request an application to transfer a particular object from the device.
        /// </summary>
        [EnumGuid(0x8D16A0A1, 0xF2C6, 0x41DA, 0x8F, 0x19, 0x5E, 0x53, 0x72, 0x1A, 0xDB, 0xF2)]
        ObjectTransferRequest,

        /// <summary>
        /// This event is sent when a driver for a device is being unloaded. This is typically a result of the device being unplugged.
        /// </summary>
        [EnumGuid(0xE4CBCA1B, 0x6918, 0x48B9, 0x85, 0xEE, 0x02, 0xBE, 0x7C, 0x85, 0x0A, 0xF9)]
        DeviceRemoved,

        /// <summary>
        /// This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
        /// </summary>
        [EnumGuid(0x8A33F5F8, 0x0ACC, 0x4D9B, 0x9C, 0xC4, 0x11, 0x2D, 0x35, 0x3B, 0x86, 0xCA)]
        ServiceMethodComplete
    }
}
