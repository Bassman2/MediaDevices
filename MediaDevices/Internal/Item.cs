using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevices.Internal
{
    
    internal class Item
    {
        

        public const string RootId = "DEVICE";

        public static Item Root { get { return new Item(RootId, RootId , ItemType.Object ); } }

        public Item(string id, string name, ItemType type)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public ItemType Type { get; private set; }

        public override string ToString()
        {
            return $"{this.Type} - {this.Name} - {this.Id}";
        }
    }
}
