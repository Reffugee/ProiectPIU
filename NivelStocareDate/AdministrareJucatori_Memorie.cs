using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    class AdministrareJucatori_Memorie
    {
        private const int nr_max_jucatori = 50;

        private Jucator[] jucatori;
        private int nrJucatori;

        public AdministrareJucatori_Memorie()
        {
            jucatori = new Jucator[nr_max_jucatori];
            nrJucatori = 0;
        }

        public void AddJucator(Jucator jucator)
        {
            jucatori[nrJucatori] = jucator;
            nrJucatori++;
        }

        public Jucator[] GetJucatori(out int nrJucatori)
        {
            nrJucatori = this.nrJucatori;
            return jucatori;
        }
    }
}
