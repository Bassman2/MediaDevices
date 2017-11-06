using PortableDeviceApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    internal class EventCallback : IPortableDeviceEventCallback
    {
        private MediaDevice device;

        public EventCallback(MediaDevice device)
        {
            this.device = device;
        }

        public void OnEvent(IPortableDeviceValues pEventParameters)
        {
            this.device.CallEvent(pEventParameters);
        }
    }
}
