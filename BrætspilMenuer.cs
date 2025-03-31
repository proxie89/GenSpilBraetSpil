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
        static List<Brætspil> brætspilsliste = new List<Brætspil>();
        public static List<Stand> Tilstande =
            [
                new Stand('A', "Super stand - Næsten som nyt."),
                new Stand('B', "God stand - Almindelige brugsspor (mindre ridser/skrammer)."),
                new Stand('C', "Rimelig stand - Tydelige brugsspor (flere ridser/skrammer)."),
                new Stand('D', "Ringe stand - Meget slidt."),
                new Stand('E', "Mangelfuldt - Mangler dele. Kan bruges til reservedele."),
            ];
        public static List<Genre> Genrer =
           [
                new Genre("Familiespil"),
                new Genre("Selskabspil"),
                new Genre("Strategispil"),
                new Genre("Voksenspil"),
            ];
        public static void AddBoardGame()
        {
            Console.Clear();

            Console.WriteLine("Hvor mange brætspil vil du indtaste?");
            int antalSpil = int.Parse(Console.ReadLine());
            for (int i = 0; i < antalSpil; i++)
            {
                Brætspil spil = new Brætspil();

                Console.Write("Indtast navn på Brætspil: ");
                spil.Navn = Console.ReadLine();

                Console.WriteLine("Indtast hvilken stand brætspillet er i. Vælg et af følgende bogstaver:\n");

                for (int j = 0; j < Tilstande.Count(); j++)
                {
                    Console.WriteLine($"{Tilstande[j].Niveau} - {Tilstande[j].Beskrivelse}\n");
                }
                char niveau = char.Parse(Console.ReadLine().ToUpper());

                spil.Stand = GetNiveauForStand(niveau);

                if (spil.Stand == null)
                {
                    spil.Stand = Tilstande[0];
                }

                Console.Write("Indtast antal spillere for dette spil: ");
                spil.AntalSpillere = Console.ReadLine();
                spil.AntalPåLager = 1;

                Console.Write("Sæt prisen på brætspillet (vurderes ud fra spillets tilstand): ");
                spil.Pris = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Indtast hvilken genre brætspillet hører til. Vælg det som det som passer bedst:\n");

                for (int j = 0; j < Genrer.Count(); j++)
                {
                    Console.WriteLine($"{j} - {Genrer[j].Navn}\n");
                }
                int nummer = int.Parse(Console.ReadLine());
                spil.Genre = Genrer.ElementAtOrDefault(nummer);
                if (spil.Genre == null)
                {
                    spil.Genre = Genrer[0];
                }

                brætspilsliste.Add(spil);
                Console.WriteLine($"\"{spil.Navn}\" er tilføjet til listen og gemt.");
            }

            SaveBoardGames();
        }

        public static Stand GetNiveauForStand(char niveau)
        {
            for (int i = 0; i < Tilstande.Count(); i++)
            {
                if (Tilstande[i].Niveau == niveau)
                {
                    return Tilstande[i];
                }
            }
            return null;
        }

        public static Genre GetNavnForGenre(string navn)
        {
            for (int i = 0; i < Genrer.Count(); i++)
            {
                if (Genrer[i].Navn == navn)
                {
                    return Genrer[i];
                }
            }
            return null;
        }

        public static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("=== Liste over navne ===\n");
            if (brætspilsliste.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                foreach (Brætspil brætspil in brætspilsliste)
                {
                    //Console.WriteLine(brætspil.Navn);
                    //Console.WriteLine(brætspil.Stand);
                    Console.WriteLine(brætspil.ToString());
                }
            }
        }

        public static void DeleteBoardGame(List<Brætspil> brætspilListe)
        {
            Console.WriteLine("Vælg navn på det brætspil du vil slette: ");
            string name = Console.ReadLine();

            Brætspil brætSpilSlettes = null;
            foreach (var brætspilListes in brætspilListe)
            {
                if (brætspilListes._navn == name)
                {
                    brætSpilSlettes = brætspilListes;

                    break;
                }
            }
            if (brætSpilSlettes != null)
            {
                brætspilListe.Remove(brætSpilSlettes);
                Console.WriteLine($"{name} er slettet");
            } 
            else
            {
                Console.WriteLine("Brætspil ikke fundet!");
            }
        }
        
        

        // SaveBoardGames og LoadBoardGames kunne lægges i en Lager-klasse sammen med brætspilListe.
        public static void SaveBoardGames()
        {
            /* LoadBoardGames er sat ind for at undgå, at linjen i filen overskrives med det nye brætspil. 
             * Dog sker der det, at hvis man tilføjer et brætspil mere, så kommer der dobbelt antal
             * fordi den loader igen. Ved ikke, hvilken løsning man hellere skal vælge?
             */
            using (StreamWriter sw = new StreamWriter("Brætspil.txt"))
            {
                foreach (Brætspil brætspil in brætspilsliste)
                {
                    sw.WriteLine(brætspil.ToString());
                }
            }
        }

        public static void LoadBoardGames()
        {
            using (StreamReader sr = new StreamReader("Brætspil.txt"))  // Her åbnes tekstfilen Brætspil.txt i den lokale mappe på computeren.
            {
                while (true)
                {
                    string line = sr.ReadLine();  // Her hentes næste linje i tekstfilen.

                    if (line == null || line == "")
                    {
                        break;  // Break ud af loopet, når linjen er null (ingen linje).
                    }

                    Brætspil brætspil = Brætspil.FromString(line);
                    brætspilsliste.Add(brætspil);
                }
            }  // Her lukkes tekstfilen. Fordi man nu er ude af kodeblokken.
        }
    }
}
