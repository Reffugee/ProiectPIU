using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Jucator
    {
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

        public string Info()
        {
            return $"Numele jucatorului: {Nume} {Prenume}, Pozitie: {Pozitie}, Numar: {Numar}, Varsta: {Varsta} ani, Inaltime: {Inaltime} cm, Greutate: {Greutate} kg";
        }
    }
}
