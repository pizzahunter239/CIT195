using System;

namespace bookStoreWithCount
{
    class book
    {
        private int _Id;
        private string _Title;
        private string _Author;
        private static int _transactions = 0;

        public book()
        {
            _Id = 0;
            _Title = "";
            _Author = "";
        }

        public book(int id, string title, string author)
        {
            _Id = id;
            _Title = title;
            _Author = author;
        }

        public int GetId()
        {
            return _Id;
        }

        public void SetId(int id)
        {
            _Id = id;
        }

        public string GetTitle()
        {
            return _Title;
        }

        public void SetTitle(string title)
        {
            _Title = title;
        }

        public string GetAuthor()
        {
            return _Author;
        }

        public void SetAuthor(string author)
        {
            _Author = author;
        }

        public void SetTrans()
        {
            _transactions++;
        }

        public int GetTrans()
        {
            return _transactions;
        }
    }

    class myStore
    {
        static void Main(string[] args)
        {
            book book1 = new book();
            book1.SetTrans();
            book1.SetId(1);
            book1.SetTitle("Harry Potter");
            book1.SetAuthor("J.K. Rowling");

            book book2 = new book();
            book2.SetTrans();
            Console.WriteLine("Please enter the book ID: ");
            book2.SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter the book's title: ");
            book2.SetTitle(Console.ReadLine());
            Console.WriteLine("Please enter the book's author: ");
            book2.SetAuthor(Console.ReadLine());

            book book3 = new book(3, "The Lord of The Rings", "J.R.R. Tolkien");
            book3.SetTrans();

            Console.WriteLine("Please enter the book ID: ");
            int tempID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the book's title: ");
            string tempTitle = Console.ReadLine();
            Console.WriteLine("Please enter the book's Author: ");
            string tempAuthor = Console.ReadLine();
            book book4 = new book(tempID, tempTitle, tempAuthor);
            book4.SetTrans();

            Console.WriteLine($"The bookstore has {book1.GetTrans()} new books");
            displayBooks(book1);
            displayBooks(book2);
            displayBooks(book3);
            displayBooks(book4);

        }
        static void displayBooks(book book)
        {
            Console.WriteLine("Here is your book information");
            Console.WriteLine($"Book ID: {book.GetId()}");
            Console.WriteLine($"Book Title: {book.GetTitle()}");
            Console.WriteLine($"Book Author: {book.GetAuthor()}");
        }
    }
}