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
        private int _minAntalSpillere;
        private int _maxAntalSpillere;
        private int _antalPåLager;  // Antal hører måske ikke til her, fordi det vedrører flere brætspil? Jeg sætter den foreløbig til 1.
        private decimal _pris;  // Decimal, fordi det er ti-tals-systemet. Det bruges der til penge, hvor vi runder af til decimaler.
        private Genre _genre;

        public string Navn { get { return _navn; } set { _navn = value; } }
        public Stand Stand { get { return _stand; } set { _stand = value; } }
        public int MinAntalSpillere { get { return _minAntalSpillere; } set { _minAntalSpillere = value; } }
        public int MaxAntalSpillere { get { return _maxAntalSpillere; } set { _maxAntalSpillere = value; } }
        public int AntalPåLager { get { return _antalPåLager; } set { _antalPåLager = value; } }
        public decimal Pris { get { return _pris; } set { _pris = value; } }
        public Genre Genre { get { return _genre; } set { _genre = value; } }

        public Brætspil(string navn, Stand stand, int minAntalSpillere, int maxAntalSpillere, int antalPåLager, decimal pris, Genre genre)
        {
            _navn = navn;
            _stand = stand;
            _minAntalSpillere = minAntalSpillere;
            _maxAntalSpillere = maxAntalSpillere;
            _antalPåLager = antalPåLager;
            _pris = pris;
            _genre = genre;
        }
                
        public override string ToString()
        {

            return  Navn + "|" + (char)Stand + "|" + MinAntalSpillere + "|" + MaxAntalSpillere + "|" + AntalPåLager + "|" + Pris + "|" + Genre;

        }

        public string ToPrettyString()
        {

            return Navn.PadRight(40) + " |   " + (char)Stand + "   |   " + MinAntalSpillere + " - " + MaxAntalSpillere + "   |   " + AntalPåLager + "   |   " + Pris.ToString().PadRight(7) + " | " + Genre;

        }

        public static Brætspil FromString(string line)
        {
            string[] lineParts = line.Split("|");  // Her splittes linjen i tekstfilen op i 7 dele.

            string navn = lineParts[0];
            Stand stand = BrætspilMenuer.ParseStand(char.Parse(lineParts[1]));
            int minAntalSpillere = int.Parse(lineParts[2]);
            int maxAntalSpillere = int.Parse(lineParts[3]);
            int antalPåLager = int.Parse(lineParts[4]);
            decimal pris = decimal.Parse(lineParts[5]);
            Genre genre = BrætspilMenuer.ParseGenre(lineParts[6]);  // Laves på samme måde som GetNiveauForStand.

            Brætspil brætspil = new Brætspil(navn, stand, minAntalSpillere, maxAntalSpillere, antalPåLager, pris, genre);  // Her laves et brætspilsobjekt ud fra de 3 dele.
            return brætspil;
        }
    }
}
