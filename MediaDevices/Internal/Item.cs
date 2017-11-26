using System.Diagnostics;

namespace MediaDevices.Internal
{

    [DebuggerDisplay("{this.Type} - {this.Name} - {this.Id}")]
    internal class Item
    {
        public const string RootId = "DEVICE";

        public static Item Root { get { return new Item(RootId, RootId, ItemType.Object, @"\"); } }


        public string Id { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; set; }
        public ItemType Type { get; private set; }

        public bool IsRoot { get { return this.Id == RootId; } }

        public Item(string id, string name, ItemType type, string FullName = null)
        {
            this.Id = id;
            this.Name = name;
            this.FullName = FullName;
            this.Type = type;
        }
    }
}
