using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // LAMBDA EXPRESS İLE
            // args => expression
            //number => number * number;

            // Func<> örnek olarak built-in bir delegate tir..
            //Action<> da bir built-int delegate tir.
            Func<int, int> square = Square;
            //veya
            Func<int, int> square1 = number => number * number;

            Console.WriteLine(Square(5)  );     //25
            Console.WriteLine(square(5)  );     //25
            Console.WriteLine(square1(5)  );    //25

            var books = new BookRepository().GetBooks();

            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            // daha da güzeli, lambda expression ile
            var cheapBooks1 = books.FindAll(book => book.Price < 10);
            // c# dilinde bu tarz şeylerde tek harf kullanmayı da çok severlermiş, altta:
            var cheapBooks2 = books.FindAll(b => b.Price < 10);

            
        }

        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }

        static int Square(int number)
        {
            return number * number;
        }
    }

    public class Book
    {
        public int Price;
        public string Title;
    }
}
