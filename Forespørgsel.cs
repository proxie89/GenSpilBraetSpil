using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    internal class Forespørgsel
    {
        public int Id { get; private set; }
        public string Kundenavn { get; private set; }
        public int Tlf { get; private set; }
        public string Brætspil { get; private set; }

        public string FilePathforespørgsel { get; set; } = "Forespørgsel.txt";


        // Opret konstruktør
        public Forespørgsel(int _id, string _kundenavn, int _tlf, string _brætspil)
        {
            Id = _id;
            Kundenavn = _kundenavn;
            Tlf = _tlf;
            Brætspil = _brætspil;
            // Sæt brætspils navn ind, så man kan søge på den. 

        }
        
        public static List<Forespørgsel> forespørgsel = new List<Forespørgsel>(); //Til forespørgsler

        public Forespørgsel(string filePathforespørgsel)   // Konstruktør placeres typisk mellem felterne ovenover og metoder nedenunder.
        {
            FilePathforespørgsel = filePathforespørgsel; // Sætter filstien ved oprettelse af DataHandler
        }


        //public string FilePathForespørgsel { get; set; } = "Forespørgsel.txt";


        public override string ToString()
        {
            return Id + " | " + Kundenavn + " | " + Tlf + " | " + Brætspil;
        }

        public static Forespørgsel FromString(string line)
        {
            string[] lineParts = line.Split(" | ");

            int _id = int.Parse(lineParts[0]);
            string _kundenavn = lineParts[1];
            int _tlf = int.Parse(lineParts[2]);
            string _brætspil = lineParts[3];

            Forespørgsel _forespørgsel = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
            return _forespørgsel;
        }
        public void GemForespørgsel()
        {
            using (StreamWriter sw = new StreamWriter(FilePathforespørgsel))
            {
                foreach (Forespørgsel forespørgsel in forespørgsel)
                {
                    sw.WriteLine(forespørgsel.ToString());
                }
            }
        }

        public void LoadForespørgsel(string FilePathforespørgsel)
        {
            
            if (!File.Exists(FilePathforespørgsel))
            {
                GemForespørgsel();
            }
            using (StreamReader sr = new StreamReader(FilePathforespørgsel))
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
                        continue;
                    }

                    if (line == "")
                    {
                        continue; // Fortsætter loopet, når der er en linje uden tekst.
                    }

                    Forespørgsel _forespørgsel = Forespørgsel.FromString(line);
                    forespørgsel.Add(_forespørgsel);
                }
            }
        }

        
    }

}
