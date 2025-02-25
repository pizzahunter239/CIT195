using System;
using System.Collections.Generic;

namespace BookCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = Menu();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        UseQueue();
                        break;
                    case 2:
                        UseStack();
                        break;
                    case 3:
                        UseLinkedList();
                        break;
                    case 4:
                        UseDictionary();
                        break;
                    case 5:
                        UseHashSet();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                choice = Menu();
            }
        }

        static int Menu()
        {
            int choice = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book Collections");
            Console.WriteLine("1. Queue - Reading List");
            Console.WriteLine("2. Stack - Book Return Pile");
            Console.WriteLine("3. LinkedList - Book Series Order");
            Console.WriteLine("4. Dictionary - Authors and Their Books");
            Console.WriteLine("5. HashSet - Book Genres");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                choice = input;
            }
            Console.ForegroundColor = ConsoleColor.White;
            return choice;
        }

        static void UseQueue()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Reading List Queue");

            Queue<string> readingList = new Queue<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Add a book to your reading list: ");
                readingList.Enqueue(Console.ReadLine());
            }

            Console.WriteLine("Number of books in your reading list: " + readingList.Count);

            Console.Write("Enter a book title to check if it's in your reading list: ");
            string bookToCheck = Console.ReadLine();
            if (readingList.Contains(bookToCheck))
            {
                Console.WriteLine("\"" + bookToCheck + "\" is in your reading list.");
            }
            else
            {
                Console.WriteLine("\"" + bookToCheck + "\" is not in your reading list.");
            }

            Console.WriteLine("You finished reading a book! Removing the first book from your list...");
            string finishedBook = readingList.Dequeue();
            Console.WriteLine("You finished reading: \"" + finishedBook + "\"");

            Console.WriteLine("Books remaining in your reading list (" + readingList.Count + "):");
            foreach (var book in readingList)
            {
                Console.WriteLine("- " + book);
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void UseStack()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book Return Stack");

            Stack<string> bookReturnPile = new Stack<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Add a book to your return pile: ");
                bookReturnPile.Push(Console.ReadLine());
            }

            Console.WriteLine("Number of books in your return pile: " + bookReturnPile.Count);

            Console.Write("Enter a book title to check if it's in your return pile: ");
            string bookToCheck = Console.ReadLine();
            if (bookReturnPile.Contains(bookToCheck))
            {
                Console.WriteLine("\"" + bookToCheck + "\" is in your return pile.");
            }
            else
            {
                Console.WriteLine("\"" + bookToCheck + "\" is not in your return pile.");
            }

            Console.WriteLine("Returning the top book from your pile to the library...");
            string returnedBook = bookReturnPile.Pop();
            Console.WriteLine("You returned: \"" + returnedBook + "\"");

            Console.WriteLine("Books remaining in your return pile (" + bookReturnPile.Count + "):");
            foreach (var book in bookReturnPile)
            {
                Console.WriteLine("- " + book);
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void UseLinkedList()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book Series LinkedList");

            LinkedList<string> bookSeries = new LinkedList<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Add book #" + (i + 1) + " to the series: ");
                bookSeries.AddLast(Console.ReadLine());
            }

            Console.WriteLine("Number of books in the series: " + bookSeries.Count);

            Console.WriteLine("First book in the series: " + bookSeries.First.Value);

            Console.WriteLine("Last book in the series: " + bookSeries.Last.Value);

            Console.Write("Enter a book in the series to find: ");
            string bookToFind = Console.ReadLine();
            LinkedListNode<string> node = bookSeries.Find(bookToFind);
            if (node != null)
            {
                Console.Write("Enter a new book to add before \"" + bookToFind + "\": ");
                bookSeries.AddBefore(node, Console.ReadLine());
                Console.WriteLine("New book added to the series!");
            }
            else
            {
                Console.WriteLine("Book not found in the series.");
            }

            Console.Write("Enter a book to remove from the series: ");
            string bookToRemove = Console.ReadLine();
            if (bookSeries.Remove(bookToRemove))
            {
                Console.WriteLine("\"" + bookToRemove + "\" removed from the series.");
            }
            else
            {
                Console.WriteLine("Book not found in the series.");
            }

            Console.WriteLine("Books in the series (" + bookSeries.Count + "):");
            foreach (var book in bookSeries)
            {
                Console.WriteLine("- " + book);
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void UseDictionary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Authors and Books Dictionary");

            Dictionary<string, string> authorBooks = new Dictionary<string, string>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter an author's name: ");
                string author = Console.ReadLine();
                Console.Write("Enter their most famous book: ");
                string book = Console.ReadLine();
                authorBooks[author] = book;
            }

            Console.WriteLine("\nAuthors and their famous books:");
            foreach (var entry in authorBooks)
            {
                Console.WriteLine(entry.Key + " wrote \"" + entry.Value + "\"");
            }

            Console.WriteLine("\nAuthors:");
            foreach (var author in authorBooks.Keys)
            {
                Console.WriteLine("- " + author);
            }

            Console.WriteLine("\nBooks:");
            foreach (var book in authorBooks.Values)
            {
                Console.WriteLine("- \"" + book + "\"");
            }

            Console.Write("\nEnter an author to remove: ");
            string authorToRemove = Console.ReadLine();
            if (authorBooks.ContainsKey(authorToRemove))
            {
                string removedBook = authorBooks[authorToRemove];
                authorBooks.Remove(authorToRemove);
                Console.WriteLine("Removed " + authorToRemove + " and their book \"" + removedBook + "\"");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }

            Console.WriteLine("\nNumber of authors in dictionary: " + authorBooks.Count);
            Console.WriteLine("Updated authors and books:");
            foreach (var entry in authorBooks)
            {
                Console.WriteLine(entry.Key + " wrote \"" + entry.Value + "\"");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        static void UseHashSet()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Book Genres HashSet");

            Console.WriteLine("Create your first list of favorite book genres...");
            HashSet<string> favoriteGenres1 = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter genre #" + (i + 1) + ": ");
                favoriteGenres1.Add(Console.ReadLine());
            }

            Console.WriteLine("\nCreate your friend's list of favorite book genres...");
            HashSet<string> favoriteGenres2 = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter genre #" + (i + 1) + ": ");
                favoriteGenres2.Add(Console.ReadLine());
            }

            Console.WriteLine("\nCreate your book club's list of favorite genres...");
            HashSet<string> favoriteGenres3 = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter genre #" + (i + 1) + ": ");
                favoriteGenres3.Add(Console.ReadLine());
            }

            Console.WriteLine("\nCombining your genres with your friend's genres...");
            favoriteGenres1.UnionWith(favoriteGenres2);

            Console.WriteLine("Combined unique genres (" + favoriteGenres1.Count + "):");
            foreach (var genre in favoriteGenres1)
            {
                Console.WriteLine("- " + genre);
            }

            Console.WriteLine("\nNow combining with your book club's genres...");
            favoriteGenres1.UnionWith(favoriteGenres3);

            Console.WriteLine("All unique genres (" + favoriteGenres1.Count + "):");
            foreach (var genre in favoriteGenres1)
            {
                Console.WriteLine("- " + genre);
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }
    }
}