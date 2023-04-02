using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{

    internal class Room
    {
        public string[,] room = new string[7, 8];
        public Room() 
        { 
        }

        public void DrawEpmtyRoom()
        {

            for (int i = 0; i < room.GetLength(1); i++) // getl=8
            {
                room[0, i] = "_\t";
                room[6, i] = "¯\t";
            }
            for (int i = 1; i < room.GetLength(0) - 1; i++) // getl=7
            {
                room[i, 0] = "|\t";
                room[i, 1] = "\t";
                room[i, 2] = "\t";
                room[i, 3] = "\t";
                room[i, 4] = "\t";
                room[i, 5] = "\t";
                room[i, 6] = "\t";
                room[i, 7] = "|\t";
            }
            room[3, 0] = "G\t"; //Gracz

        }
    }
}
