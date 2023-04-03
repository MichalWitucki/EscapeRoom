using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    internal class GamePlay
    {
        public Room room1 = new Room();
        public List<Item> items = new List<Item>();
        public List<Item> equipment = new List<Item>();

        //Room room2 = new Room();
        public GamePlay()
        {
            Item commode = new Item("Komoda", true, false, true, 0, 4);
            items.Add(commode);
            Item armchair = new Item("Fotel", true, false, false, 0 , 0);
            items.Add(armchair);
            Item painting = new Item("Obraz", true, false, false, 0, 2);
            items.Add(painting);
            Item wardrobe = new Item("Szafa", false, false, false, 4, 0);
            items.Add(wardrobe);
            Item stool = new Item("Taboret", true, true, false, 4, 4);
            items.Add(stool);
            Item plant = new Item("Roślina", true, true, false, 4, 4);
            items.Add(plant);
            Item doormat = new Item("Wycieraczka", true, true, false, 2, 4);
            items.Add(doormat);
            Item door = new Item("Drzwi", false, false, true, 2, 5);
            items.Add(door);
            Item player = new Item("Gracz", 2, 0);
            items.Add(player);

            ReloadRoom();
           
            room1.room[commode.yCoordinate, commode.xCoordinate] = commode.ShortName;
            room1.room[armchair.yCoordinate, armchair.xCoordinate] = armchair.ShortName;
            room1.room[painting.yCoordinate, painting.xCoordinate] = painting.ShortName;
            room1.room[wardrobe.yCoordinate, wardrobe.xCoordinate] = wardrobe.ShortName;
            room1.room[stool.yCoordinate, stool.yCoordinate] = stool.ShortName;
            room1.room[door.yCoordinate, door.xCoordinate] = door.ShortName;
            room1.room[player.yCoordinate, player.xCoordinate] = player.ShortName;
        }

        internal void ReloadRoom()
        {
            room1.room[commode.yCoordinate, commode.xCoordinate] = commode.ShortName;
            room1.room[armchair.yCoordinate, armchair.xCoordinate] = armchair.ShortName;
            room1.room[painting.yCoordinate, painting.xCoordinate] = painting.ShortName;
            room1.room[wardrobe.yCoordinate, wardrobe.xCoordinate] = wardrobe.ShortName;
            room1.room[stool.yCoordinate, stool.yCoordinate] = stool.ShortName;
            room1.room[door.yCoordinate, door.xCoordinate] = door.ShortName;
            room1.room[player.yCoordinate, player.xCoordinate] = player.ShortName;
        }
        
        internal void DrawRoom(bool room)
        {
            switch (room)
            {
                case false:
                    {
                        for (int i = 0; i < room1.room.GetLength(1); i++)
                            Console.Write("_______\t");
                        Console.WriteLine("__");
                        for (int y = 0; y < room1.room.GetLength(0); y++)
                        {
                            Console.Write("|\t");
                            int x;
                            for (x = 0; x < room1.room.GetLength(1) - 1; x++)
                            {
                                Console.Write($"{room1.room[y, x]}\t");
                            }
                            Console.Write($"{room1.room[y, x]}");
                            Console.WriteLine("|");
                        }
                        for (int i = 0; i < room1.room.GetLength(1); i++)
                            Console.Write("¯¯¯¯¯¯¯\t");
                        Console.WriteLine("¯¯");
                        break;
                    }

                    //case true:
                    //    {
                    //        for (int y = 0; y < room2.room.GetLength(0); y++)
                    //        {
                    //            for (int x = 0; x < room2.room.GetLength(1); x++)
                    //            {
                    //                Console.Write(room2.room[y, x]);
                    //            }
                    //            Console.WriteLine();
                    //        }
                    //        break;
                    //    }
            }
        }

        internal void getHelp()
        {
            Console.WriteLine("Przedmioty, które mogą znajdować się w pokoju:\nG - gracz, D - drzwi, F - fotel, O - obraz, K - komoda, " +
                "S - szafa, T- taboret, R - roślina, W - wycieraczka.");
            Console.WriteLine("Dostępne akcje:" +
                "\nU - użyj przedmiotu z ekwipunku, P - przesuń przedmiot, Z - zabierz, O - otwórz.");
        }

        internal void ShowPlayerItems()
        {
            foreach (var item in equipment)
            {
                Console.Write(item);
            }
        }

        internal string PlayerMove()
        {
            string move = Console.ReadLine().ToUpper();
            return move;
        }

        internal Item PlayerItem(string move)
        {
            Console.Write($"Jakiego przedmiotu dotyczy ruch: {move} ?: ");
            string item = Console.ReadLine().ToUpper();
            var playerItem = items.Find(x => x.ShortName == item);
            return playerItem;
        }

        internal void MoveItem(Item item)
        {
            if (items.Contains(item))
            {
                if (item.IsMoveable)
                {
                    if (item.IsMoved)
                        Console.WriteLine($"Przedmiot: {item.Name} został już przesunięty.");
                    else
                    {
                        item.SetNewXCoordinate();
                        item.IsMoved = true;
                        Console.WriteLine($"Przesunięto: {item.Name}.");
                    }
                }
                else
                    Console.WriteLine($"Nie można przesunąć przedmiotu: {item.Name}."); 
            }
            else
                Console.WriteLine("Niepoprawny wybór.");
        }

        internal void OpenItem(Item item)
        {
            if (items.Contains(item))
            {
                if (item.IsOpenable)
                {
                    if (item.IsOpen)
                        Console.WriteLine($"Przedmiot: {item.Name} został już otwarty.");
                    else
                    {
                        Console.WriteLine(item.IsOpen);
                        Console.WriteLine("mamy to");
                    }
                }
                else
                    Console.WriteLine($"Nie można otworzyć przedmiotu: {item.Name}.");
            }
            else
                Console.WriteLine("Niepoprawny wybór.");
        }
    }
}
