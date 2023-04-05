using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Timers;


namespace EscapeRoom
{
    internal class GamePlay
    {
        public Room room = new Room();
        public List<Item> items = new List<Item>();
        public List<Item> equipment = new List<Item>();
        public bool wasActionToShow, win;
        Item armchair = new Item("Fotel", true, false, false, true, false, 0, 0);
        Item painting = new Item("Obraz", true, false, false, true, false, 0, 2);
        Item desk = new Item("Biurko", true, false, true, true, false, 0, 4);
        Item wardrobe = new Item("Szafa", false, false, false, true, false, 4, 0);
        Item stool = new Item("Taboret", true, true, false, true, false, 4, 4);
        Item microvawe = new Item("Mikrofalówka", true, false, true, false, false, 0, 0);
        Item coffeeMachine = new Item("Ekspres do kawy", true, false, false, false, false, 0, 4);
        Item plant = new Item("Roślina", true, false, false, false, false, 4, 1);
        Item flashlight = new Item("Latarka", true, true, false, false, false, 4, 3);
        Item player = new Item("Gracz", false, false, false, true, false, 2, 0);
        Item door = new Item("Drzwi", false, false, false, true, false, 2, 5);
        Item key = new Item("Klucz", false, true, false, false, false, 0, 0);
        Item picklock = new Item("Wytrych", false, true, false, false, false, 0, 0);
        Item album = new Item("Album", false, true, true, false, false, 0, 0);
        Item notepad = new Item("Notatnik", false, true, true, false, false, 0, 0);
        Item notebook = new Item("Zeszyt", false, true, true, false, false, 0, 0);
        
        public GamePlay()
        {
            items.Add(armchair);
            items.Add(painting);
            items.Add(desk);
            items.Add(wardrobe);
            items.Add(stool);
            items.Add(microvawe);
            items.Add(coffeeMachine);
            items.Add(plant);
            items.Add(flashlight);
            items.Add(door);
            items.Add(player);
            items.Add(key);
            items.Add(picklock);
            items.Add(album);
            items.Add(notepad);
            items.Add(notebook);
        }

        internal void ReloadRoom()
        {
            foreach (Item item in items)
            {
                if (item.IsVisibleNow)
                    room.room[item.yCoordinate, item.xCoordinate] = item.ShortName;
            }
        }

        internal void DrawRoom()
        {
            Console.Write("_");
            for (int i = 0; i < room.room.GetLength(1); i++)
                Console.Write("______");
            Console.WriteLine("_____");
            for (int y = 0; y < room.room.GetLength(0); y++)
            {
                Console.Write("|");
                int x;
                for (x = 0; x < room.room.GetLength(1) - 1; x++)
                {
                    Console.Write($"{room.room[y, x]}\t");
                }
                Console.Write($"{room.room[y, x]}");
                Console.WriteLine("|");
            }
            Console.Write("¯");
            for (int i = 0; i < room.room.GetLength(1) - 1; i++)
                Console.Write("¯¯¯¯¯¯¯");
            Console.WriteLine("¯¯¯¯¯¯");
        }

