using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class ForespørgselMenuer
    {
        //Forespørgsel _forespørgsel = new Forespørgsel("Forespørgsel.txt");
        
        public static void ForespørgselMenu()
        {
            while (true)
            {
                Console.Clear(); // Rydder skærmen for en ren menuvisning
                Console.WriteLine("=== Forespørgselmenu ===\n");
                Console.WriteLine("1. Opret forespørgsel\n");
                Console.WriteLine("2. Se liste med forespørgsler\n");
                Console.WriteLine("3. Slet forespørgsel\n");
                Console.WriteLine("4. Søg på forespørgsel\n");
                Console.WriteLine("5. Tilbage til hovedmenu!\n");
                Console.Write("Vælg en mulighed: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddForspørgsel();
                        break;
                    case "2":
                        SeListe();
                        break;
                    case "3":
                        SletForespørgsel();
                        break;
                    case "4":
                        SøgForespørgsel();
                        break;
                    case "5":
                        Console.WriteLine("Vend tilbage til Hovedmenu!");
                        return; // Afslutter programmet her
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }

                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        public void AddForspørgsel() //Tilføj en Forespørgsel. Skal tildeles et ID
        {
            Console.Clear();

            Console.WriteLine("Hvor mange forespørgsler vil du indtaste?");
            int antalFor = int.Parse(Console.ReadLine());
            for (int i = 0; i < antalFor; i++)
            {
                Console.WriteLine("Hvilket spil vil kunden gerne oprette forespørgsel på?");
                string _brætspil = Console.ReadLine();

                Console.WriteLine("Indtast kundens navn");
                string _kundenavn = Console.ReadLine();

                Console.WriteLine("Indtast kundens telefonnummer");
                int _tlf = int.Parse(Console.ReadLine());

                // Forespørgselsnummer skal nok være et for loop, hvor i = 1, og herefter adder den til hver gang et nummer bliver oprettet
                Console.WriteLine("Indtast forespørgsels ID" + (i + 1) + ": ");
                int _id = int.Parse(Console.ReadLine());

                Forespørgsel.forespørgsel.Add(new Forespørgsel(_id, _kundenavn, _tlf, _brætspil));
                Console.WriteLine($"Forespørgsel {_id} blev oprettet.\nSpil: {_brætspil}\nNavn: {_kundenavn}\nTlf: {_tlf}\n");

            }

            Forespørgsel.GemForespørgsel();
        }

        
       

        public void SeListe()
        {
            string fIDPrintList = "".PadRight(7);
            string fNAVNPrintList = "Navn".PadRight(14);
            string fTLFPrintList = "TLF".PadRight(12);
            string fBRÆTSPILPrintList = "Brætspil".PadRight(12);

            // Udskriv liste med forespørgsler
            Console.Clear();
            Console.WriteLine("=== Liste over forspørgsler ===");
            Console.WriteLine($"{fIDPrintList}{fNAVNPrintList}{fTLFPrintList}{fBRÆTSPILPrintList}");
            if (Forespørgsel.forespørgsel.Count == 0)
            {
                Console.WriteLine("Ingen forespørgsler er blevet oprettet endnu.");
            }
            else
            {
                for (int i = 0; i < Forespørgsel.forespørgsel.Count; i++)
                {
                    //Console.WriteLine($"ID: {forespørgsels.Id} \nNavn: {forespørgsels.Kundenavn} \nTlf: {forespørgsels.Tlf}" +
                    //$"\nBrætspil: {forespørgsels.Brætspil}  \n-------------------------------");
                    var forespørgsel =Forespørgsel.forespørgsel[i];
                    Console.WriteLine($"[{i + 1}] {forespørgsel.fToPrettyString()}");



                }
            }
            //static List<Forespørgsel> forespøgsel = new List<Forespørgsel>();

        }

        public void SletForespørgsel()
        {
            //Indsæt slet forespørgsel
            Console.WriteLine("Indtast nummeret på den forespørgsel du ønsker at slette");
            int tal = Convert.ToInt32(Console.ReadLine());

            Forespørgsel forespørgselremove = null;
            foreach (var forespørgsels in Forespørgsel.forespørgsel)
            {
                if (forespørgsels.Id == tal)
                {
                    forespørgselremove = forespørgsels;
                    break;
                }
            }
            if (forespørgselremove != null)
            {
                Forespørgsel.forespørgsel.Remove(forespørgselremove);
                Console.WriteLine($"{tal} er blevet slettet");
            }
            else
            {
                Console.WriteLine("Forespørgsels ID ikke fundet");
            }
        }

        public void SøgForespørgsel()
        {
            // tilføj søge funktion
            //Spørg bruger hvilket ID han leder efter
            Console.WriteLine("Indtast ID for den forespørgsel du vil søge på:"); //ændrede teksten her, da det ikke var tydeligt hvad man skulle taste. (exception error)
            // Indtast brugerens ID
            int søgtID = int.Parse(Console.ReadLine());

            // Søg på person med det angivne ID
            Forespørgsel søgtForespørgsel = Forespørgsel.forespørgsel.Find(f => f.Id == søgtID);
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
