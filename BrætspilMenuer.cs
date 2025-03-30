using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    internal class BrætspilMenuer
    {
        //static List<string> names = new List<string>(); // Liste til at gemme navne
        static List<Brætspil> brætspilListe = new List<Brætspil>();
        static List<Stand> tilstande =
            [
                new Stand('A', "Super stand - Næsten som nyt."),
                new Stand('B', "God stand - Almindelige brugsspor (mindre ridser/skrammer)."),
                new Stand('C', "Rimelig stand - Tydelige brugsspor (flere ridser/skrammer)."),
                new Stand('D', "Ringe stand - Meget slidt."),
                new Stand('E', "Mangelfuldt - Mangler dele. Kan bruges til reservedele."),
            ];
        static List<Genre> genrer =
           [
                new Genre("Familiespil"),
                new Genre("Selskabspil"),
                new Genre("Strategispil"),
                new Genre("Voksenspil"),
            ];
        public static void AddBoardGame()
        {
            Brætspil spil = new Brætspil();
            Console.Clear();

            Console.Write("Indtast navn på Brætspil: ");
            spil.Navn = Console.ReadLine();

            Console.WriteLine("Indtast hvilken stand brætspillet er i. Vælg et af følgende bogstaver:\n");

            for (int i = 0; i < tilstande.Count(); i++)
            {
                Console.WriteLine($"{tilstande[i].Niveau} - {tilstande[i].Beskrivelse}\n");
            }
            char niveau = char.Parse(Console.ReadLine());
            for (int i = 0; i < tilstande.Count(); i++)
            {
                if (tilstande[i].Niveau == niveau)
                {
                    spil.Stand = tilstande[i];
                    break;
                }
            }
            if (spil.Stand == null)
            {
                spil.Stand = tilstande[0];
            }

            Console.Write("Indtast antal spillere for dette spil: ");
            spil.AntalSpillere = Console.ReadLine();
            spil.AntalPåLager = 1;

            Console.Write("Sæt prisen på brætspillet (vurderes ud fra spillets tilstand): ");
            spil.Pris = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Indtast hvilken genre brætspillet hører til. Vælg det som det som passer bedst:\n");

            for (int i = 0; i < genrer.Count(); i++)
            {
                Console.WriteLine($"{i} - {genrer[i].Navn}\n");
            }
            int nummer = int.Parse(Console.ReadLine());
            spil.Genre = genrer.ElementAtOrDefault(nummer);
            if (spil.Genre == null)
            {
                spil.Genre = genrer[0];
            }

            brætspilListe.Add(spil);
            SaveBoardGames();
            Console.WriteLine($"\"{spil.Navn}\" er tilføjet til listen og gemt.");

            //Console.Clear();
            //Console.Write("Indtast navn på brætspil: ");
            //string name = Console.ReadLine();
            //if (!string.IsNullOrWhiteSpace(name))
            //{
            //    names.Add(name);
            //    Console.WriteLine($"\"{name}\" er tilføjet til listen.");
            //}
            //else
            //{
            //    Console.WriteLine("Navnet kan ikke være tomt.");
            //}
        }

        public static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("=== Liste over navne ===\n");
            if (brætspilListe.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                foreach (Brætspil brætspil in brætspilListe)
                {
                    //Console.WriteLine(brætspil.Navn);
                    //Console.WriteLine(brætspil.Stand);
                    Console.WriteLine(brætspil.ToString());
                }
            }
        }

        public static void DeleteBoardGame()
        {
            PrintList();
            if (brætspilListe.Count == 0)
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

        public static void SaveBoardGames()
        {
            using (StreamWriter sw = new StreamWriter("Brætspil.txt"))
            {
                foreach (Brætspil brætspil in brætspilListe) 
                { 
                    sw.WriteLine(brætspil.ToString() );
                }
            } 
        }
    }
}
