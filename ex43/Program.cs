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
            const string CommandFindBookByParameter = "4";

            Library library = new Library();
            bool isOpen = true;

            while (isOpen)
            {
                Console.Write($"Библиотека\n" +
                    $"{CommandAddBook} - добавить книгу\n" +
                    $"{CommandRemoveBook} - убрать книгу\n" +
                    $"{CommandShowAllBooks} - показать все книги\n" +
                    $"{CommandFindBookByParameter} - показать книгу по параметру\n\n" +
                    $"Ваш ввод: ");

                switch (Console.ReadLine())
                {
                    case CommandAddBook:
                        library.AddBook();
                        break;

                    case CommandRemoveBook:
                        library.RemoveBook();
                        break;

                    case CommandShowAllBooks:
                        library.ShowAllBooks();
                        break;

                    case CommandFindBookByParameter:
                        library.FindBookByParameter();
                        break;

                    default:
                        Console.WriteLine("Неккоректный ввод...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();

            }
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public void AddBook()
        {
            int bookId = _books.Count + 1;

            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine().ToUpper();

            Console.Write("Введите автора книги: ");
            string authorName = Console.ReadLine().ToUpper();

            Console.Write("Введите год выпуска книги: ");

            if (int.TryParse(Console.ReadLine(), out int releaseYear))
            {
                _books.Add(new Book(bookId, bookName, authorName, releaseYear));
                Console.WriteLine($"Книга '{bookName}' успешно добавлена...");
            }
            else
            {
                Console.WriteLine("Неккоректный ввод...");
            }
        }

        public void ShowAllBooks()
        {
            if (_books.Count > 0)
            {
                foreach (var book in _books)
                {
                    book.ShowInfo();
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Библиотека пуста...");
            }
        }

        public void RemoveBook()
        {
            ShowAllBooks();

            if (TryGetBook(out Book book))
            {
                _books.Remove(book);
            }
        }

        public void FindBookByParameter()
        {
            const string CommandFindByName = "1";
            const string CommandFindByAuthor = "2";
            const string CommandFindByYear = "3";

            Console.Write($"{CommandFindByName} - найти по названию\n" +
                $"{CommandFindByAuthor} - найти по автору\n" +
                $"{CommandFindByYear} - найти по дате релиза\n\n" +
                $"Ваш ввод: ");

            switch (Console.ReadLine())
            {
                case CommandFindByName:
                    Console.Write("Введите название книги: ");
                    string nameOfBook = Console.ReadLine().ToUpper();

                    foreach (var book in _books)
                    {
                        if (nameOfBook == book.Name)
                        {
                            book.ShowInfo();
                        }
                    }

                    break;

                case CommandFindByAuthor:
                    Console.Write("Введите автора: ");
                    string nameOfAuthor = Console.ReadLine().ToUpper();

                    foreach (var book in _books)
                    {
                        if (nameOfBook == book.Name)
                        {
                            book.ShowInfo();
                        }
                    }
                    break;

                case CommandFindByYear:
                    break;

                default:
                    Console.WriteLine("Неккоректный ввод...");
                    break;
            }
        }

        private bool TryGetBook(out Book book)
        {
            Console.Write("Введите номер удаляемой книги: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                if (bookId > 0 && bookId - 1 < _books.Count)
                {
                    book = _books[bookId - 1];
                    Console.WriteLine($"Книга под номером {bookId} успешно удалена...");
                    return true;
                }
                else
                {
                    Console.WriteLine("Книга с таким номером отсутствует...");
                    book = null;
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Неккоректный ввод...");
                book = null;
                return false;
            }
        }
    }

    class Book
    {
        private int _bookId;

        public Book(int bookId, string name, string author, int year)
        {
            _bookId = bookId;
            Name = name;
            Author = author;
            Year = year;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{_bookId}. Название книги: '{Name}'\nАвтор: {Author}\nГод выпуска: {Year} год");
        }
    }
}
