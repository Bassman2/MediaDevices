using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    /// <summary>
    /// MediaDive connector
    /// </summary>
    public class MediaDeviceConnector : IConnectionRequestCallback
    {
        private IPortableDeviceConnector connector;

        /// <summary>
        /// Event signals if complete
        /// </summary>
        public event EventHandler<CompleteEventArgs> Complete;

        private MediaDeviceConnector()
        { }

        internal MediaDeviceConnector(IPortableDeviceConnector connector)
        {
            this.connector = connector;
        }

        /// <summary>
        /// Connect to service
        /// </summary>
        public void Connect()
        {
            this.connector.Connect(this);
        }

        /// <summary>
        /// Disconnect from service
        /// </summary>
        public void Disconnect()
        {
            this.connector.Disconnect(this);
        }

        /// <summary>
        /// On completed
        /// </summary>
        /// <param name="hrStatus">Status</param>
        public void OnComplete([In, MarshalAs(UnmanagedType.Error)] int hrStatus)
        {
            this.Complete?.Invoke(this, new CompleteEventArgs(hrStatus));
        }
    }
}
