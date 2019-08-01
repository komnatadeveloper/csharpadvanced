using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "ADO.NET Step by Step", Price = 5},
                new Book() {Title = "ASP.NET MVC", Price = 9.99f},
                new Book() {Title = "ASP.NET Web API", Price = 12},
                new Book() {Title = "C# Advanced Topics", Price = 7},
                new Book() {Title = "C# Advanced Topics", Price = 12}
            };
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Price < 10)
                    cheapBooks.Add(book);
            }

            // ŞİMDİ AYNI FİLTRELEMEYİ LINQ İLE YAPALIM

            // LINQ Extension Methods

            var cheapBooks1 = books.Where(b => b.Price < 10);   // Lambda Expression ve where sorgusu

            // orderby kullanalım
            var cheapBooks2 = books.OrderBy(b => b.Title);

            // ucuca ekleyip, hem fiyata göre filtreleyip, hem Title a gore sıralayalım
            var cheapBooks3 = books.Where(b => b.Price < 10).OrderBy(b => b.Title);

            // ucuca ekleyip, hem fiyata göre filtreleyip, hem Title a gore sıralayalım. Select ekleyelim.
            // select projection veya transformation için kullanılıyormuş
            // sadece Title listesi oluştu yani string generic listesi
            var cheapBooks4 = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title);
            // (Yukarıdaki şekildeki gibi nokta, altsatırda devam etmeye, LINQ Extension Methods diyoruz.)


            // Single ile sadece tek birşey seçebiliriz. Fakat dikkat et, eğer o filtren bulunamazsa, app hata verir önlem de almamışsan
            var cheapBooks6 = books.Single(b => b.Title == "ASP.NET MVC");

            // O objectin olmaması riski de varsa, SingleOrDefault kullanırız. Alttaki örnekte default olarak null gelir bulunamazsa...
            var cheapBooks7 = books.SingleOrDefault(b => b.Title == "ASP.NET MVC++");  // ++ eklediigimiz için bulunamıycak.


            // First, aynısından sadece ilkini bulur - bulamazsa hata verir
            var cheapBooks8 = books.First(b => b.Title == "C# Advanced Topics");  

            // FirstOrDefault, ilki, ama hiç bulamazsa default olarak bu örnekte null
            var cheapBooks9 = books.FirstOrDefault(b => b.Title == "C# Advanced Topics");
            
            // Last, aynısından sadece sonuncuyu bulur - bulamazsa hata verir
            var cheapBooks10 = books.Last(b => b.Title == "C# Advanced Topics");  

            // LastOrDefault, sonuncusu, ama hiç bulamazsa default olarak bu örnekte null
            var cheapBooks11 = books.LastOrDefault(b => b.Title == "C# Advanced Topics");

            // Skip() ve Take() - ilk 2 tanesini atla, sonra 3 tanesini al
            var cheapBooks12 = books.Skip(2).Take(3);

            // SQL deki gibi Aggregate Func da var. mesela Count()
            var bookCount = books.Count();

            // SQL deki Max() - tabi price a göre max olmasını biz söylüycez - float type a return ediyor, çünkü class Books ta, Price type float
            var highestPrice = books.Max( b => b.Price);  // type: float

            // Min()
            var minPrice = books.Min(b => b.Price);  // type: float
            
            // Sum() - tüm kitapların fiyatı toplamı
            var totalPrice = books.Sum(b => b.Price);  // type: float
            
            // Average() - tüm kitapların ortalama fiyatı
            var avgPrice = books.Average(b => b.Price);  // type: float

            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title + " " + book.Price);

            foreach (var book in cheapBooks4)
                Console.WriteLine(book);

            foreach (var book in cheapBooks12)
            Console.WriteLine(book.Title + " " + book.Price);



            // LINQ Query Methods
            var cheapBooks5 = from b in books
                              where b.Price < 10
                              orderby b.Title
                              select b.Title;


        }
    }
}
