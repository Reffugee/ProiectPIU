using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareJucatori_FisierText
    {
        private const int nr_max_jucatori = 50;
        private string numeFisier;

        public AdministrareJucatori_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugaJucator(Jucator jucator)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(jucator.ConversieSir_PentruFisier());
            }
        }

        public List<Jucator> GetJucatori(out int nrJucatori)
        {
            List<Jucator> jucatori = new List<Jucator>();
            nrJucatori = 0;

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    jucatori.Add(new Jucator(linieFisier));
                }
            }

            nrJucatori = jucatori.Count;
            return jucatori;
        }

        public List<Jucator> GetJucator(string term, out int count)
        {
            term = term?.Trim() ?? "";
            var all = GetJucatori(out _);

            string[] parts = term.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var found = all.Where(j =>
                (parts.Length == 1 &&
                 (j.Nume.Equals(parts[0], StringComparison.OrdinalIgnoreCase) ||
                  j.Prenume.Equals(parts[0], StringComparison.OrdinalIgnoreCase))) ||

                (parts.Length >= 2 &&
                 j.Nume.Equals(parts[0], StringComparison.OrdinalIgnoreCase) &&
                 j.Prenume.Equals(parts[1], StringComparison.OrdinalIgnoreCase))
            ).ToList();

            count = found.Count;
            return found;
        }

        public void SalveazaEdit(IEnumerable<Jucator> jucatori)
        {
            var lines = jucatori
                .Select(j => j.ConversieSir_PentruFisier());
            File.WriteAllLines(numeFisier, lines, Encoding.UTF8);
        }
        public bool StergeUltimulJucator()
        {
            var lines = File.ReadAllLines(numeFisier).ToList();
            if (lines.Count == 0)
                return false;

            lines.RemoveAt(lines.Count - 1);

            File.WriteAllLines(numeFisier, lines);
            return true;
        }

    }
}
