using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelStocareDate
{
    public class AdministrareJucatori
    {
        private const int nr_max_jucatori = 50;

        private Jucator[] jucatori;
        private int nrJucatori;

        public AdministrareJucatori()
        {
            jucatori = new Jucator[nr_max_jucatori];
            nrJucatori = 0;
        }

        public void AdaugaJucator(Jucator jucator)
        {
            jucatori[nrJucatori] = jucator;
            nrJucatori++;
        }

        public Jucator[] GetJucatori(out int nrJucatori)
        {
            nrJucatori = this.nrJucatori;
            return jucatori;
        }

        public Jucator GetJucator(string Nume, string Prenume)
        { 
            foreach (var jucator in jucatori)
            {
                if (jucator.Nume.Equals(Nume, StringComparison.OrdinalIgnoreCase) &&
                    jucator.Prenume.Equals(Prenume, StringComparison.OrdinalIgnoreCase))
                {
                    return jucator;
                }
            }
            return null;
        }
        
        
    }
}
