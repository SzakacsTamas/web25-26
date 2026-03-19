using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvek
{
    internal class adatok
    {
        public int ev;
        public int negyedEv;
        public string eredet;
        public string leiras;
        public int kiadottSzam;

        public adatok(int ev, int negyedEv, string eredet, string leiras, int kiadottSzam)
        {
            this.ev = ev;
            this.negyedEv = negyedEv;
            this.eredet = eredet;
            this.leiras = leiras;
            this.kiadottSzam = kiadottSzam;
        }
    }
}
