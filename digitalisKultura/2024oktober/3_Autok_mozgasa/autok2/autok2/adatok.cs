using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok2
{
    internal class adatok
    {
        public string rendszam;
        public int ora;
        public int perc;
        public int sebesseg;
        public int ido;

        public adatok(string rendszam, int ora, int perc, int sebesseg)
        {
            this.rendszam = rendszam;
            this.ora = ora;
            this.perc = perc;
            this.sebesseg = sebesseg;
            this.ido = ora*60+perc;
        }
    }
}
