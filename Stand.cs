using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public enum Stand
    {
        Super = 'A',
        God = 'B',
        Rimelig = 'C',
        Ringe = 'D',
        Mangelfuld = 'E',
        Reparation = 'F'    
    }


    //public class Stand
    //{
    //    private char _niveau;
    //    private string _beskrivelse;

    //    public char Niveau
    //    {
    //        get { return _niveau; }
    //        set
    //        {
    //            if (!char.IsWhiteSpace(value) && char.IsLetterOrDigit(value))
    //            {
    //                _niveau = value;
    //            }
    //            else
    //            {
    //                Console.WriteLine("Fejl. Stand skal være et tegn fra A-E.");
    //            }
    //        }
    //    }
    //    public string Beskrivelse { get { return _beskrivelse; } set { _beskrivelse = value; } }

    //    public Stand(char niveau, string beskrivelse)
    //    {
    //        Niveau = niveau;
    //        Beskrivelse = beskrivelse;
    //    }

    //    public static List<Stand> Tilstande =
    //        [
    //            new Stand('A', "Super stand - Næsten som nyt."),
    //            new Stand('B', "God stand - Almindelige brugsspor (mindre ridser/skrammer)."),
    //            new Stand('C', "Rimelig stand - Tydelige brugsspor (flere ridser/skrammer)."),
    //            new Stand('D', "Ringe stand - Meget slidt."),
    //            new Stand('E', "Mangelfuldt - Mangler dele. Kan bruges til reservedele."),
    //        ];

    //}
}
