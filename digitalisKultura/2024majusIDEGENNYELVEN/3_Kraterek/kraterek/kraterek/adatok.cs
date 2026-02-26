using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kraterek
{
    internal class adatok
    {
        public double xKoordinata;
        public double yKoordinata;
        public double kraterSugar;
        public string kraterNev;

        public adatok(double xKoordinata, double yKoordinata, double kraterSugar, string kraterNev)
        {
            this.xKoordinata = xKoordinata;
            this.yKoordinata = yKoordinata;
            this.kraterSugar = kraterSugar;
            this.kraterNev = kraterNev;
        }
    }
}
