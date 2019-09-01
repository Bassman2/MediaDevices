using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerCtrl
{
    public class RefreshEventArgs : EventArgs
    {
        public RefreshEventArgs(bool recursive)
        {
            this.Recursive = recursive;
        }

        public bool Recursive { get; private set; }
    }
}
