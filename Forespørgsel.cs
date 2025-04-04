using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        // Opret konstruktør
        public Forespørgsel(int _id, string _kundenavn, int _tlf, string _brætspil)
        {
            Id = _id;
            Kundenavn = _kundenavn;
            Tlf = _tlf;
            Brætspil = _brætspil;
            // Sæt brætspils navn ind, så man kan søge på den. 

        }

        public override string ToString()
        {
            return Id.ToString().PadRight(5) + " | " + Kundenavn + " | " + Tlf.ToString().PadRight(30) + " | " + Brætspil;
        }
        public string FilePathForespørgsel { get; set; } = "Forespørgsel.txt";
        public static List<Forespørgsel> forespørgselliste = new List<Forespørgsel>(); //Til forespørgsler

        
        /*
        public Forespørgsel FromString(string line)
        {
            string[] lineParts = line.Split(" | ");

            int _id = int.Parse(lineParts[0]);
            string _kundenavn = lineParts[1];
            int _tlf = int.Parse(lineParts[2]);
            string _brætspil = lineParts[3];

            Forespørgsel forespørgsels = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
            return forespørgsels;
        }
        */

        public Forespørgsel(string filePathForespørgsel)
        {
            FilePathForespørgsel = filePathForespørgsel;
        }

        public static void GemForespørgsel()
        {
            using (StreamWriter sw = new StreamWriter(FilePathForespørgsel))
            {
                foreach (Forespørgsel forespørgselsliste in forespørgselliste)
                {
                    sw.WriteLine(forespørgselliste.ToString());
                }
            }
        }

        public static void LoadForespørgsel()
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
                        continue;
                    }

                    if (line == "")
                    {
                        continue; // Fortsætter loopet, når der er en linje uden tekst.
                    }

                    Forespørgsel forespørgsels = Forespørgsel.FromString(line);
                    forespørgselliste.Add(forespørgsels);
                }
            }
          
        }
        /*
        public override string ToString()
        {
            return Id.ToString().PadRight(5) + " | " + Kundenavn + " | " + Tlf.ToString().PadRight(30) + " | " + Brætspil;
        }
        */

        public static Forespørgsel FromString(string line)
        {
            string[] lineParts = line.Split(" | ");
            int _id = int.Parse(lineParts[0]);
            string _kundenavn = lineParts[1];
            int _tlf = int.Parse(lineParts[2]);
            string _brætspil = lineParts[3];

            Forespørgsel forespørgselsliste = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
            return forespørgselsliste;
        }

    }

}
