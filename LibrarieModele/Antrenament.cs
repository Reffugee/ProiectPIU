using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Antrenament
    {
        public string Exercitiu { get; set; }
        public string TipExercitiu { get; set; }
        public int Durata { get; set; }

        public Antrenament()
        {
            Exercitiu = TipExercitiu = string.Empty;
            Durata = 0;
        }

        public Antrenament(string _Exercitiu, string _TipExercitiu, int _Durata)
        {
            Exercitiu = _Exercitiu;
            TipExercitiu = _TipExercitiu;
            Durata = _Durata;
        }
        public string Info()
        {
            return $"Exercitiu: {Exercitiu}, Tip Exercitiu: {TipExercitiu}, Durata: {Durata} minute";
        }
    }
}
