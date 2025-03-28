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

        public char Niveau { get { return _niveau; } set { _niveau = value; } }
        public string Beskrivelse { get { return _beskrivelse; } set { _beskrivelse = value; } }
    }
}
