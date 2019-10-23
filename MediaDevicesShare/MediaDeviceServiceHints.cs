using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices
{
    /// <summary>
    /// Hints Service class
    /// </summary>
    public class MediaDeviceServiceHints : MediaDeviceService
    {
        internal MediaDeviceServiceHints(MediaDevice device, string serviceId) : base(device, serviceId)
        {

        }

        /// <summary>
        /// Update service
        /// </summary>
        protected override void Update()
        {
            // no properties
        }

        
        
    }
}
