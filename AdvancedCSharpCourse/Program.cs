using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvancedCSharpCourse
{

    class Program
    {
        static void Main(string[] args)
        {
            //Generics();

            //Delegates();

            //LambdaExpressions();

            //Events();

            // ExtensionMethods();

            //Linq();

            //NullableTypes();

            //Dynamics();

            ExceptionHandling();
        }

        private static void ExceptionHandling()
        {
            try
            {
                var calc = new Calculator();
                calc.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
               
            }

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"c:\file.zip");
                var content = streamReader.ReadToEnd();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }

            try
            {
                using (var streamReader1 = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader.ReadToEnd();
                }       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("mosh");
            }
            catch(Exception ex)
            {
                Console.WriteLine("YouTube Api exception: " + ex.Message);
            }
        }

        private static void Dynamics()
        {
            //dynamic excelObject = "Mosh";
            //excelObject.Optimize();

            //dynamic name = "Mosh";
            //name++;// runtime exception

            //dynamic a = 10;
            //dynamic b = 5;
            //var c = a + b; // will be dynamic as well

            int i = 5;
            dynamic d = i; //will be an integer during the runtime
            long l = d; //not need for explicit casting

        }

        private static void NullableTypes()
        {
            //Nullable<DateTime> time = null;
            //same as above
            DateTime? date = null;// new DateTime(2018, 1, 1);
            DateTime date1 = date.GetValueOrDefault(); //assign a nulluble to not nulluble by using the GetValueOrDefault() method.
            DateTime? date2 = date1; //assign an not nulluble to nulluble, not a problem at all.

            //Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            //Console.WriteLine("HasValue: " + date.HasValue);
            //Console.WriteLine("Value: " + date.Value);

            if (date != null)
            {
                date2 = date.GetValueOrDefault();
            }
            else
            {
                date2 = DateTime.Today;
            }
            //shorter implementaion of the code above
            date2 = date ?? DateTime.Today;

            Console.WriteLine(date2);
        }

        private static void Linq()
        {
            var books = new BookRepository().GetBooks();

            //var cheapBooks = new List<Book>();
            //foreach(var book in books)
            //{
            //    if(book.Price < 10)
            //    {
            //        cheapBooks.Add(book);
            //    }
            //}


            ////instead of the code about use linq
            //var cheapBooks = books
            //                    .Where(book => (book.Price < 10))
            //                    .OrderBy(book => book.Price)
            //                    .Select(book => book.Title);

            ////books.OrderBy(book => book.Title);

            ////LINQ Query Operators
            //var cheaperBooks =
            //    from book in books
            //    where book.Price < 10
            //    orderby book.Price
            //    select book.Title;

            //foreach (var book in cheapBooks)
            //{
            //    //Console.WriteLine(book.Title + " " + book.Price);
            //    Console.WriteLine(book);
            //}

            //LINQ Extension Methods
            //var book = books.Single(b => b.Title == "ASP.NET MVC");
            //var book = books.SingleOrDefault(b => b.Title == "ASP. NET MVC");
            //Console.WriteLine(book == null);

            //var book = books.First(b => b.Title == "C# Advanced Topics");
            //Console.WriteLine(book.Title + " " + book.Price);

            //var PagedBooks = books.Skip(2).Take(3);
            //foreach(var book in PagedBooks)
            //{
            //    Console.WriteLine(book.Title);
            //}

            //var count = books.Count();
            //Console.WriteLine(count);

            var maxPrice = books.Max(b => b.Price);
            var minPrice = books.Min(b => b.Price);
            Console.WriteLine(maxPrice);
            Console.WriteLine(minPrice);
        }


        private static void ExtensionMethods()
        {
            string post = "This is supposed to be very long blog post blah blah blah...";
            var shortenPost = post.Shorten(5);

            Console.WriteLine(shortenPost);
        }
        
        static void Events()
        {
            var video = new Video { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //event publisher
            var mailService = new MailService(); //event subscriber
            var messageService = new MessageService(); //event subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            videoEncoder.Encode(video);
        }

        static void LambdaExpressions()
        {
            // Basic syntax for lambda expression "args => expression"
            // without arguments "() => ..."
            // one argument "x => ..."
            // more argumetnts "(x, y, z) => ..."

            //Func<int, int> square = (number => number * number);

            //const int factor = 5;

            //Func<int, int> mulitplier = n => n * factor;

            //var result = mulitplier(10);

            //Console.WriteLine(result);

            var books = new BookRepository().GetBooks();

            //static bool IsCheaperThan10Dollars(Book book)
            //{
            //    return (book.Price < 10);
            //}
            //previos commented out function can be exchanged by lambda expresion
            var cheapBooks = books.FindAll(book => book.Price < 10);

            foreach(var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }
        }

        static void Delegates()
        {
            PhotoPrecessor photoPrecessor = new PhotoPrecessor();
            var filters = new PhotoFilters();

            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyes;

            photoPrecessor.Process("pathToNowhere", filterHandler);

        }

        static void RemoveRedEyes(Photo photo)
        {
            Console.WriteLine("Apply remove red eyes.");
        }

        static void Generics()
        {
            //var numbers = new List();
            //numbers.Add(10);

            var book = new Book { Isbn = "1111", Title = "C# Advanced" };
            //var books = new BookList();
            //books.Add(book);

            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(book);

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            var number = new Nullable<int>();
            Console.WriteLine("Has Value ? -> " + number.HasValue);
            Console.WriteLine("Value: " + number.GetVlaueOrDefault());
        }
    }
}
