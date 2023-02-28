// Nguyễn Bá Thiết
using System;
using System.Collections;
using System.Collections.Generic;

namespace Bai4_2_1
{
    interface IBook : IComparable<IBook>
    {
        string this[int index]
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }
        string Author
        {
            get;
            set;
        }
        string Publisher
        {
            get;
            set;
        }
        string ISBN
        {
            get;
            set;
        }
        int Year
        {
            get;
            set;
        }
        void Show();
    }

    class Book : IBook
    {
        private string isbn;
        private string title;
        private string author;
        private string publisher;
        private int year;
        private ArrayList chapter = new ArrayList();

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < chapter.Count)
                    return (string)chapter[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < chapter.Count)
                    chapter[index] = value;
                else if (index == chapter.Count)
                    chapter.Add(value);
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public void Show()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Publisher: " + publisher);
            Console.WriteLine("Year: " + year);
            Console.WriteLine("ISBN: " + isbn);
            Console.WriteLine("Chapter: ");
            for (int i = 0; i < chapter.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}: {chapter[i]}");
            }
            Console.WriteLine("----------------");
        }

        public void Input()
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write("Author: ");
            author = Console.ReadLine();
            Console.Write("Publisher: ");
            publisher = Console.ReadLine();
            Console.Write("ISBN: ");
            isbn = Console.ReadLine();
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input chapter(finish with empty string)");
            string str;
            do
            {
                str = Console.ReadLine();
                if (str.Length > 0)
                    chapter.Add(str);
            } while (str.Length > 0);
        }

        public int CompareTo(IBook other)
        {
            // Sắp xếp theo tiêu chí title, author, publisher, hoặc year
            return this.Title.CompareTo(other.Title);
        }
    }

    class BookList
    {
        private ArrayList list = new ArrayList();

        public void AddBook()
        {
            Book b = new Book();
            b.Input();
            list.Add(b);
        }
        public void ShowList()
        {
            foreach (Book b in list)
                b.Show();
        }
        public void InputList()
        {
            int n;
            Console.Write("Amount of books: ");
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                AddBook();
                n--;
            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                BookList bl = new BookList();
                bl.InputList();
                bl.ShowList();
                Console.ReadLine();

            }
        }

    }
}