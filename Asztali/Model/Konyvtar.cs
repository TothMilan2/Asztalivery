using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztali.Model
{
    internal class Konyvtar
    {
        private readonly string _name;

        public override string ToString()
        {
            return $"bookID: {BookID}, cím: {Booknev}, Ki van véve: {Kivaneveve}, kiadási év: {Kiadasiev}, kölcsönzés ideje: {Kolcsonzesideje}, ISBN: {ISBN}";
        }
    }
}
