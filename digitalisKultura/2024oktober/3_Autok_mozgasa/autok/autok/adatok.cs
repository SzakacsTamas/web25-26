using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok
{
    internal class adatok
    {
        public string rendSzam;
        public int ora;
        public int perc;
        public int sebesseg;

        public adatok(string rendSzam, int ora, int perc, int sebesseg)
        {
            this.rendSzam= rendSzam;
            this.ora= ora;
            this.perc= perc;
            this.sebesseg= sebesseg;

        }
    }
}
