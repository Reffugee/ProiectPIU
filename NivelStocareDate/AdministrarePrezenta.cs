using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrarePrezenta
    {
        private List<string> _ListaPrezenta;

        public AdministrarePrezenta()
        {
            _ListaPrezenta = new List<string>();
        }

        public void Prezenta(string NumeJucator, int NumarJucator, string Exercitiu, bool prezenta)
        {
            var Prezenta  = $"{NumeJucator} (Jucatorul #{NumarJucator}) prezenta la {Exercitiu}: {prezenta}";
            _ListaPrezenta.Add(Prezenta);
        }

        public void AfisarePrezenta()
        {
            Console.WriteLine("Lista Prezenta:");
            foreach (var lista in _ListaPrezenta)
            {
                Console.WriteLine(lista);
            }
        }

        public bool PrezentaExercitiu(int NumarJucator, string Exercitiu)
        {
            foreach (var lista in _ListaPrezenta)
            {
                if (lista.Contains($"Jucator #{NumarJucator}") && lista.Contains(Exercitiu))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
