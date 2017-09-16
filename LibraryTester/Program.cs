using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTester
{
    class Program
    {
        public static void Main(string[] str)
        {
            bool a = true;
            Console.WriteLine(a.Change());
            Console.ReadLine();
        }
    }

    public static class CprBoolExtention
    {
        public static bool Change(this bool b)
        {
            b = !b;
            return b;
        }

        public static bool On(this bool b)
        {
            b = true;
            return true;
        }

        public static bool Off(this bool b)
        {
            b = false;
            return false;
        }
    }
}
