using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reklam
{
    internal class adatok
    {
        public int nap;
        public string hirdetesTipus;
        public int rendelesDarab;

        public adatok(int nap, string hirdetesTipus, int rendelesDarab)
        {
            this.nap = nap;
            this.hirdetesTipus = hirdetesTipus;
            this.rendelesDarab = rendelesDarab;
        }
    }
}
