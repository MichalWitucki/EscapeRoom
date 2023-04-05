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
        public bool IsMoveable { get; set; }
        public bool IsTakeable { get; set; }
        public bool IsOpenable { get; set; }
        public bool IsCodeLocked { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public int Secret { get; }

        private string _code = "146";

        public Item(string Name, bool isMoveable, bool isTakeable, bool isOpenable, bool isVisibleNow, bool isCodeLocked,  int yCoordinate, int xCoordinate) 
        {
            this.Name = Name;
            this.ShortName = Name.Substring(0, 1);
            this.IsMoveable = isMoveable;
            this.IsTakeable = isTakeable;
            this.IsOpenable = isOpenable;
            this.IsVisibleNow = isVisibleNow;
            this.IsCodeLocked = isCodeLocked;
            this.yCoordinate = yCoordinate;
            this.xCoordinate = xCoordinate;
        }
        
        internal void SetNewXCoordinate()
        {
            this.xCoordinate += 1;
        }

        internal bool IsCodeCorrect(string userCode)
        {
            if (userCode == _code)
            {
                return true;
            }
            else return false;
        }

        internal void GetSecret(int number)
        {
            Console.WriteLine($"Odczytano cyfrę {_code.Substring(number,1)}.");
        }
    }
}
