using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    public class MediaDeviceConnector : IConnectionRequestCallback
    {
        private IPortableDeviceConnector connector;

        public event EventHandler<CompleteEventArgs> Complete;

        private MediaDeviceConnector()
        { }

        internal MediaDeviceConnector(IPortableDeviceConnector connector)
        {
            this.connector = connector;
        }

        public void Connect()
        {
            this.connector.Connect(this);
        }

        public void Disconnect()
        {
            this.connector.Disconnect(this);
        }

        public void OnComplete([In, MarshalAs(UnmanagedType.Error)] int hrStatus)
        {
            this.Complete?.Invoke(this, new CompleteEventArgs(hrStatus));
        }
    }
}
