using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    /// <summary>
    /// Event argument class for media device events
    /// </summary>
    public class MediaDeviceEventArgs : EventArgs
    {
        internal MediaDeviceEventArgs(
            string pnpDeviceId, 
            Events eventEnum,
            OperationState operationState,
            uint operationProgress,
            string objectParentPersistanceUniqueId, 
            string objectCreationCookie,
            bool childHierarchyChanged,
            string serviceMethodContext)
        {
            this.PnpDeviceId = pnpDeviceId;
            this.Event = eventEnum;
            this.OperationState = operationState;
            this.OperationProgress = operationProgress;
            this.ObjectParentPersistanceUniqueId = objectParentPersistanceUniqueId;
            this.ObjectCreationCookie = objectCreationCookie;
            this.ChildHierarchyChanged = childHierarchyChanged;
            this.ServiceMethodContext = serviceMethodContext;
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
        /// Indicates that the child hiearchy for the object has changed.
        /// </summary>
        public bool ChildHierarchyChanged { get; private set; }

        /// <summary>
        /// Indicates the service method invocation context.
        /// </summary>
        public string ServiceMethodContext { get; private set; }
    }
}
