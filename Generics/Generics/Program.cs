using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class List
    {
        public void Add(int number)
        {
            throw new NotImplementedException();
        }

        public int this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class GenericList <T>    // T burada Template anlamında sanırım
    {
        public void Add(T value)  // Tnin ne oldugu henüz şu aşamada belli değil, bu classı kullanan belirleyecek.
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
