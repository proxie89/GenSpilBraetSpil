using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Forespørgsel
    {
        public int Id { get; private set; }
        public string Kundenavn { get; private set; }
        public int Tlf { get; private set; }
        public string Brætspil { get; private set; }

        public string FilePathforespørgsel { get; set; } = "Forespørgsler.txt";


        // Opret konstruktør
        public Forespørgsel(int _id, string _kundenavn, int _tlf, string _brætspil)
        {
            Id = _id;
            Kundenavn = _kundenavn;
            Tlf = _tlf;
            Brætspil = _brætspil;
            // Sæt brætspils navn ind, så man kan søge på den. 

        }

        //public Forespørgsel(string filePathforespørgsel)   // Konstruktør placeres typisk mellem felterne ovenover og metoder nedenunder.
        //{
        //    FilePathforespørgsel = filePathforespørgsel; // Sætter filstien ved oprettelse af DataHandler
        //}

        //public string FilePathForespørgsel { get; set; } = "Forespørgsel.txt";


        public override string ToString()
        {
            return Id + " | " + Kundenavn + " | " + Tlf + " | " + Brætspil;
        }

        public string fToPrettyString()
        {
            return Id.ToString().PadRight(0) + " | " + Kundenavn.PadRight(20) + " | " + Tlf.ToString().PadRight(20) + " | " + Brætspil;
        }

        public static Forespørgsel FromString(string line)
        {
            string[] lineParts = line.Split(" | ");

            int _id = int.Parse(lineParts[0]);
            string _kundenavn = lineParts[1];
            int _tlf = int.Parse(lineParts[2]);
            string _brætspil = lineParts[3];

            Forespørgsel _forespørgsel = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
            return _forespørgsel;
        }


        public static void AddForspørgsel(DataLager lager) //Tilføj en Forespørgsel. Skal tildeles et ID
        {
            Console.Clear();

            Console.WriteLine("Hvor mange forespørgsler vil du indtaste?");
            int antalFor = int.Parse(Console.ReadLine());
            for (int i = 0; i < antalFor; i++)
            {
                Console.WriteLine("Hvilket spil vil kunden gerne oprette forespørgsel på?");
                string _brætspil = Console.ReadLine();

                foreach(var item in lager.BrætspilsListe)
                {
                    if (lager.BrætspilsListe.Any(x => x.Navn == _brætspil))
                    {
                        Console.WriteLine("Der findes allerede et brætspil med dette navn på lager!!!"); ;
                    }

                }

                Console.WriteLine("Indtast kundens navn");
                string _kundenavn = Console.ReadLine();

                Console.WriteLine("Indtast kundens telefonnummer");
                int _tlf = int.Parse(Console.ReadLine());

                // Forespørgselsnummer skal nok være et for loop, hvor i = 1, og herefter adder den til hver gang et nummer bliver oprettet
                Console.WriteLine("Indtast forespørgsels ID" + (i + 1) + ": ");
                int _id = int.Parse(Console.ReadLine());

                Forespørgsel forespørgsel = new Forespørgsel(_id, _kundenavn, _tlf, _brætspil);
                lager.ForespørgselsListe.Add(forespørgsel);
                Console.WriteLine($"Forespørgsel {_id} blev oprettet.\nSpil: {_brætspil}\nNavn: {_kundenavn}\nTlf: {_tlf}\n");
                //Forespørgsel.ForespørgselsListe.Add(new Forespørgsel(_id, _kundenavn, _tlf, _brætspil));
                //Console.WriteLine($"Forespørgsel {_id} blev oprettet.\nSpil: {_brætspil}\nNavn: {_kundenavn}\nTlf: {_tlf}\n");

            }

            lager.GemForespørgsel();
        }

        public static void SeListe(DataLager lager)
        {
            string fIDPrintList = "".PadRight(7);
            string fNAVNPrintList = "Navn".PadRight(24);
            string fTLFPrintList = "TLF".PadRight(22);
            string fBRÆTSPILPrintList = "Brætspil".PadRight(22);

            // Udskriv liste med forespørgsler
            Console.Clear();
            Console.WriteLine("=== Liste over forspørgsler ===");
            Console.WriteLine($"{fIDPrintList}{fNAVNPrintList}{fTLFPrintList}{fBRÆTSPILPrintList}");
            if (lager.ForespørgselsListe.Count == 0)
            {
                Console.WriteLine("Ingen forespørgsler er blevet oprettet endnu.");
            }
            else
            {
                for (int i = 0; i < lager.ForespørgselsListe.Count; i++)
                {
                    //Console.WriteLine($"ID: {forespørgsels.Id} \nNavn: {forespørgsels.Kundenavn} \nTlf: {forespørgsels.Tlf}" +
                    //$"\nBrætspil: {forespørgsels.Brætspil}  \n-------------------------------");
                    var forespørgsel = lager.ForespørgselsListe[i];
                    Console.WriteLine($"[{i + 1}] {forespørgsel.fToPrettyString()}");
                }
            }
            //static List<Forespørgsel> forespøgsel = new List<Forespørgsel>();

        }

  /*      public void TjekForEksisterende(DataLager lager)
        {

            foreach (var item in lager.BrætspilsListe)
            {
                if (lager.BrætspilsListe.Contains(_brætspil))
                {
                    Console.WriteLine("Der findes allerede et brætspil med dette navn på lager!!!"); ;
                }
                
            }
        }
  */
        public static void SletForespørgsel(DataLager lager)
        {
            //Indsæt slet forespørgsel
            Console.WriteLine("Indtast nummeret på den forespørgsel du ønsker at slette");
            int tal = Convert.ToInt32(Console.ReadLine());

            Forespørgsel forespørgselremove = null;
            foreach (var forespørgsels in lager.ForespørgselsListe)
            {
                if (forespørgsels.Id == tal)
                {
                    forespørgselremove = forespørgsels;
                    break;
                }
            }
            if (forespørgselremove != null)
            {
                lager.ForespørgselsListe.Remove(forespørgselremove);
                Console.WriteLine($"{tal} er blevet slettet");
            }
            else
            {
                Console.WriteLine("Forespørgsels ID ikke fundet");
            }
        }

        public static void SøgForespørgsel(DataLager lager)
        {
            // tilføj søge funktion
            //Spørg bruger hvilket ID han leder efter
            Console.WriteLine("Indtast ID for den forespørgsel du vil søge på:"); //ændrede teksten her, da det ikke var tydeligt hvad man skulle taste. (exception error)
                                                                                  // Indtast brugerens ID
            int søgtID = int.Parse(Console.ReadLine());

            // Søg på person med det angivne ID
            Forespørgsel søgtForespørgsel = lager.ForespørgselsListe.Find(f => f.Id == søgtID);
            // Se om man kan søge på navn; 


            //Udskriv nu det søgte ID's informationer
            if (søgtForespørgsel != null)
            {
                Console.WriteLine($"Forespørgsel: {søgtForespørgsel.Id} \nKundenavn: {søgtForespørgsel.Kundenavn} \n" +
                    $"Kundetelefon: {søgtForespørgsel.Tlf} \nSpil: {søgtForespørgsel.Brætspil}");
            }
            else
            {
                Console.WriteLine("Det indtastede nummer er ikke korrekt");
            }

        }

    }

}
