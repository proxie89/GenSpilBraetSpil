﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    internal class ForespørgselMenuer
    {
        static List<Forespørgsel> forespørgsel = new List<Forespørgsel>(); //Til forespørgsler

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
                Console.WriteLine("5. Afslut programmet!\n");
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

        public static void AddForspørgsel() //Tilføj en Forespørgsel. Skal tildeles et ID
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

                Console.WriteLine("Indtast forespørgsels ID" + (i + 1) + ": ");
                int _id = int.Parse(Console.ReadLine());

                forespørgsel.Add(new Forespørgsel(_id, _kundenavn, _tlf, _brætspil));
                Console.WriteLine($"Forespørgsel {_id} blev oprettet.\nSpil: {_brætspil}\nNavn: {_kundenavn}\nTlf: {_tlf}\n");

            }
        }

        /*
        static void AddKunde()
        {
            
            kunde.Add(new Kunde("Kathrine Jensen", 88776655));
            kunde.Add(new Kunde("Bo Hansen", 99887766));

            Console.Clear();
            Console.WriteLine("Indtast kundens fulde navn");
            string name = Console.ReadLine();
            Console.WriteLine("Indtast telefonnummer på kunden");
            int nummer = Convert.ToInt32(Console.ReadLine());

            if ((!string.IsNullOrWhiteSpace(name)))
            {
                Kunde.Add(name); //Adder til "Kunde" listen
                Kunde.Add(nummer);
                Console.WriteLine($"{name} er tilføjet som kunde");
            }
            else
            {
                Console.WriteLine("Error. Prøv igen");
            }
        }
        */
        public static void SeListe()
        {
            // Udskriv liste med forespørgsler
            Console.Clear();
            Console.WriteLine("=== Liste over forspørgsler ===");
            if (forespørgsel.Count == 0)
            {
                Console.WriteLine("Ingen forespørgsler er blevet oprettet endnu.");
            }
            else
            {
                foreach (var forespørgsels in forespørgsel)
                {
                    Console.WriteLine($"ID: {forespørgsels.Id} \nNavn: {forespørgsels.Kundenavn} \nTlf: {forespørgsels.Tlf}" +
                        $"\nBrætspil: {forespørgsels.Brætspil}");

                }
            }
            //static List<Forespørgsel> forespøgsel = new List<Forespørgsel>();

        }

        static void SletForespørgsel()
        {
            //Indsæt slet forespørgsel
        }

        public static void SøgForespørgsel()
        {
            // tilføj søge funktion
            //Spørg bruger hvilket ID han leder efter
            Console.WriteLine("Hvilken forespørgsel leder du efter?");
            // Indtast brugerens ID
            int søgtID = int.Parse(Console.ReadLine());

            // Søg på person med det angivne ID
            Forespørgsel søgtForespørgsel = forespørgsel.Find(f => f.Id == søgtID);

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
