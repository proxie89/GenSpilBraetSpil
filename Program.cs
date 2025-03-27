using System;
using System.Collections.Generic;

namespace ProjektGenspil
{
    class Program
    {
        static List<string> names = new List<string>(); // Liste til at gemme navne

        static void Main()
        {
            while (true)
            {
                Console.Clear(); // Rydder skærmen for en ren menuvisning
                Console.WriteLine("=== Hovedmenu ===");
                Console.WriteLine("1. Tilføj navn til listen");
                Console.WriteLine("2. Vis alle navne");
                Console.WriteLine("3. Slet et navn");
                Console.WriteLine("3. Afslut");
                Console.Write("Vælg en mulighed: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddName();
                        break;
                    case "2":
                        ShowNames();
                        break;
                    case "3":
                        DeleteName();
                        break;
                    case "4":
                        Console.WriteLine("Farvel!");
                        return; // Afslutter programmet
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }

                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        static void AddName()
        {
            Console.Clear();
            Console.Write("Indtast et navn: ");
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

        static void ShowNames()
        {
            Console.Clear();
            Console.WriteLine("=== Liste over navne ===");
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

        static void DeleteName()
        {
            ShowNames();
            if (names.Count == 0)
            {
                return;
            }

            Console.Write("Indtast nummeret på det navn, du vil slette: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= names.Count)
            {
                string removedName = names[index - 1];
                names.RemoveAt(index - 1);
                Console.WriteLine($"\"{removedName}\" er blevet slettet.");
            }
            else
            {
                Console.WriteLine("Ugyldigt valg. Prøv igen.");
            }
        }

    }
}

