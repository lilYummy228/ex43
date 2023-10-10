﻿using System;
using System.Collections.Generic;

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
            const string CommandExit = "5";

            Library library = new Library();
            bool isOpen = true;

            while (isOpen)
            {
                Console.Write($"Библиотека\n" +
                    $"{CommandAddBook} - добавить книгу\n" +
                    $"{CommandRemoveBook} - убрать книгу\n" +
                    $"{CommandShowAllBooks} - показать все книги\n" +
                    $"{CommandFindBookByParameter} - найти книгу по параметру\n" +
                    $"{CommandExit} - выход из программы\n" +
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

                    case CommandExit:
                        isOpen = false;
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
            Console.Write("Введите название книги: ");
            string bookName = Console.ReadLine().ToUpper();

            Console.Write("Введите автора книги: ");
            string authorName = Console.ReadLine().ToUpper();

            Console.Write("Введите год выпуска книги: ");

            if (int.TryParse(Console.ReadLine(), out int releaseYear))
            {
                _books.Add(new Book(bookName, authorName, releaseYear));
                Console.WriteLine($"Книга '{bookName}' успешно добавлена...");
            }
            else
            {
                Console.WriteLine("Неккоректный ввод...");
            }
        }

        public void ShowAllBooks()
        {
            if (IsFilled())
            {
                int bookId = 1;
                Console.Clear();

                foreach (Book book in _books)
                {
                    Console.Write($"{bookId}. ");
                    book.ShowInfo();
                    bookId++;
                }
            }
        }

        public void RemoveBook()
        {
            if (IsFilled())
            {
                ShowAllBooks();

                if (TryGetBookById(out Book book))
                {
                    _books.Remove(book);
                    Console.WriteLine($"Книга '{book.Name}' успешно удалена...");
                }
                else
                {
                    Console.WriteLine("Книга с таким номером отсутствует...");
                }
            }
        }

        public void FindBookByParameter()
        {
            if (IsFilled())
            {

                const string CommandFindByName = "1";
                const string CommandFindByAuthor = "2";
                const string CommandFindByReleaseYear = "3";
                const string CommandGetBack = "4";

                Console.Clear();
                Console.Write($"Найти книгу по параметру\n" +
                    $"{CommandFindByName} - найти по названию\n" +
                    $"{CommandFindByAuthor} - найти по автору\n" +
                    $"{CommandFindByReleaseYear} - найти по дате релиза\n" +
                    $"{CommandGetBack} - вернуться назад\n" +
                    $"\nВаш ввод: ");

                switch (Console.ReadLine())
                {
                    case CommandFindByName:
                        FindBookByName();
                        break;

                    case CommandFindByAuthor:
                        FindBookByAuthor();
                        break;

                    case CommandFindByReleaseYear:
                        FindBookByReleaseYear();
                        break;

                    case CommandGetBack:
                        Console.WriteLine("Возвращаемся назад...");
                        break;

                    default:
                        Console.WriteLine("Неккоректный ввод...");
                        break;
                }
            }
        }

        private void FindBookByName()
        {
            Console.Write("\nВведите название книги: ");
            string nameOfBook = Console.ReadLine().ToUpper();

            foreach (Book book in _books)
            {
                if (nameOfBook == book.Name)
                {
                    book.ShowInfo();
                }
            }
        }

        private void FindBookByAuthor()
        {
            Console.Write("\nВведите автора: ");
            string nameOfAuthor = Console.ReadLine().ToUpper();

            foreach (Book book in _books)
            {
                if (nameOfAuthor == book.Author)
                {
                    book.ShowInfo();
                }
            }
        }

        private void FindBookByReleaseYear()
        {
            Console.Write("\nВведите год выпуска: ");

            if (int.TryParse(Console.ReadLine(), out int releaseYear))
            {
                foreach (Book book in _books)
                {
                    if (releaseYear == book.Year)
                    {
                        book.ShowInfo();
                    }
                }
            }
        }

        private bool TryGetBookById(out Book book)
        {
            Console.Write("\nВведите ID книги: ");

            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                if (bookId > 0 && bookId - 1 < _books.Count)
                {
                    book = _books[bookId - 1];
                    return true;
                }
                else
                {
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

        private bool IsFilled()
        {
            if (_books.Count > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Библиотека пуста...");
                return false;
            }
        }
    }

    class Book
    {
        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название книги: '{Name}'\nАвтор: {Author}\nГод выпуска: {Year} год\n");
        }
    }
}