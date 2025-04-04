using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Genre
    {
        
        private string _navn;

        public string Navn { get { return _navn; } set { _navn = value; } }

        public Genre(string navn)
        {
            _navn = navn;
        }
    }
}
