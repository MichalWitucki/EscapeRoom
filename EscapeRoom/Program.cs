using System.ComponentModel;

namespace EscapeRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GamePlay();
            Console.WriteLine("Zanjdujesz się w pokoju bez okien. Spróbuj z niego wyjść.");
            Console.WriteLine("Schemat pokoju:");
            game.ReloadRoom();
            game.DrawRoom();
            game.ShowPlayerItems();
            Console.WriteLine("W grze używa się skrótów (jeden znak). Aby zobaczyć listę dostępnych opcji wpisz pomoc.");
            do
            {
                Console.WriteLine("-----");
                Console.Write("Wykonaj ruch: ");
                string playerMove = Console.ReadLine().ToUpper();
                switch (playerMove)
                {
                    case "O":
                        game.OpenItem(game.WhichItem(playerMove));
                        break;
                    case "P":
                        game.MoveItem(game.WhichItem(playerMove));
                        break;
                    case "U":
                        game.UseItem(game.WhichItem(playerMove));
                        break;
                    case "Z":
                        game.TakeItem(game.WhichItem(playerMove));
                        break;
                    case "POMOC":
                        game.getHelp();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór.");
                        break;
                }
                if (game.wasActionToShow)
                {
                    game.ReloadRoom();
                    game.DrawRoom();
                    game.ShowPlayerItems();
                    game.wasActionToShow = false;
                }
            } 
            while (game.win == false);
        }
    }
}