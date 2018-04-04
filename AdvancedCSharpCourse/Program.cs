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
