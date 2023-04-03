namespace EscapeRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool room2isAvailable = false; 
            var game = new GamePlay();
            Console.WriteLine("Zanjdujesz się w pokoju bez okien. Spróbuj z niego wyjść.");
            do
            {
                game.DrawRoom(room2isAvailable);
                game.ShowPlayerItems();
                Console.Write("Co robisz ? (Aby zobaczyć listę dostępnych opcji wpisz pomoc): ");
                string playerMove = game.PlayerMove();
                switch (playerMove)
                {
                    case "O":
                    case "OTWÓRZ":
                    case "OTWORZ":
                        game.OpenItem(game.PlayerItem(playerMove));
                        break;
                    case "P":
                    case "PRZESUŃ":
                    case "PRZESUN":
                        game.MoveItem(game.PlayerItem(playerMove));
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