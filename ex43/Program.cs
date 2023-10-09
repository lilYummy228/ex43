using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex43
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandShowBookByParameter = "4";

            Console.Write($"Библиотека\n" +
                $"{CommandAddBook} - добавить книгу\n" +
                $"{CommandRemoveBook} - убрать книгу\n" +
                $"{CommandShowAllBooks} - показать все книги\n" +
                $"{CommandShowBookByParameter} - показать книгу по параметру\n");

            switch (Console.ReadLine())
            {
                case CommandAddBook:
                    break;

                case CommandRemoveBook:
                    break;

                case CommandShowAllBooks:
                    break;

                case CommandShowBookByParameter:
                    break;

                default:
                    Console.WriteLine("Неккоректный ввод...");
                    break;
            }
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {

        }
    }

    class Book
    {
        private string _name;
        private string _author;
        private int _year;

        public Book(string name, string author, int year)
        {
            _name = name;
            _author = author;
            _year = year;
        }
    }
}
