namespace EscapeRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            var game = new GamePlay();
            Console.WriteLine("Zanjdujesz się w pokoju bez okien. Spróbuj z niego wyjść.");
            do
            {
                game.ReloadRoom();
                game.DrawRoom();
                game.ShowPlayerItems();
                Console.WriteLine();
                Console.WriteLine("Co robisz ? (Używaj skrótów. Aby zobaczyć listę dostępnych opcji wpisz pomoc): ");
                string playerMove = game.PlayerMove();
                switch (playerMove)
                {
                    case "O":
                        game.OpenItem(game.PlayerItem(playerMove));
                        break;
                    case "P":
                        game.MoveItem(game.PlayerItem(playerMove));
                        break;
                    case "U":
                        game.UseItem(game.PlayerItem(playerMove));
                        break;
                    case "Z":
                        game.TakeItem(game.PlayerItem(playerMove));
                        break;
                    case "POMOC":
                        game.getHelp();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór:");
                        break;
                }
            } while (true);    
            
         
        }
    }
}