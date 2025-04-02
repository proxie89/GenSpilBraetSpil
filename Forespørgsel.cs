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
            return Id + " | " + Kundenavn + " | " + Tlf + " | " + Brætspil;
        }

        public static Forespørgsel FromString(string line)
        {
            string[] lineParts = line.Split(" | ");

            int _id = int.Parse(lineParts[0]);
            string _kundenavn = lineParts[1];
            int _tlf = int.Parse(lineParts[2]);
            string _brætspil = lineParts[3];

            Forespørgsel forespørgsels = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
            return forespørgsels;
        }

    }

}
