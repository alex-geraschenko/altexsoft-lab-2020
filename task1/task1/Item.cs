using System;
using System.Collections.Generic;
using System.Text;

namespace task1
{
    enum ItemType
    {
        File,
        Folder
    }
    class Item
    {
        public int index;
        public ItemType type;
        public string name;

        public Item(int _index, ItemType _type, string _name)
        {
            this.index = _index;
            this.type = _type;
            this.name = _name;
        }
    }


}
