using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Stand
    {
        private char _niveau;
        private string _beskrivelse;

        public char Niveau 
        { 
            get { return _niveau; } 
            set 
            {
                if (!char.IsWhiteSpace(value) && char.IsLetterOrDigit(value))
                {
                    _niveau = value;
                }
                else 
                {
                    Console.WriteLine("Fejl. Stand skal være et tegn fra A-E.");
                }
            } 
        }
        public string Beskrivelse { get { return _beskrivelse; } set { _beskrivelse = value; } }

        public Stand(char niveau, string beskrivelse) 
        {
            Niveau = niveau;
            Beskrivelse = beskrivelse;
        }
    }
}
