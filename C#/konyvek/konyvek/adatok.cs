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
        public string KoltoEsCim;
        public int peldanySzam;

        public adatok(int ev, int negyedEv, string eredet, string KoltoEsCim, int peladnySzam)
        {
            this.ev = ev;
            this.negyedEv = negyedEv;
            this.KoltoEsCim = KoltoEsCim;
            this.eredet = eredet;
            this.peldanySzam = peladnySzam;
        }
    }
}
