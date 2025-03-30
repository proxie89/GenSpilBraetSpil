using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektGenspil
{
    public class Brætspil
    {
        private string _navn;
        private Stand _stand;
        private string _antalSpillere;  // Ændret fra int til string, fordi man nogle gange skriver f.eks.: 2-6 spillere. Så dækker den bredere.
        private int _antalPåLager;  // Antal hører måske ikke til her, fordi det vedrører flere brætspil? Jeg sætter den foreløbig til 1.
        private decimal _pris;  // Decimal, fordi det er ti-tals-systemet. Det bruges der til penge, hvor vi runder af til decimaler.
        private Genre _genre;

        public string Navn 
        { 
            get { return _navn; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _navn = value; 
                }
                else
                {
                    Console.WriteLine("Navnet kan ikke være tomt.");
                }
            } 
        }
        public Stand Stand 
        { 
            get { return _stand; } 
            set 
            { 
                _stand = value; 
            } 
        }
        public string AntalSpillere { get { return _antalSpillere; } set { _antalSpillere = value; } }
        public int AntalPåLager { get { return _antalPåLager; } set { _antalPåLager = value; } }
        public decimal Pris { get { return _pris; } set { _pris = value; } }
        public Genre Genre { get { return _genre; } set { _genre = value; } }

        public Brætspil() { }
        public Brætspil(string navn, Stand stand, string antalSpillere, int antalPåLager, decimal pris, Genre genre)
        {
            _navn = navn;
            _stand = stand;
            _antalSpillere = antalSpillere;
            _antalPåLager = antalPåLager;
            _pris = pris;
            _genre = genre;
        }

        /* Vi vil have en funktion ToString. 
         * Den skal kunne tilgås udefra, så public.
         * Man skal bruge override, fordi man skal overskrive den indbyggede funktion.
         */

        public override string ToString()
        {
            return Navn + " | " + Stand.Niveau + " | " + AntalSpillere + " | " + AntalPåLager + " | " + Pris + " | " + Genre.Navn;
        }
    }
}
