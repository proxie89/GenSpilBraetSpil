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

        public string Navn { get { return _navn; } set { _navn = value; } }
        public char Stand { get { return _stand; } set { _stand = value; } }
        public int AntalSpillere { get { return _antalSpillere; } set { _antalSpillere = value; } }
        public int AntalPåLager { get  { return _antalPåLager;} set {  _antalPåLager = value; } }
        public int Pris { get { return _pris; } set { _pris = value; } }  
    }

    public class Variabler (string navn, char stand, int antalSpillere, int antalPåLager, int pris)
    {
        this._navn = navn;
        this._stand = stand;
        this._antalSpillere = antalSpillere;
        this._antalPåLager = antalPåLager;
        this._pris = pris;    
       
}

