using LibrarieModele.Enumerari;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Antrenament
    {
        private const char SeparatorFisier = ';';

        private const int EXERCITIU = 0;
        private const int TIPEXERCITIU = 1;
        private const int DURATA = 2;
        private const int ZI = 3;
        public string Exercitiu { get; set; }
        public string TipExercitiu { get; set; }
        public int Durata { get; set; }
        public Zile Zi { get; set; }


        public Antrenament()
        {
            Exercitiu = TipExercitiu = string.Empty;
            Durata = 0;
        }

        public Antrenament(string _Exercitiu, string _TipExercitiu, int _Durata, Zile _Zi)
        {
            Exercitiu = _Exercitiu;
            TipExercitiu = _TipExercitiu;
            Durata = _Durata;
            Zi = _Zi;
        }
        public Antrenament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SeparatorFisier);
            this.Exercitiu = dateFisier[EXERCITIU];
            this.TipExercitiu = dateFisier[TIPEXERCITIU];
            this.Durata = Convert.ToInt32(dateFisier[DURATA]);
            this.Zi = (Zile)Enum.Parse(typeof(Zile), dateFisier[ZI]);
        }
        public string Info()
        {
            return $"Exercitiu: {Exercitiu}, Tip Exercitiu: {TipExercitiu}, Durata: {Durata} minute, Ziua: {Zi}";
        }

        public string ConversieSirFisier()
        {
            string obiectAntrenamentFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                SeparatorFisier,
                (Exercitiu ?? " Necunoscut "),
                (TipExercitiu ?? " Necunoscut "),
                Durata.ToString(),
                Zi.ToString());

            return obiectAntrenamentFisier;
        }
    }
}
