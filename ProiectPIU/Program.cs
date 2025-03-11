using System;
using LibrarieModele;
using NivelStocareDate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace ProiectPIU
{
    class Program
    {
        static void Main()
        {
            AdministrareJucatori adminJucatori = new AdministrareJucatori();
            Jucator JucatorNou = new Jucator();
            AdministrareAntrenament adminAntrenament = new AdministrareAntrenament();
            Antrenament AntrenamentNou = new Antrenament();

            for(int k = 0; k < 2; k++)
            {
                JucatorNou = CitireJucatorTastatura();
                AfisareJucator(JucatorNou);
                adminJucatori.AdaugaJucator(JucatorNou);
            }
            Jucator[] jucatori = adminJucatori.GetJucatori(out int nrJucatori);
            AfisareJucatori(jucatori, nrJucatori);

            for (int k = 0; k < 2; k++)
            {
                AntrenamentNou = CitireTastaturaAntrenament();
                AfisareAntrenament(AntrenamentNou);
                adminAntrenament.AdaugaAntrenament(AntrenamentNou);
            }
            Antrenament[] antrenamente = adminAntrenament.GetAntrenamente(out int nrAntrenamente);
            AfisareAntrenamente(antrenamente, nrAntrenamente);

            Console.WriteLine("Introdu numele jucatorului de cautat: ");
            string NumeCauta = Console.ReadLine();
            Console.WriteLine("Introdu prenumele jucatorului de cautat: ");
            string PrenumeCauta = Console.ReadLine();

            Jucator GasireJucator = adminJucatori.GetJucator(NumeCauta, PrenumeCauta);

            if(GasireJucator != null)
            {
                Console.WriteLine($"Jucator gasit: {GasireJucator.Nume} {GasireJucator.Prenume}, Pozitie: {GasireJucator.Pozitie}");
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
            Console.WriteLine("Introduceti pozitia jucatorului:");
            string pozitie = Console.ReadLine();
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
                jucator.Pozitie ?? " NECUNOSCUT ",
                jucator.Numar,
                jucator.Varsta,
                jucator.Inaltime,
                jucator.Greutate);
            Console.WriteLine(infoJucator);
        }
        public static void AfisareJucatori(Jucator[] jucatori, int nrJucatori)
        {
            Console.WriteLine("Jucatorii sunt:");
            for (int contor = 0;contor < nrJucatori; contor++)
            {
                string infoJucator = jucatori[contor].Info();
                Console.WriteLine($"Jucatorul {contor+1}, {infoJucator}");
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

            Antrenament antrenament = new Antrenament(nume, tip, durata);
            return antrenament;
        }
        public static void AfisareAntrenament(Antrenament antrenament)
        {
            string infoAntrenament = string.Format("Numele exercitiului {0}, Tipul exercitiului {1}, Durata exercitiului {2} minute.",
                antrenament.Exercitiu ?? " NECUNOSCUT ",
                antrenament.TipExercitiu ?? "NECUNOSCUT ",
                antrenament.Durata);
            Console.WriteLine(infoAntrenament);
        }
        public static void AfisareAntrenamente(Antrenament[] antrenamente, int nrAntrenamente)
        {
            Console.WriteLine("Exercitiile sunt:");
            for (int contor = 0; contor < nrAntrenamente; contor++)
            {
                string infoAntrenament = antrenamente[contor].Info();
                Console.WriteLine($"Exercitiul {contor + 1}, {infoAntrenament}");
            }
        }
    }
}
