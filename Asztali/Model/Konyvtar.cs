using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztali.Model
{
    internal class Konyvtar
    {
        private int _bookID;
        private string _konyvnev;
        private bool _kivaneveve;
        private int _kiadasiev;
        private string _kolcsonzesideje;
        private int _ISBN;

        public int BookID { get => _bookID; set => _bookID = value; }
        public string Konyvnev { get => _konyvnev; set => _konyvnev = value; }
        public bool Kivaneveve { get => _kivaneveve; set => _kivaneveve = value; }
        public int Kiadasiev { get => _kiadasiev; set => _kiadasiev = value; }
        public string Kolcsonzesideje { get => _kolcsonzesideje; set => _kolcsonzesideje = value; }
        public int ISBN { get => _ISBN; set => _ISBN = value; }

        public Konyvtar(int bookID, string konyvnev, bool kivaneveve, int kiadasiev, string kolcsonzesideje, int iSBN)
        {
            BookID = bookID;
            Konyvnev = konyvnev;
            Kivaneveve = kivaneveve;
            Kiadasiev = kiadasiev;
            Kolcsonzesideje = kolcsonzesideje;
            ISBN = iSBN;
        }

        public Konyvtar()
        {
        }

        public override string ToString()
        {
            return $"bookID: {BookID}, cím: {Konyvnev}, Ki van véve: {Kivaneveve}, kiadási év: {Kiadasiev}, kölcsönzés ideje: {Kolcsonzesideje}, ISBN: {ISBN}";
        }
    }
}
