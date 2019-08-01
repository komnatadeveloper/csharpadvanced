using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //  DateTime date = null; diyemezsin

            Nullable<DateTime> date = null;
            DateTime? date1 = null;

            DateTime date2;

            var str = "apple";
            var str1 = "apple.";


            dynamic varName = "Emrah";
            varName = 5;
            varName = DateTime.Today;

            dynamic a = 5;
            dynamic b = 10;
            var c = a + b;
            int d = a + b;
            

            var hashCode = str.GetHashCode();
            var hashCode2 = str1.GetHashCode();
            var hashCode3 = str1.GetHashCode();

            Console.WriteLine(hashCode);
            Console.WriteLine(hashCode2);
            Console.WriteLine(hashCode3);

            
        }
    }
}
