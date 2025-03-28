using System;
using System.Collections.Generic;

namespace ProjektGenspil
{
    class Program
    {
        static List<string> names = new List<string>(); // Liste til at gemme navne
        static List<Forespørgsel> forespørgsel = new List<Forespørgsel>(); //Til forespørgsler

        static void Main()
        {
            while (true)
            {
                Console.Clear(); // Rydder skærmen for en ren menuvisning
                Console.WriteLine("=== Hovedmenu ===");
                Console.WriteLine("1. Tilføj navn til listen");
                Console.WriteLine("2. Vis alle navne");
                Console.WriteLine("3. Slet et navn");
                Console.WriteLine("4. Til forespørgsel menu");
                Console.WriteLine("4. Afslut");
                Console.Write("Vælg en mulighed: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBoardGame();
                        break;
                    case "2":
                        PrintList();
                        break;
                    case "3":
                        DeleteBoardGame();
                        break;
                    case "4":
                        ForespørgselMenu();
                        break;
                    case "5":
                        Console.WriteLine("Farvel!");
                        return; // Afslutter programmet
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }

                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        static void AddBoardGame()
        {
            Console.Clear();
            Console.Write("Indtast et navn: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                names.Add(name);
                Console.WriteLine($"\"{name}\" er tilføjet til listen.");
            }
            else
            {
                Console.WriteLine("Navnet kan ikke være tomt.");
            }
        }

        static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("=== Liste over navne ===");
            if (names.Count == 0)
            {
                Console.WriteLine("Ingen navne tilføjet endnu.");
            }
            else
            {
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
                
        static void DeleteBoardGame()
        {
            PrintList();
            if (names.Count == 0)
            {
                Console.WriteLine("Ingen navne at slette.");
                return;
            }

            int index;
            while (true)
            {
                Console.Write("Indtast nummeret på det navn, du vil slette: ");
                string input = Console.ReadLine();

                
                Console.WriteLine($"Input: {input}");

                /*if { }
                

                }

                else
                {
                    Console.WriteLine("Ugyldigt valg. Prøv igen.");
                }*/
            }
        }

        static void ForespørgselMenu()
        {
            while (true)
            {
                Console.Clear(); // Rydder skærmen for en ren menuvisning
                Console.WriteLine("=== Forespørgselmenu ===");
                Console.WriteLine("1. Opret forespørgsel");
                Console.WriteLine("2. Se liste med forespørgsler");
                Console.WriteLine("3. Slet forespørgsel");
                Console.WriteLine("4. Søg på forespørgsel");
                Console.WriteLine("5. Afslut");
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
                        Console.WriteLine("Farvel!");
                        return; // Afslutter programmet
                    default:
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                        break;
                }

                Console.WriteLine("Tryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        static void AddForspørgsel() //Tilføj en Forespørgsel. Skal tildeles et ID
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
        static void SeListe()
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

        static void SøgForespørgsel()
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

