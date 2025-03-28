using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class brætspil
    {
        private string _navn;
        private char _stand;
        private int _antalSpillere;
        private int _antalPåLager;
        private int _pris;
        private string _genre;

        public string navn { get { return _navn; } set { _navn = value; } }
        public char stand { get { return _stand; } set { _stand = value; } }
        public int antalSpillere { get { return _antalSpillere; } set { _antalSpillere = value; } }
        public int antalPåLager { get { return _antalPåLager; } set { _antalPåLager = value; } }
        public int pris { get { return _pris; } set { _pris = value; } }
        public string genre { get { return _genre; } set { _genre = value; } }


        public brætspil(string navn, char stand, int antalSpillere, int antalPåLager, int pris, string genre)
        {
            _navn = navn;
            _stand = stand;
            _antalSpillere = antalSpillere;
            _antalPåLager = antalPåLager;
            _pris = pris;
            _genre = genre;
        }
    }
}
