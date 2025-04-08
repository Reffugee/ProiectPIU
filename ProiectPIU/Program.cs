using System;
using LibrarieModele;
using LibrarieModele.Enumerari;
using NivelStocareDate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.IO;

namespace ProiectPIU
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            AdministrareJucatori_FisierText adminJucatori = new AdministrareJucatori_FisierText(caleCompletaFisier);
            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier2"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            Jucator JucatorNou = new Jucator();
            AdministrareAntrenament_FisierText adminAntrenament = new AdministrareAntrenament_FisierText(caleCompletaFisier2);
            Antrenament AntrenamentNou = new Antrenament();

            JucatorNou = CitireJucatorTastatura();
            AfisareJucator(JucatorNou);
            adminJucatori.AdaugaJucator(JucatorNou);
            List<Jucator> jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            AfisareJucatori(jucatori);
            AntrenamentNou = CitireTastaturaAntrenament();
            AfisareAntrenament(AntrenamentNou);
            adminAntrenament.AddAntrenament(AntrenamentNou);
            List<Antrenament> antrenamente = adminAntrenament.GetAntrenamente(out int nrAntrenamente);
            AfisareAntrenamente(antrenamente);

            AdministrarePrezenta adminPrezenta = new AdministrarePrezenta();

            Console.WriteLine("\nMarcheaza jucatorul prezent la antrenament:");
            foreach (var jucator in jucatori)
            {
                if (jucator != null)
                {
                    Console.WriteLine($"A fost jucatorul {jucator.Nume} {jucator.Prenume} ( Jucatorul #{jucator.Numar}) la {AntrenamentNou.Exercitiu}? (da/nu):");
                    string input = Console.ReadLine().ToLower();
                    bool prezent = input == "da" || input == "da";

                    adminPrezenta.Prezenta(jucator.Nume, jucator.Numar, AntrenamentNou.Exercitiu, prezent);
                }
            }

            adminPrezenta.AfisarePrezenta();


            Console.WriteLine("Introdu numele jucatorului de cautat: ");
            string NumeCauta = Console.ReadLine();
            Console.WriteLine("Introdu prenumele jucatorului de cautat: ");
            string PrenumeCauta = Console.ReadLine();

            List<Jucator> gasiti = adminJucatori.GetJucator(NumeCauta, PrenumeCauta);

            if (gasiti.Count > 0)
            {
                foreach (var jucator in gasiti)
                {
                    Console.WriteLine(jucator.Info());
                }
            }
            else
            {
                Console.WriteLine("Jucatorul nu a fost gasit");
            }

        }

        public static Jucator CitireJucatorTastatura()
        {
            Console.WriteLine("Introduceti Numele Jucatorului:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti Prenumele Jucatorului:");
            string prenume = Console.ReadLine();
            Console.WriteLine("Introduceti pozitiile jucatorului (separate prin virgula, ex: Fundas, Mijlocas):");
            string inputPozitie = Console.ReadLine();
            Pozitie pozitie = Pozitie.Necunoscut;

            if (!string.IsNullOrWhiteSpace(inputPozitie))
            {
                foreach (var p in inputPozitie.Split(','))
                {
                    if (Enum.TryParse(p.Trim(), true, out Pozitie pozitieTemp))
                    {
                        pozitie |= pozitieTemp;
                    }
                }
            }
            Console.WriteLine("Introduceti data nasterii jucatorului (format: DD-MM-YYYY):");
            DateTime dataNastere = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Introduceti numarul jucatorului:");
            int numar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti inaltimea jucatorului in cm:");
            int inaltime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduceti greutatea jucatorului in kg:");
            int greutate = Convert.ToInt32(Console.ReadLine());

            Jucator jucator = new Jucator(nume, prenume, pozitie, dataNastere, numar, inaltime, greutate);

            return jucator;

        }
        public static void AfisareJucator(Jucator jucator)
        {
            string infoJucator = string.Format("Numele jucatorului: {0} {1}, Pozitie: {2}, Numar: {3}, Varsta: {4} ani, Inaltime: {5} cm, Greutate: {6} kg",
                jucator.Nume ?? " NECUNOSCUT ",
                jucator.Prenume ?? " NECUNOSCUT ",
                jucator.Pozitie != Pozitie.Necunoscut ? jucator.Pozitie.ToString() : "NECUNOSCUT",
                jucator.Numar,
                jucator.Varsta,
                jucator.Inaltime,
                jucator.Greutate);
            Console.WriteLine(infoJucator);
        }
        public static void AfisareJucatori(List<Jucator> jucatori)
        {
            Console.WriteLine("Jucatorii sunt:");
            for (int contor = 0; contor < jucatori.Count; contor++)
            {
                string infoJucator = jucatori[contor].Info();
                Console.WriteLine($"Jucatorul {contor + 1}, {infoJucator}");
            }
        }
        public static Antrenament CitireTastaturaAntrenament()
        {
            Console.WriteLine("Introdu numele exercitiului:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introdu tipul exercitiului:");
            string tip = Console.ReadLine();
            Console.WriteLine("Introdu durata exercitiului:");
            int durata = Convert.ToInt32(Console.ReadLine());
            Console.Write("Alege ziua din saptamana: ");
            Console.WriteLine("1 - Luni \n" +
            "2 - Marti \n" +
            "3 - Miercuri \n" +
            "4 - Joi \n" +
            "5 - Vineri \n" +
            "6 - Sambata \n" +
            "7 - Duminica \n");
            int ziInput = Convert.ToInt32(Console.ReadLine());

            if (!Enum.IsDefined(typeof(Zile), ziInput))
            {
                Console.WriteLine("Ziua introdusa nu este valida.");
            }

            Zile zi = (Zile)ziInput;

            Antrenament antrenament = new Antrenament(nume, tip, durata, zi);
            return antrenament;
        }
        public static void AfisareAntrenament(Antrenament antrenament)
        {
            string infoAntrenament = string.Format("Numele exercitiului {0}, Tipul exercitiului {1}, Durata exercitiului {2} minute, Ziua: {3}",
                antrenament.Exercitiu ?? " NECUNOSCUT ",
                antrenament.TipExercitiu ?? "NECUNOSCUT ",
                antrenament.Durata,
                antrenament.Zi);
            Console.WriteLine(infoAntrenament);
        }
        public static void AfisareAntrenamente(List<Antrenament> antrenamente)
        {
            Console.WriteLine("Exercitiile sunt:");
            for (int contor = 0; contor < antrenamente.Count; contor++)
            {
                string infoAntrenament = antrenamente[contor].Info();
                Console.WriteLine($"Exercitiul {contor + 1}, {infoAntrenament}");
            }
        }
    }
}
