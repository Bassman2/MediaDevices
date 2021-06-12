using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ExplorerCtrl
{
    public interface IExplorerItem : IEquatable<IExplorerItem>
    {
        event EventHandler<RefreshEventArgs> Refresh;

        string Name { get; set; }
        string FullName { get; }
        string Link { get; }
        long Size { get; }
        DateTime? Date { get; }
        ExplorerItemType Type { get; }
        ImageSource Icon { get; }
        bool IsDirectory { get; }
        bool HasChildren { get; }
        IEnumerable<IExplorerItem> Children { get; }
        void Push(Stream stream, string path);
        void Pull(string path, Stream stream);
        void CreateFolder(string path);
    }
}
