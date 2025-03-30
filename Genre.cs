using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Genre
    {
        /*Brætspil kan inddeles i fem kategorier: 
         * kapløbsspil (fx ludo og backgammon), 
         * jagtspil (rævespil og hund-efter-hare), 
         * strategispil (skak, dam, go og reversi (othello)), 
         * positionsspil (tre på stribe, mølle og halma) og
         * mancalaspil (kalaha og mancala).
         * 
         * Eller:
         *
         * Familiespil
         * Selskabsspil
         * Strategispil
         * Voksenspil
         * 
         * Et spil kan tilhøre flere Genrer...
         */
        private string _navn;

        public string Navn { get { return _navn; } set { _navn = value; } }

        public Genre(string navn)
        {
            _navn = navn;
        }
    }
}
