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
        private string FilePath = "Jucator.txt";
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

        public Jucator[] GetJucatori(out int nrJucatori)
        {
            Jucator[] jucatori = new Jucator[nr_max_jucatori];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrJucatori = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    jucatori[nrJucatori++] = new Jucator(linieFisier);
                }

            }
            return jucatori;
        }
        public List<Jucator> GetJucator(string Nume, string Prenume)
        {
            List<Jucator> listaJucatori = new List<Jucator>();
            foreach (var linie in File.ReadLines(FilePath))
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
