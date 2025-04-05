using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    internal class BrætspilMenuer
    {
       
        public static void AddBoardGame(Lager lager)
        {
            Console.Clear();

            Console.WriteLine("Hvor mange brætspil vil du indtaste?");
            int antalSpil = int.Parse(Console.ReadLine());
            for (int i = 0; i < antalSpil; i++)
            {
                Console.Write("Indtast navn på Brætspil: ");
                string navn = Console.ReadLine();

                Console.WriteLine("Indtast hvilken stand brætspillet er i. Vælg et af følgende bogstaver:\n");
                Stand[] tilstande = Enum.GetValues<Stand>();
                for (int j = 0; j < tilstande.Length; j++)   // length er en property og kan bruges til array (count er en metode)
                {
                    Console.WriteLine($"{(char)tilstande[j]} - {tilstande[j]}\n");
                }
                char niveau = char.Parse(Console.ReadLine().ToUpper());

                Stand stand = ParseStand(niveau);

                Console.Write("Indtast mindste antal spillere for dette spil: ");
                int minAntalSpillere = int.Parse(Console.ReadLine());

                Console.Write("Indtast højeste antal spillere for dette spil: ");
                int maxAntalSpillere = int.Parse(Console.ReadLine());

                int antalPåLager = 1;

                Console.Write("Sæt prisen på brætspillet (vurderes ud fra spillets tilstand): ");
                decimal pris = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Indtast hvilken genre brætspillet hører til. Vælg det som det som passer bedst:\n");
                Genre[] genrer = Enum.GetValues<Genre>();
                for (int j = 0; j < genrer.Length; j++)
                {
                    Console.WriteLine($"{j + 1} - {genrer[j]}\n");
                }
                int nummer = int.Parse(Console.ReadLine());
                Genre genre = genrer.ElementAtOrDefault(nummer - 1); 

                Brætspil spil = new Brætspil(navn, stand, minAntalSpillere, maxAntalSpillere, antalPåLager, pris, genre);
                lager.BrætspilsListe.Add(spil);
                Console.WriteLine($"\"{spil.Navn}\" er tilføjet til listen og gemt.");
            }

            lager.SaveBoardGames();
        }



        public static Stand ParseStand(char niveau)
        {
            return (Stand)niveau.ToString().ToUpper()[0];  //Todo: Check, at det er en gyldig stand.
        }

        public static Genre ParseGenre(string navn)
        {
            return Enum.Parse<Genre>(navn);
        }

        public static void PrintList(Lager lager)
        {
            string indexPrintList = "".PadRight(4);
            string titelPrintList = "Navn".PadRight(43);
            string standPrintList = "Stand".PadRight(8);
            string antalSpillerePrintList1 = "#".PadRight(2);
            string antalSpillerePrintList2 = "Spillere".PadRight(10); 
            string antalPåLagerPrintList = "Lager".PadRight(9);
            string prisPrintList = "Pris".PadRight(13);
            string genrePrintList = "Genre".PadRight(20);

            Console.Clear();
            Console.Write("=== Liste over navne ===\n");
            Console.WriteLine($"{indexPrintList}{titelPrintList}{standPrintList}{antalSpillerePrintList1}{antalSpillerePrintList2}{antalPåLagerPrintList}{prisPrintList}{genrePrintList}");
            
            if (lager.BrætspilsListe.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                for (int i = 0; i < lager.BrætspilsListe.Count; i++)
                {
                    var brætspil = lager.BrætspilsListe[i];
                    Console.WriteLine($"[{i + 1}] {brætspil.ToPrettyString()}");
                }
            }
        }

        public static void DeleteBoardGame(Lager lager) 
        {
            string indexPrintList = "".PadRight(4);
            string titelPrintList = "Navn".PadRight(43);
            string standPrintList = "Stand".PadRight(8);
            string antalSpillerePrintList1 = "#".PadRight(2);
            string antalSpillerePrintList2 = "Spillere".PadRight(10);
            string antalPåLagerPrintList = "Lager".PadRight(9);
            string prisPrintList = "Pris".PadRight(13);
            string genrePrintList = "Genre".PadRight(20);

            Console.Clear();
            Console.WriteLine("=== Liste over brætspil ===");
            Console.WriteLine($"{indexPrintList}{titelPrintList}{standPrintList}{antalSpillerePrintList1}{antalSpillerePrintList2}{antalPåLagerPrintList}{prisPrintList}{genrePrintList}");


            if (lager.BrætspilsListe.Count == 0)
            {
                Console.WriteLine("Ingen brætspil i listen!");
                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < lager.BrætspilsListe.Count; i++)
            {
                var game = lager.BrætspilsListe[i];
                Console.WriteLine($"[{i + 1}] {game.ToPrettyString()}");
            }

            Console.WriteLine("\nIndtast indeksnummeret på det brætspil, du vil slette: ");
            string input = Console.ReadLine();
           
            int index = int.Parse(input);
            int zeroBasedIndex = index - 1;
            string deletedName = lager.BrætspilsListe[zeroBasedIndex].Navn;

            Console.WriteLine($"Er du sikker på du vil slette {deletedName}? Skriv ja eller nej:");
            string confirmInput = Console.ReadLine().ToUpper();

            if (confirmInput == "JA")

                try
                {
                
                    if (index >= 1 && index <= lager.BrætspilsListe.Count) 
                    {
                    
                        lager.BrætspilsListe.RemoveAt(zeroBasedIndex);
                        {

                        using (StreamWriter swSlet = new StreamWriter("Brætspil.txt", false))

                            foreach (var game in lager.BrætspilsListe)
                            {
                                swSlet.WriteLine(game.ToString());
                            }

                            Console.WriteLine($"\"{deletedName}\" er slettet fra listen.");
                        }

                   
                        }
                    else
                        {
                        Console.WriteLine("Ugyldigt indeksnummer! Indtast et nummer mellem 1 og " + lager.BrætspilsListe.Count + ".");
                        }
                }
                catch (FormatException)
                    {
                        Console.WriteLine("Fejl: Du skal indtaste et heltal (f.eks. 1, 2, 3).");
                    }
                        
             else
             {
                Console.WriteLine($"Du valgte Nej til at slette. {deletedName} blev ikke slettet!");
             }
        }
    }
}
