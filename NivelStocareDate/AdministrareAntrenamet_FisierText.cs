using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareAntrenament_FisierText
    {
        private const int nr_max_antrenamente = 50;
        private string numeFisier2;

        public AdministrareAntrenament_FisierText(string numeFisier2)
        {
            this.numeFisier2 = numeFisier2;
            Stream streamFisierText = File.Open(numeFisier2, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddAntrenament(Antrenament antrenament)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier2, true))
            {
                streamWriterFisierText.WriteLine(antrenament.ConversieSirFisier());
            }
        }
        public Antrenament[] GetAntrenamente(out int nrAntrenamente)
        {
            Antrenament[] antrenamente = new Antrenament[nr_max_antrenamente];
            using (StreamReader streamReader = new StreamReader(numeFisier2))
            {
                string linieFisier;
                nrAntrenamente = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    antrenamente[nrAntrenamente++] = new Antrenament(linieFisier);
                }
            }
            return antrenamente;
        }
    }
}
