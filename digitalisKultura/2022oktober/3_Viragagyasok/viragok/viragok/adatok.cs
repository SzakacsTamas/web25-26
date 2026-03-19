using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace viragok
{
    internal class adatok
    {
        public int elsoUltetes;
        public int utolsoUltetes;
        public string szin;

        public adatok(int elsoUltetes, int utolsoUltetes, string szin)
        {
            this.elsoUltetes = elsoUltetes;
            this.utolsoUltetes = utolsoUltetes;
            this.szin = szin;
        }
    }
}
