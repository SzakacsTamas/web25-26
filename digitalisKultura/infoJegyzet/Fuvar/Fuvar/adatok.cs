using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    internal class adatok
    {
        public int taxiAz;
        public string indulasIdopontja;
        public int utazasIdeje;
        public double megtettTav;
        public double vitelDij;
        public double borravaló;
        public string fizetesMod;

        public adatok(int taxiAz, string indulasIdopontja, int utazasIdeje, double megtettTav, double vitelDij, double borravaló, string fizetesMod)
        {
            this.taxiAz = taxiAz;
            this.indulasIdopontja = indulasIdopontja;
            this.utazasIdeje = utazasIdeje;
            this.megtettTav = megtettTav;
            this.vitelDij = vitelDij;
            this.borravaló = borravaló;
            this.fizetesMod = fizetesMod;
        }
    }
}
