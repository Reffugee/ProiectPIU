using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Jucator
    {
        private const char Separator_fisier = ';';
        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int POZITIE = 2;
        private const int DATANASTERE = 3;
        private const int NUMAR = 4;
        private const int INALTIME = 5;
        private const int GREUTATE = 6;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Pozitie { get; set; }
        public DateTime DataNastere { get; set; }
        public int Numar { get; set; }
        public int Inaltime { get; set; }
        public int Greutate { get; set; }

        public int Varsta
        {
            get
            {
                DateTime Azi = DateTime.Today;
                int varsta = Azi.Year - DataNastere.Year;
                if (DataNastere.Date > Azi.AddYears(-varsta))
                {
                    varsta--;
                }
                return varsta;
            }
        }


        public Jucator()
        {
            Nume = Prenume = Pozitie = string.Empty;
            Numar = Inaltime = Greutate = -1;
            DataNastere = DateTime.MinValue;
        }

        public Jucator(string _Nume, string _Prenume, string _Pozitie, DateTime _DataNastere, int _Numar, int _Inaltime, int _Greutate)
        {
            Nume = _Nume;
            Prenume = _Prenume;
            Pozitie = _Pozitie;
            DataNastere = _DataNastere;
            Numar = _Numar;
            Inaltime = _Inaltime;
            Greutate = _Greutate;
        }
        public Jucator(string linieFisier)
        {
            var dateFisier = linieFisier.Split(Separator_fisier);
            this.Nume = dateFisier[NUME];
            this.Prenume = dateFisier[PRENUME];
            this.Pozitie = dateFisier[POZITIE];
            this.Numar = Convert.ToInt32(dateFisier[NUMAR]);
            this.DataNastere = DateTime.Parse(dateFisier[DATANASTERE]);
            this.Inaltime = Convert.ToInt32(dateFisier[INALTIME]);
            this.Greutate = Convert.ToInt32(dateFisier[GREUTATE]);
        }

        public string Info()
        {
            return $"Numele jucatorului: {Nume} {Prenume}, Pozitie: {Pozitie}, Numar: {Numar}, Varsta: {Varsta} ani, Inaltime: {Inaltime} cm, Greutate: {Greutate} kg";
        }
        public string ConversieSir_PentruFisier()
        {
            string obiectJucatorFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                Separator_fisier,
                (Nume ?? " Necunoscut "),
                (Prenume ?? " Necunoscut "),
                (Pozitie ?? " Necunoscut "),
                DataNastere.ToString("yyyy-MM-dd"),
                Numar.ToString(),
                Inaltime.ToString(),
                Greutate.ToString());
            return obiectJucatorFisier;

        }

    }
}
