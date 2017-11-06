using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{
    
    internal class Item
    {
        public string Id;
        public string Name;
        public ItemType Type;

        public const string RootId = "DEVICE";

        public static Item Root { get { return new Item() { Id = RootId, Name = RootId, Type = ItemType.Object }; } }

        public override string ToString()
        {
            return $"{this.Type} - {this.Name} - {this.Id}";
        }
    }
}
