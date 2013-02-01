using System;
using MLV;

namespace MyNes
{
    class ManagedListViewItem_BRom : ManagedListViewItem
    {
        private BRom rom;
        public BRom BRom
        { get { return rom; } set { rom = value; } }
    }
}
