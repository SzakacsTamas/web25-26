using System;
using System.Collections.Generic;
using System.Text;

namespace belepteto
{
    internal class adatok
    {
        public string tanuloKod;
        public int ora;
        public int perc;
        public int esemeny;

        public adatok(string tanuloKod, string idopont, int esemeny)
        {
            this.tanuloKod = tanuloKod;
            string[] darabok = idopont.Split(':');
            this.ora = int.Parse(darabok[0]);
            this.perc = int.Parse(darabok[1]);
            this.esemeny = esemeny;
        }
    }
}
