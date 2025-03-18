using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareAntrenament_Memorie
    {
        private const int nrMaxAntrenamente = 50;

        private Antrenament[] antrenamente;

        private int nrAntrenamente;

        public AdministrareAntrenament_Memorie()
        {
            antrenamente = new Antrenament[nrMaxAntrenamente];
            nrAntrenamente = 0;
        }

        public void AdaugaAntrenament(Antrenament antrenament)
        {
            antrenamente[nrAntrenamente] = antrenament;
            nrAntrenamente++;
        }

        public Antrenament[] GetAntrenamente(out int nrAntrenamente)
        {
            nrAntrenamente = this.nrAntrenamente;
            return antrenamente;
        }
    }
}
