using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrarePrezenta
    {
        private readonly string caleFisier;
        private const char SEPARATOR = ';';

        public AdministrarePrezenta(string caleFisier)
        {
            this.caleFisier = caleFisier;
            if (!File.Exists(caleFisier))
                File.Create(caleFisier).Dispose();
        }

        public void SalveazaPrezenta(Prezenta p)
        {
            string line = string.Join(SEPARATOR.ToString(),
                p.Nume,
                p.Prenume,
                p.Exercitiu,
                p.Data.ToString("yyyy-MM-dd"),
                (p.Participa ? "1" : "0"));
            File.AppendAllLines(caleFisier, new[] { line });
        }

        public List<Prezenta> GetPrezente()
        {
            return File.ReadAllLines(caleFisier)
                       .Where(l => !string.IsNullOrWhiteSpace(l))
                       .Select(l =>
                       {
                           var parts = l.Split(SEPARATOR);
                           return new Prezenta
                           {
                               Nume = parts[0],
                               Prenume = parts[1],
                               Exercitiu = parts[2],
                               Data = DateTime.Parse(parts[3]),
                               Participa = parts[4] == "1"
                           };
                       })
                       .ToList();
        }
    }
}
