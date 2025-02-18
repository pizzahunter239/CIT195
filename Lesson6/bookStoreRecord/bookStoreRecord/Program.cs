using System;
namespace bookStoreRecord
{
    class Program
    {
        public record Bookstore(int ID, string Title, string Author, double Price);

        public static void Main()
        {
            Bookstore book1 = new(1, "The Great Gatsby", "F. Scott Fitzgerald", 12.99);
            Bookstore book2 = new(2, "1984", "George Orwell", 14.99);
            Bookstore book3 = new(3, "Pride and Prejudice", "Jane Austen", 11.99);

            Console.WriteLine("Book 1: " + book1);
            Console.WriteLine("Book 2: " + book2);
            Console.WriteLine("Book 3: " + book3);
        }
    }
}