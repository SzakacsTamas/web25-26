using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoszerviz
{
    internal class adatok
    {
        public string rendSzam;
        public string uzemTipus;
        public DateOnly elsoUzembe;
        public string tulajNeve;
        public DateOnly szervizbeHozas;
        public adatok(string rendSzam, string uzemTipus, DateOnly elsoUzembe, string tulajNeve, DateOnly szervizbeHozas)
        {
         
            this.rendSzam = rendSzam;
            this.uzemTipus = uzemTipus;
            this.elsoUzembe = elsoUzembe;
            this.tulajNeve = tulajNeve;
            this.szervizbeHozas = szervizbeHozas;
        }
    }
}
