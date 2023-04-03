using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class Item
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsMoved { get; set; }
        public bool IsOpen { get; set; }
        public bool IsMoveable { get; private set; }
        public bool IsPickable { get; private set; }
        public bool IsOpenable { get; private set; }
        public byte xCoordinate { get; private set; }
        public byte yCoordinate { get; private set; }

        public Item(string Name, bool isMoveable, bool isPickable, bool isOpenable, byte yCoordinate, byte xCoordinate) 
        {
            this.Name = Name;
            this.ShortName = Name.Substring(0, 1);
            this.IsMoveable = isMoveable;
            this.IsPickable = isPickable;
            this.IsOpenable = isOpenable;
            this.yCoordinate = yCoordinate;
            this.xCoordinate = xCoordinate;
        }
        public Item(string Name, byte yCoordinate, byte xCoordinate)
        {
            this.Name = Name; 
            this.ShortName = Name.Substring(0, 1);
            this.yCoordinate = yCoordinate;
            this.xCoordinate = xCoordinate;
        }

        internal void SetNewXCoordinate()
        {
            this.xCoordinate += 1;
        }

        //public Item()
        //{
        //    this.Name = Name; 
        //    this.ShortName = Name.Substring(0, 1);
        //}
    }
}
