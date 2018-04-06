using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            ExtensionMethods();
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
