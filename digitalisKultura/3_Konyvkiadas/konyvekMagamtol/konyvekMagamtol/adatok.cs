using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvekMagamtol
{
    internal class adatok
    {
        public int ev;
        public int negyedEv;
        public string eredet;
        public string leiras;
        public int kiadottPeldanySzam;

        public adatok(int ev, int negyedEv, string eredet, string leiras, int kiadottPeldanySzam)
        {
            this.ev = ev;
            this.negyedEv = negyedEv;
            this.eredet = eredet;
            this.leiras = leiras;
            this.kiadottPeldanySzam = kiadottPeldanySzam;
        }
    }
}
