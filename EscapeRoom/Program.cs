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
                Console.Write("Co robisz ? (Aby zobaczyć listę dostępnych opcji wpisz pomoc.): ");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    
                    case "POMOC":
                        game.Help();
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór:");
                        break;
                }
            } while (true);    
            
         
        }
    }
}