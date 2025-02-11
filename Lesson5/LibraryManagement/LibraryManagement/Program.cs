using System;

abstract class LibraryItem
{
    public string Title { get; set; }
    public string ISBN { get; set; }

    public abstract void DisplayDetails();

    protected LibraryItem(string title, string isbn)
    {
        Title = title;
        ISBN = isbn;
    }
}

class Book : LibraryItem
{
    public string Author { get; set; }

    public Book(string title, string author, string isbn) : base(title, isbn)
    {
        Author = author;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine("Book Details:");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Library Management System\n");

        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0333791035");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "978-2253115847");

        book1.DisplayDetails();
        book2.DisplayDetails();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
