using System;

namespace MediaDevices
{
    public class CompleteEventArgs : EventArgs
    {
        internal CompleteEventArgs(int hrStatus)
        {
            this.Status = hrStatus;
        }

        public int Status { get; private set; }
    }
}
