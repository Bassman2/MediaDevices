using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerCtrl
{
    public class CopyEventArgs : EventArgs
    {
        public CopyEventArgs(double percentage, string file)
        {
            this.Percentage = percentage;
            this.File = file;
        }

        public double Percentage { get; private set; }
        public string File { get; private set; }
    }
}
