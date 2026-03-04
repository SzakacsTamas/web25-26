using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto2
{
    internal class adatok
    {
        public string diakAzonosito;
        public int ora;
        public int perc;
        public int esemenyKodja;

        public adatok(string diakAzonosito, string idopont, int esemenyKodja)
        {
            this.diakAzonosito = diakAzonosito;
            string[] darabok= idopont.Split(':'); 
            this.ora = int.Parse(darabok[0]);
            this.perc = int.Parse(darabok[1]);
            this.esemenyKodja = esemenyKodja;
        }
    }
}
