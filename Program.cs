﻿using System;
using System.Collections.Generic;

namespace ProjektGenspil
{
    class Program
    {
        static void Main()
        {
            Lager lager = new Lager("Brætspil.txt");  // Dette er et lagerobjekt.
            lager.LoadBoardGames();
           
            ForespørgselMenuer.LoadForespørgsel();
            
            while (true)
            {
                Console.Clear(); // Rydder skærmen for en ren menuvisning
                Console.WriteLine("=== Hovedmenu ===\n");
                Console.WriteLine("1. Tilføj brætspil til listen\n");
                Console.WriteLine("2. Vis brætspilsliste\n");
                Console.WriteLine("3. Slet et brætspilsnavn\n");
                Console.WriteLine("4. Til forespørgselsmenuer\n");
                Console.WriteLine("5. Afslut programmet\n");
                Console.Write("Vælg en mulighed: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\nTilføj brætspil");
                        BrætspilMenuer.AddBoardGame(lager);
                        break;
                    case "2":
                        Console.WriteLine("\nVis liste af brætspil");
                        BrætspilMenuer.PrintList(lager);
                        break;
                    case "3":
                        Console.WriteLine("\nSlet brætspil");
                        BrætspilMenuer.DeleteBoardGame(lager);
                        break;
                    case "4":
                        Console.WriteLine("\nForespørgsel menuer.");
                        ForespørgselMenuer.ForespørgselMenu();
                        break;
                    case "5":
                        Console.WriteLine("Farvel!");
                        return; // Afslutter programmet
                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }

                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }


    }
}

