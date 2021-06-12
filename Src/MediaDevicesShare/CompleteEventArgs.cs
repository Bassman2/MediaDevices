using System;

namespace MediaDevices
{
    /// <summary>
    /// Complete event arguments
    /// </summary>
    public class CompleteEventArgs : EventArgs
    {
        internal CompleteEventArgs(int hrStatus)
        {
            this.Status = hrStatus;
        }

        /// <summary>
        /// Status
        /// </summary>
        public int Status { get; private set; }
    }
}
