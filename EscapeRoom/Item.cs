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
        public bool IsTaken { get; set; }
        public bool IsVisibleNow { get; set; }
        public bool IsMoveable { get; private set; }
        public bool IsTakeable { get; private set; }
        public bool IsOpenable { get; private set; }
        public byte xCoordinate { get; set; }
        public byte yCoordinate { get; set; }

        public Item(string Name, bool isMoveable, bool isTakeable, bool isOpenable, bool isVisibleNow, byte yCoordinate, byte xCoordinate) 
        {
            this.Name = Name;
            this.ShortName = Name.Substring(0, 1);
            this.IsMoveable = isMoveable;
            this.IsTakeable = isTakeable;
            this.IsOpenable = isOpenable;
            this.IsVisibleNow = isVisibleNow;
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
