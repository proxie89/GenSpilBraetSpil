using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class DataLager
    {
        public string FilePathBrætspil { get; set; } = "Brætspil.txt";// Sti til filen, der gemmer data
        public string FilePathForespørgsel { get; set; } = "Forespørgsler.txt";// Sti til filen, der gemmer data

        public List<Brætspil> BrætspilsListe = new List<Brætspil>();
        public  List<Forespørgsel> ForespørgselsListe = new List<Forespørgsel>(); //Til forespørgsler

        public DataLager(string filePathBrætspil, string filePathForespørgsel)   // Konstruktør placeres typisk mellem felterne ovenover og metoder nedenunder.
        {
            FilePathBrætspil = filePathBrætspil; // Sætter filstien ved oprettelse af DataHandler
            FilePathForespørgsel = filePathForespørgsel;
        }
        
        public void SaveBoardGames()
        {
            using (StreamWriter sw = new StreamWriter(FilePathBrætspil))  // FilePathBrætspil er ikke static, så den hører til et objekt.
            {
                foreach (Brætspil brætspil in BrætspilsListe)
                {
                    sw.WriteLine(brætspil.ToString());
                }
            }
        }

        public void LoadBoardGames()
        {
            if (!File.Exists(FilePathBrætspil))
            {
                SaveBoardGames();
            }

            using (StreamReader sr = new StreamReader(FilePathBrætspil))  // Her åbnes tekstfilen Brætspil.txt i den lokale mappe på computeren.
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

        public void GemForespørgsel()
        {
            using (StreamWriter sw = new StreamWriter(FilePathForespørgsel))
            {
                foreach (Forespørgsel forespørgsel in ForespørgselsListe)
                {
                    sw.WriteLine(forespørgsel.ToString());
                }
            }
        }

        public void LoadForespørgsel()
        {

            if (!File.Exists(FilePathForespørgsel))
            {
                GemForespørgsel();
            }
            using (StreamReader sr = new StreamReader(FilePathForespørgsel))
            {
                while (true)
                {
                    string line = sr.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                   
                    if (line == "")
                    {
                        continue; // Fortsætter loopet, når der er en linje uden tekst.
                    }

                    Forespørgsel _forespørgsel = Forespørgsel.FromString(line);
                    ForespørgselsListe.Add(_forespørgsel);
                }
            }
        }
    }
}
