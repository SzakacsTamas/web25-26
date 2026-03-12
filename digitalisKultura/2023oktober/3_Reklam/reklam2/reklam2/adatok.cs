using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reklam2
{
    internal class adatok
    {
        public int nap;
        public string varos;
        public int rendelesSzama;

        public adatok(int nap, string varos, int rendelesSzama)
        {
            this.nap = nap;
            this.varos = varos;
            this.rendelesSzama = rendelesSzama;
        }
    }
}