        internal void getHelp()
        {
            Console.WriteLine("Możliwe ruchy:");
            Console.WriteLine("U = użyj przedmiotu z ekwipunku, P = przesuń przedmiot, Z = zabierz przedmiot, O = otwórz przedmiot."); 
            Console.WriteLine("Przedmioty, które znajdują się w pokoju: ");
            foreach (var item in items)
            {
                if (item.IsVisibleNow)
                    Console.Write($"{item.ShortName} = {item.Name}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Przedmioty, które znajdują się w ekwipunku: ");
            foreach (var item in equipment)
            {
                Console.Write($"{item.ShortName} = {item.Name}, ");
            }
            Console.WriteLine();
        }

        internal void ShowPlayerItems()
        {
            Console.Write("Ekwipunek gracza: ");
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

        internal Item WhichItem(string move)
        {
            if (move == "U")
            {
                Console.Write($"Jakiego przedmiotu dotyczy ruch ?: ");
                string item = Console.ReadLine().ToUpper();
                var playerItem = equipment.Find(x => x.ShortName == item);
                return playerItem;
            }
            else
            {
                Console.Write($"Jakiego przedmiotu dotyczy ruch ?: ");
                string item = Console.ReadLine().ToUpper();
                var playerItem = items.Find(x => x.ShortName == item);
                return playerItem;
            }
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
                            Console.WriteLine($"Przesunięto: {item.Name}.");
                            item.IsMoved = true;
                            wasActionToShow = true;
                            if (item.ShortName == "B")
                                MoveAndDiscover(picklock, item);
                            else if (item.ShortName == "R")
                                MoveAndDiscover(album, item);
                            else if (item.ShortName == "E")
                                MoveAndDiscover(notebook, item);
                            else
                                Console.WriteLine("Nic się nie wydarzyło.");

                            room.room[item.yCoordinate, item.xCoordinate] = " "; 
                            item.SetNewXCoordinate();
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

        internal void MoveAndDiscover(Item item, Item movedItem)
        {
            room.room[item.yCoordinate, item.xCoordinate] = item.ShortName;
            item.yCoordinate = movedItem.yCoordinate;
            item.xCoordinate = movedItem.xCoordinate;
            item.IsVisibleNow = true;
            Console.WriteLine($"Odkryto: {item.Name}.");
        }

        internal void OpenItem(Item item)
        {
            if (items.Contains(item))
            {
                if (item.IsVisibleNow)
                {
                    if (item.IsOpenable)
                    {
                        if (item.IsCodeLocked)
                        {
                            Console.WriteLine("Aby otworzyć drzwi musisz podać trzycyfrowy kod. Masz trzy próby.");
                            for (int i = 1; i < 4; i++)
                            {
                                Console.Write($"Próba {i}: ");
                                win = item.IsCodeCorrect(Console.ReadLine()) ;
                                if (win)
                                {
                                    item.IsOpen = true;
                                    Console.WriteLine("Kod jest poprawny. Koniec gry.");
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                    Console.WriteLine("Niepoprawny kod.");
                            }
                        }
                        else
                        {
                            if (item.IsOpen)
                                Console.WriteLine($"Przedmiot: {item.Name} został już otwarty.");
                            else
                            {
                                Console.WriteLine($"Otwarto: {item.Name}.");
                                item.IsOpen = true;
                                if (item.ShortName == "S")
                                { 
                                    OpenAndDiscover(key, item);
                                    wasActionToShow = true;
                                }
                                else if (item.ShortName == "M")
                                {
                                    OpenAndDiscover(notepad, item);
                                    wasActionToShow = true;
                                }
                                else if (item.ShortName == "D")
                                {
                                    Console.WriteLine("Odkryto nowy pokój.");
                                    wasActionToShow = true;
                                    NewRoom();
                                }
                                else
                                    Console.WriteLine("Nic się nie wydarzyło.");
                            }
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

        internal void OpenAndDiscover(Item item, Item openedItem)
        {
            item.yCoordinate = openedItem.yCoordinate;
            item.xCoordinate = openedItem.xCoordinate + 1;
            room.room[item.yCoordinate, item.xCoordinate] = item.ShortName;
            item.IsVisibleNow = true;
            Console.WriteLine($"Odkryto: {item.Name}.");
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
                            room.room[item.yCoordinate, item.xCoordinate] = " ";
                            item.IsVisibleNow = false;
                            item.IsTaken = true;
                            wasActionToShow = true;
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

        internal void UseItem(Item item)
        {
            if (equipment.Contains(item))
            {
                wasActionToShow = true; 
                Console.WriteLine($"Użyto: {item.Name}.");
                if (item.ShortName == "A")
                {
                    item.GetSecret(0);
                }
                else if (item.ShortName == "N")
                {
                    item.GetSecret(1);
                }
                else if (item.ShortName == "Z")
                {
                    item.GetSecret(2);
                }
                else if (item.ShortName == "W")
                {
                    UnlockItem(wardrobe);
                    equipment.Remove(item);
                }
                else if (item.ShortName == "K")
                {
                    UnlockItem(door);
                    equipment.Remove(item);
                }
                else
                    Console.WriteLine("Nic się nie wydarzyło.");
            }
            else
                Console.WriteLine($"W ekwipunku nie ma takiego przedmiotu.");
        }

        internal void UnlockItem(Item item)
        {
            Console.WriteLine($"Przedmiot: {item.Name} został odblokowany.");
            item.IsOpenable = true;
        }

        internal void NewRoom()
        {
            for (int i = 0; i < room.room.GetLength(0); i++)
            {
                for (int j = 0; j < room.room.GetLength(1); j++)
                {
                    room.room[i, j] = " ";
                }
            }          
            foreach (Item item in items)
            {
                if (item.IsVisibleNow)
                    item.IsVisibleNow = false;
            }
            microvawe.IsVisibleNow = true;
            coffeeMachine.IsVisibleNow = true;
            plant.IsVisibleNow = true;
            flashlight.IsVisibleNow = true; 
            player.IsVisibleNow = true;
            items.Remove(door);
            Item door2 = new Item("Drzwi", false,  false, true, true, true, 2, 5);
            items.Add(door2);
        }
    }
}
