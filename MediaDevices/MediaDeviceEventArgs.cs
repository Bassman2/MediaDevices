using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;

namespace MediaDevices
{
    /// <summary>
    /// Event argument class for media device events
    /// </summary>
    public class MediaDeviceEventArgs : EventArgs
    {
        protected MediaDevice mediaDevice;

        internal MediaDeviceEventArgs(Events eventEnum, MediaDevice mediaDevice, IPortableDeviceValues eventParameters)
        {
            this.mediaDevice = mediaDevice;
            this.Event = eventEnum;

            string pnpDeviceId = string.Empty;
            eventParameters.GetStringValue(WPD.EVENT_PARAMETER_PNP_DEVICE_ID, out pnpDeviceId);
            this.PnpDeviceId = pnpDeviceId;
                        
            //try
            if (ComHelper.HasKeyValue(eventParameters, WPD.EVENT_PARAMETER_OPERATION_STATE))
            {
                uint operationState = 0;
                eventParameters.GetUnsignedIntegerValue(WPD.EVENT_PARAMETER_OPERATION_STATE, out operationState);
                this.OperationState = (OperationState)operationState;
            }
            //catch { }
            try
            {
                uint operationProgress = 0;
                eventParameters.GetUnsignedIntegerValue(WPD.EVENT_PARAMETER_OPERATION_PROGRESS, out operationProgress);
                this.OperationProgress = operationProgress;
            }
            catch { }
            try
            {
                string objectParentPersistanceUniqueId = string.Empty;
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID, out objectParentPersistanceUniqueId);
                this.ObjectParentPersistanceUniqueId = objectParentPersistanceUniqueId;
            }
            catch { }
            try
            {
                string objectCreationCookie = string.Empty;
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_OBJECT_CREATION_COOKIE, out objectCreationCookie);
                this.ObjectCreationCookie = objectCreationCookie;
            }
            catch { }
            try
            {
                int childHierarchyChanged = 0;
                eventParameters.GetBoolValue(WPD.EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED, out childHierarchyChanged);
                this.ChildHierarchyChanged = childHierarchyChanged != 0;
            }
            catch { }
            try
            {
                string serviceMethodContext = string.Empty;
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_SERVICE_METHOD_CONTEXT, out serviceMethodContext);
                this.ServiceMethodContext = serviceMethodContext;
            }
            catch { }
        }

        /// <summary>
        /// Indicates the device that originated the event.
        /// </summary>
        public string PnpDeviceId { get; private set; }

        /// <summary>
        /// Indicates the event sent.
        /// </summary>
        public Events Event { get; private set; }

        /// <summary>
        /// Indicates the current state of the operation (e.g. started, running, stopped etc.).
        /// </summary>
        public OperationState OperationState { get; private set; }

        /// <summary>
        /// Indicates the progress of a currently executing operation. Value is from 0 to 100, with 100 indicating that the operation is complete.
        /// </summary>
        public uint OperationProgress { get; private set; }

        /// <summary>
        /// Uniquely identifies the parent object, similar to WPD_OBJECT_PARENT_ID, but this ID will not change between sessions.
        /// </summary>
        public string ObjectParentPersistanceUniqueId { get; private set; }

        /// <summary>
        /// This is the cookie handed back to a client when it requested an object creation using the IPortableDeviceContent::CreateObjectWithPropertiesAndData method.
        /// </summary>
        public string ObjectCreationCookie { get; private set; }

        /// <summary>
        /// Indicates that the child hierarchy for the object has changed.
        /// </summary>
        public bool ChildHierarchyChanged { get; private set; }

        /// <summary>
        /// Indicates the service method invocation context.
        /// </summary>
        public string ServiceMethodContext { get; private set; }
    }
}
