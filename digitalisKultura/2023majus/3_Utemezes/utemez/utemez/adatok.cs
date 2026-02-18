using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utemez
{
    internal class adatok
    {
        public int kezdoHonap;
        public int kezdoNap;
        public int vegeHonap;
        public int vegeNap;
        public string diakAzonositok;
        public string taborTipus;

        public adatok(int kezdoHonap, int kezdoNap, int vegeHonap, int vegeNap, string diakAzonositok, string taborTipus)
        {
            this.kezdoHonap = kezdoHonap;
            this.kezdoNap = kezdoNap;
            this.vegeHonap = vegeHonap;
            this.vegeNap = vegeNap;
            this.diakAzonositok = diakAzonositok;
            this.taborTipus = taborTipus;
        }
    }
}
