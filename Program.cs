namespace ProjektGenspil
{
    internal class Program
    {
        static void Main(string[] args)
            
        {
           

            Console.WriteLine("|----Projekt Genspil Menu----|");
            Console.WriteLine("|1.AddBoardGame              |");
            Console.WriteLine("|2.RemoveBoardGame           |");
            Console.WriteLine("|3.PrintStockList            |");
            Console.WriteLine("|4.SearchBoardgameFcritria   |");
            Console.WriteLine("|5.ViewboardGame             |");
            Console.WriteLine("|----------------------------|");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    {
                        Console.WriteLine("|----Projekt Genspil Menu----|");
                        Console.WriteLine("|1.AddBoardGame              |");
                        Console.WriteLine("|2.RemoveBoardGame           |");
                        Console.WriteLine("|3.PrintStockList            |");
                        Console.WriteLine("|4.SearchBoardgameFcritria   |");
                        Console.WriteLine("|5.ViewboardGame             |");
                        Console.WriteLine("|----------------------------|");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("|----Projekt Genspil Menu----|");
                        Console.WriteLine("|1.AddBoardGame              |");
                        Console.WriteLine("|2.RemoveBoardGame           |");
                        Console.WriteLine("|3.PrintStockList            |");
                        Console.WriteLine("|4.SearchBoardgameFcritria   |");
                        Console.WriteLine("|5.ViewboardGame             |");
                        Console.WriteLine("|----------------------------|");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("|----Projekt Genspil Menu----|");
                        Console.WriteLine("|1.AddBoardGame              |");
                        Console.WriteLine("|2.RemoveBoardGame           |");
                        Console.WriteLine("|3.PrintStockList            |");
                        Console.WriteLine("|4.SearchBoardgameFcritria   |");
                        Console.WriteLine("|5.ViewboardGame             |");
                        Console.WriteLine("|----------------------------|");
                        break;
                    }
                    case 4:
                    {
                        
                       
                         Console.WriteLine("|----Projekt Genspil Menu----|");
                         Console.WriteLine("|1.AddBoardGame              |");
                         Console.WriteLine("|2.RemoveBoardGame           |");
                         Console.WriteLine("|3.PrintStockList            |");
                         Console.WriteLine("|4.SearchBoardgameFcritria   |");
                         Console.WriteLine("|5.ViewboardGame             |");
                         Console.WriteLine("|----------------------------|");
                         break;
                    }
                    case 5:
                    {


                        Console.WriteLine("|----Projekt Genspil Menu----|");
                        Console.WriteLine("|1.AddBoardGame              |");
                        Console.WriteLine("|2.RemoveBoardGame           |");
                        Console.WriteLine("|3.PrintStockList            |");
                        Console.WriteLine("|4.SearchBoardgameFcritria   |");
                        Console.WriteLine("|5.ViewboardGame             |");
                        Console.WriteLine("|----------------------------|");
                        break;
                    }
            }

            List<Brætspil> spil = new List<Brætspil>();

        }
    }
}
