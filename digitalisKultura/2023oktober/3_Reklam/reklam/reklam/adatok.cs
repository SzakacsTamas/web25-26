using System;
using System.Collections.Generic;
using System.Text;

namespace reklam
{
    internal class adatok
    {
        public int nap;
        public string hirdetesForma;
        public int rendelesekSzama;

        public adatok(int nap, string hirdetesForma, int rendelesekSzama)
        {
            this.nap = nap;
            this.hirdetesForma = hirdetesForma;
            this.rendelesekSzama = rendelesekSzama;
        }
    }
}
