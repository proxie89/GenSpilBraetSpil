﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGenspil
{
    public class Lager
    {
        public string FilePathBrætspil { get; set; } = "Brætspil.txt";// Sti til filen, der gemmer data

        public List<Brætspil> BrætspilsListe = new List<Brætspil>();
       
        public Lager(string filePathBrætspil)   // Konstruktør placeres typisk mellem felterne ovenover og metoder nedenunder.
        {
            FilePathBrætspil = filePathBrætspil; // Sætter filstien ved oprettelse af DataHandler
        }
        
        public void SaveBoardGames()
        {
            using (StreamWriter sw = new StreamWriter(FilePathBrætspil))  // FilePathBrætspil er ikke static, så den hører til et objekt.
            {
                foreach (Brætspil brætspil in BrætspilsListe)
                {
                    sw.WriteLine(brætspil.ToString());
                }
            }
        }

        public void LoadBoardGames()
        {
            if (!File.Exists(FilePathBrætspil))
            {
                SaveBoardGames();
            }

            using (StreamReader sr = new StreamReader(FilePathBrætspil))  // Her åbnes tekstfilen Brætspil.txt i den lokale mappe på computeren.
            {
                while (true)
                {
                    string line = sr.ReadLine();  // Her hentes næste linje i tekstfilen.

                    if (line == null)
                    {
                        break;  // Break ud af loopet, når linjen er null (ingen linje).
                    }

                    if (line == "")
                    {
                        continue; // Fortsætter loopet, når der er en linje uden tekst.
                    }

                    Brætspil brætspil = Brætspil.FromString(line);
                    BrætspilsListe.Add(brætspil);
                }
            }  // Her lukkes tekstfilen. Fordi man nu er ude af kodeblokken.
        }
    }
}
