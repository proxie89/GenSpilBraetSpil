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
        private static List<Brætspil> brætspilsListe = new List<Brætspil>();
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
                Console.Write("Indtast navn på Brætspil: ");
                string navn = Console.ReadLine();

                Console.WriteLine("Indtast hvilken stand brætspillet er i. Vælg et af følgende bogstaver:\n");

                for (int j = 0; j < Tilstande.Count(); j++)
                {
                    Console.WriteLine($"{Tilstande[j].Niveau} - {Tilstande[j].Beskrivelse}\n");
                }
                char niveau = char.Parse(Console.ReadLine().ToUpper());
                                
                Stand stand = GetNiveauForStand(niveau) ?? Tilstande[0]; // ændret flow control til at være mere readable

                Console.Write("Indtast antal spillere for dette spil: ");
                string antalSpillere = Console.ReadLine();
                int antalPåLager = 1;

                Console.Write("Sæt prisen på brætspillet (vurderes ud fra spillets tilstand): ");
                decimal pris = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Indtast hvilken genre brætspillet hører til. Vælg det som det som passer bedst:\n");

                for (int j = 0; j < Genrer.Count(); j++)
                {
                    Console.WriteLine($"{j} - {Genrer[j].Navn}\n");
                }
                int nummer = int.Parse(Console.ReadLine());
                Genre genre = Genrer.ElementAtOrDefault(nummer) ?? Genrer[0]; // ændret flow control til at være mere readable


                Brætspil spil = new Brætspil(navn, stand, antalSpillere, antalPåLager, pris, genre);
                brætspilsListe.Add(spil);
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
            if (brætspilsListe.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                foreach (Brætspil brætspil in brætspilsListe)
                {
                    //Console.WriteLine(brætspil.Navn);
                    //Console.WriteLine(brætspil.Stand);
                    Console.WriteLine(brætspil.ToString());
                }
            }
        }



        public static void DeleteBoardGame()
        {

            Console.Clear();
            Console.WriteLine("Liste over brætspil:");

            if (brætspilsListe.Count == 0)
            {
                Console.WriteLine("Ingen brætspil i listen!");
                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
                return;
            }

            
            for (int i = 0; i < brætspilsListe.Count; i++)
            {
                var game = brætspilsListe[i];
                Console.WriteLine($"[{i + 1}] {game.ToString()}");
            }

            Console.WriteLine("\nIndtast indeksnummeret på det brætspil, du vil slette: ");
            string input = Console.ReadLine();

            try
            {
                int index = int.Parse(input); 
                if (index >= 1 && index <= brætspilsListe.Count) 
                {
                    int zeroBasedIndex = index - 1; 
                    string deletedName = brætspilsListe[zeroBasedIndex].Navn;
                    brætspilsListe.RemoveAt(zeroBasedIndex);
                    Console.WriteLine($"\"{deletedName}\" er slettet fra listen.");
                }
                else
                {
                    Console.WriteLine("Ugyldigt indeksnummer! Indtast et nummer mellem 1 og " + brætspilsListe.Count + ".");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Fejl: Du skal indtaste et heltal (f.eks. 1, 2, 3).");
            }
            catch (Exception ex)
            {
                Console.WriteLine("En uventet fejl opstod: " + ex.Message);
            }

            Console.WriteLine("Tryk på en tast for at fortsætte...");
            Console.ReadKey();
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
                foreach (Brætspil brætspil in brætspilsListe)
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
                    brætspilsListe.Add(brætspil);
                }
            }  // Her lukkes tekstfilen. Fordi man nu er ude af kodeblokken.
        }
    }
}
