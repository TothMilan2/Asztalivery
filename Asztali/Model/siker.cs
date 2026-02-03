using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztali.Model
{
    internal class siker
    {
        private string _konyvnev;

        public string Konyvnev { get => _konyvnev; set => _konyvnev = value; }

        public siker(string konyvnev)
        {
            Konyvnev = konyvnev;
        }

        public siker()
        {
        }

        public override string ToString()
        {
            return $"2001 ben kiadott könyvek: {Konyvnev}";
        }
    }
}
