using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    internal class BrætspilMenuer
    {
        static List<string> names = new List<string>(); // Liste til at gemme navne

        public static void AddBoardGame()
        {
            Console.Clear();
            Console.Write("Indtast navn på Brætspil: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                names.Add(name);
                Console.WriteLine($"\"{name}\" er tilføjet til listen.");
            }
            else
            {
                Console.WriteLine("Navnet kan ikke være tomt.");
            }
        }

        public static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("=== Liste over navne ===\n");
            if (names.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }

        public static void DeleteBoardGame()
        {
            PrintList();
            if (names.Count == 0)
            {
                Console.WriteLine("Ingen navne at slette.");
                return;
            }

            int index;
            while (true)
            {
                Console.Write("Indtast nummeret på det navn, du vil slette: ");
                string input = Console.ReadLine();


                Console.WriteLine($"Input: {input}");

                /*if { }
                

                }

                else
                {
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                }*/
            }
        }
    }
}
