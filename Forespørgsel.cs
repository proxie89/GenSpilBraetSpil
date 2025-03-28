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


        }
    }
}
