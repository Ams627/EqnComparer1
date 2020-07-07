using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace EqnComparer1
{
    class X
    {
        public string Str1 { get; set; }
        public string Str2 { get; set; }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode($"{Str1}{Str2}");
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is X x)
            {
                return x.Str1.Equals(Str1, StringComparison.OrdinalIgnoreCase) && x.Str2.Equals(Str2, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }


    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var h = new HashSet<X>();

                var a = new X { Str1 = "Wonk", Str2 = "Wink" };
                var c = new X { Str1 = "wonk", Str2 = "wink" };
                var b = a;

                if (a.Equals(b))
                {
                    Console.WriteLine($"Equal");
                }

                if (a.Equals(c))
                {
                    Console.WriteLine($"Equal");
                }

                h.Add(new X { Str1 = "hello", Str2 = "world" });
                h.Add(new X { Str1 = "Hello", Str2 = "World" });
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
