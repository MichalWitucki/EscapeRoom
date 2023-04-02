using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class GamePlay
    {
        Room room1 = new Room(); 
        Room room2 = new Room();
        public GamePlay()
        {
            room1.DrawEpmtyRoom();
            room1.room[1, 1] = "F\t"; //fotel
            room1.room[1, 3] = "O\t"; //obraz
            room1.room[1, 5] = "K\t"; //komoda
            room1.room[3, 7] = "D\t"; //drzwi
            room1.room[5, 1] = "S\t"; //szafa
            room1.room[5, 5] = "T\t"; //taboret

            room2.DrawEpmtyRoom();
            room2.room[1, 1] = "F\t"; //fotel
            room2.room[5, 2] = "O\t"; //obraz
            room2.room[5, 5] = "R\t"; //roślina
            room2.room[1, 5] = "K\t"; //komoda
            room2.room[3, 6] = "W\t"; //wycieraczka
            room2.room[3, 7] = "D\t"; //drzwi
            
        }

        internal void DrawRoom(bool room)
        {
            switch (room)
            {
                case false:
                    {
                        for (int y = 0; y < room1.room.GetLength(0); y++)
                        {
                            for (int x = 0; x < room1.room.GetLength(1); x++)
                            {
                                Console.Write(room1.room[y, x]);
                            }
                            Console.WriteLine();
                        }
                        break;
                    }

                case true:
                    {
                        for (int y = 0; y < room2.room.GetLength(0); y++)
                        {
                            for (int x = 0; x < room2.room.GetLength(1); x++)
                            {
                                Console.Write(room2.room[y, x]);
                            }
                            Console.WriteLine();
                        }
                        break;
                    }
            }
        }

        internal void Help() 
        {
            Console.WriteLine("Przedmioty znajdujące się w pokoju:\nF - fotel, O - obraz, K - komoda, " +
                "S - szafa, T- taboret, R - roślina, W - wycieraczka, D - drzwi, G - gracz.");
            Console.WriteLine("Dostępne akcje:" +
                "\nU - użyj przedmiotu z ekwipunku, P - przesuń przedmiot, Z - zajrzyj na przedmiot, O - otwórz.");
        }

        internal void Move(string item)
        {

        }
    }
}
