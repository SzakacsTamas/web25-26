using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utemez2
{
    internal class adatok
    {
        public int kezdoHonap;
        public int kezdoNap;
        public int utolsoHonap;
        public int utolsoNap;
        public string diakAzonosito;
        public string taborTema;

        public adatok(int kezdoHonap, int kezdoNap, int utolsoHonap, int utolsoNap, string diakAzonosito, string taborTema)
        {
            this.kezdoHonap = kezdoHonap;
            this.kezdoNap = kezdoNap;
            this.utolsoHonap = utolsoHonap;
            this.utolsoNap = utolsoNap;
            this.diakAzonosito = diakAzonosito;
            this.taborTema = taborTema;
        }
    }
}
