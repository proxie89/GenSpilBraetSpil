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

        public string Navn { get; set; }
        public Stand Stand { get; set; }
        public int MinAntalSpillere { get; set; }
        public int MaxAntalSpillere { get; set; }
        public int AntalPåLager { get; set; }
        public decimal Pris { get; set; }
        public Genre Genre { get; set; }

        public Brætspil(string _navn, Stand _stand, int _minAntalSpillere, int _maxAntalSpillere, int _antalPåLager, decimal _pris, Genre _genre)
        {
            Navn = _navn;
            Stand = _stand;
            MinAntalSpillere = _minAntalSpillere;
            MaxAntalSpillere = _maxAntalSpillere;
            AntalPåLager = _antalPåLager;
            Pris = _pris;
            Genre = _genre;
        }
                
        public override string ToString()
        {

            return  Navn + "|" + (char)Stand + "|" + MinAntalSpillere + "|" + MaxAntalSpillere + "|" + AntalPåLager + "|" + Pris + "|" + Genre;

        }

        public string ToPrettyString()
        {

            return Navn.PadRight(40) + "   |  " + (char)Stand + "  |   " + MinAntalSpillere + " - " + MaxAntalSpillere + "   |   " + AntalPåLager + "   |   " + Pris.ToString().PadRight(7) + " | " + Genre;

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

    public enum Stand
    {
        Super = 'A',
        God = 'B',
        Rimelig = 'C',
        Ringe = 'D',
        Mangelfuld = 'E',
        Reparation = 'F'
    }

    public enum Genre
    {
        Familiespil,
        Selskabsspil,
        Strategispil,
        Voksenspil,
        Børnespil
    }
}
