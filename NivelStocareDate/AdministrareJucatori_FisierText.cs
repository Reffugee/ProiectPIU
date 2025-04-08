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

        public List<Jucator> GetJucator(string Nume, string Prenume)
        {
            List<Jucator> listaJucatori = new List<Jucator>();
            foreach (var linie in File.ReadLines(numeFisier))
            {
                Jucator jucator = new Jucator(linie);
                if (jucator.Nume.Equals(Nume, StringComparison.OrdinalIgnoreCase) &&
                    jucator.Prenume.Equals(Prenume, StringComparison.OrdinalIgnoreCase))
                {
                    listaJucatori.Add(jucator);
                }
            }
            return listaJucatori;
        }
    }
}
