using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele.Enumerari
{
    [Flags]
    public enum Pozitie
    {
        Necunoscut = 0,
        Portar = 1,
        Fundas = 2,
        Mijlocas = 4,
        Atacant = 8
    }
}
