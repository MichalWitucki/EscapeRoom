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
        Item commode = new Item("Komoda", true, false, true, true, 0, 4);
        Item armchair = new Item("Fotel", true, false, false, true, 0, 0);
        Item painting = new Item("Obraz", true, false, false, true, 0, 2);
        Item wardrobe = new Item("Szafa", false, false, false, true, 4, 0);
        Item stool = new Item("Taboret", true, true, false, true, 4, 4);
        Item plant = new Item("Roślina", true, true, false, false, 4, 4);
        Item doormat = new Item("Wycieraczka", true, true, false, false, 2, 4);
        Item door = new Item("Drzwi", false, false, true, true, 2, 5);
        Item player = new Item("Gracz", false, false, false, true, 2, 0);




        //Room room2 = new Room();
        public GamePlay()
        {
            items.Add(commode);
            items.Add(armchair);
            items.Add(painting);
            items.Add(wardrobe);
            items.Add(stool);
            items.Add(plant);
            items.Add(doormat);
            items.Add(door);
            items.Add(player);
            


        }

        internal void ReloadRoom()
        {
            foreach (Item item in items)
            {
                
                if (item.IsVisibleNow)
                    room1.room[item.yCoordinate, item.xCoordinate] = item.ShortName;
            }
            //room1.room[commode.yCoordinate, commode.xCoordinate] = commode.ShortName;
            //room1.room[armchair.yCoordinate, armchair.xCoordinate] = armchair.ShortName;
            //room1.room[painting.yCoordinate, painting.xCoordinate] = painting.ShortName;
            //room1.room[wardrobe.yCoordinate, wardrobe.xCoordinate] = wardrobe.ShortName;
            //room1.room[stool.yCoordinate, stool.xCoordinate] = stool.ShortName;
            //room1.room[door.yCoordinate, door.xCoordinate] = door.ShortName;
            //room1.room[player.yCoordinate, player.xCoordinate] = player.ShortName;
           
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
            Console.WriteLine("Przedmioty, które znajdują się w pokoju: ");
            foreach (var item in items)
            {
                if (item.IsVisibleNow)
                    Console.Write($"{item.ShortName} = {item.Name}, ");
            }
            Console.WriteLine("\nDostępne akcje:\nU = użyj przedmiotu z ekwipunku, P = przesuń przedmiot, Z = zabierz przedmiot, O = otwórz przedmiot.");
        }

        internal void ShowPlayerItems()
        {
            Console.Write("Twój ekwipunek: ");
            if (equipment.Count() == 0) 
                Console.Write("jest pusty.");
            else
            {
                foreach (var item in equipment)
                {
                    Console.Write($"{item.ShortName}, ");

                }
            }
            Console.WriteLine();
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
                if (item.IsVisibleNow)
                {
                    if (item.IsMoveable)
                    {
                        if (item.IsMoved)
                            Console.WriteLine($"Przedmiot: {item.Name} został już przesunięty.");
                        else
                        {
                            room1.room[item.yCoordinate, item.xCoordinate] = " ";
                            item.SetNewXCoordinate();
                            item.IsMoved = true;
                            Console.WriteLine($"Przesunięto: {item.Name}.");
                        }
                    }
                    else
                        Console.WriteLine($"Nie można przesunąć przedmiotu: {item.Name}.");
                }
                else
                    Console.WriteLine("W pokoju nie ma takiego przedmiotu.");

                 
            }
            else
                Console.WriteLine("Niepoprawny wybór.");
        }

        internal void OpenItem(Item item)
        {
            if (items.Contains(item))
            {
                if (item.IsVisibleNow)
                {
                    if (item.IsOpenable)
                    {
                        if (item.IsOpen)
                            Console.WriteLine($"Przedmiot: {item.Name} został już otwarty.");
                        else
                        {
                            item.IsOpen = true;
                            Console.WriteLine($"Otwarto: {item.Name}.");
                        }
                    }
                    else
                        Console.WriteLine($"Nie można otworzyć przedmiotu: {item.Name}.");
                }
                else
                    Console.WriteLine("W pokoju nie ma takiego przedmiotu.");

            }
            else
                Console.WriteLine("Niepoprawny wybór.");
        }

        internal void TakeItem(Item item)
        {
            if (items.Contains(item))
            {
                if (item.IsVisibleNow)
                {
                    if (item.IsTakeable)
                    {
                        if (item.IsTaken)
                            Console.WriteLine($"Przedmiot: {item.Name} został już zabrany.");
                        else
                        {
                            room1.room[item.yCoordinate, item.xCoordinate] = " ";
                            item.IsVisibleNow = false;
                            item.IsTaken = true;
                            equipment.Add(item);
                            Console.WriteLine($"Zabrano: {item.Name}.");
                        }
                    }
                    else
                        Console.WriteLine($"Nie można zabrać przedmiotu: {item.Name}.");
                }
                else
                    Console.WriteLine("W pokoju nie ma takiego przedmiotu.");
            }
            else
                Console.WriteLine("Niepoprawny wybór.");
        }
    }
}
