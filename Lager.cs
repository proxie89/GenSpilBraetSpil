using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Lager
    {
        //static List<string> names = new List<string>(); // Liste til at gemme navne
        public static List<Brætspil> BrætspilsListe = new List<Brætspil>();
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

        // SaveBoardGames og LoadBoardGames kunne lægges i en Lager-klasse sammen med brætspilListe.
        public static void SaveBoardGames()
        {
            using (StreamWriter sw = new StreamWriter("Brætspil.txt"))
            {
                foreach (Brætspil brætspil in BrætspilsListe)
                {
                    sw.WriteLine(brætspil.ToString());
                }
            }
        }

        public static void LoadBoardGames()
        {
            string filePath = "Brætspil.txt";
            if (!File.Exists(filePath))
            {
                SaveBoardGames();
            }

            using (StreamReader sr = new StreamReader("Brætspil.txt"))  // Her åbnes tekstfilen Brætspil.txt i den lokale mappe på computeren.
            {
                while (true)
                {
                    string line = sr.ReadLine();  // Her hentes næste linje i tekstfilen.

                    if (line == null)
                    {
                        break;  // Break ud af loopet, når linjen er null (ingen linje).
                    }

                    if (line == "")
                    {
                        continue; // Fortsætter loopet, når der er en linje uden tekst.
                    }

                    Brætspil brætspil = Brætspil.FromString(line);
                    BrætspilsListe.Add(brætspil);
                }
            }  // Her lukkes tekstfilen. Fordi man nu er ude af kodeblokken.
        }
    }
}
