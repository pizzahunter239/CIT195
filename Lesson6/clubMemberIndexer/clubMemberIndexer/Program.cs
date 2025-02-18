using System;

namespace Indexer_example1
{
    class Program
    {
        public const int Size = 15;

        class ClubMembers
        {
            private string[] Members = new string[Size];

            public string ClubType { get; set; }
            public string ClubLocation { get; set; }
            public string MeetingDate { get; set; }

            public ClubMembers()
            {
                for (int i = 0; i < Size; i++)
                {
                    Members[i] = string.Empty;
                }

                ClubType = string.Empty;
                ClubLocation = string.Empty;
                MeetingDate = string.Empty;
            }

            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index <= Size - 1)
                    {
                        return Members[index];
                    }
                    return string.Empty;
                }
                set
                {
                    if (index >= 0 && index <= Size - 1)
                    {
                        Members[index] = value;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ClubMembers bookClub = new ClubMembers();

            bookClub[0] = "John Doe";
            bookClub[1] = "Jane Smith";
            bookClub[2] = "Bobby Brown";
            bookClub[3] = "Cade Alpers";

            bookClub.ClubType = "Book Reading Club";
            bookClub.ClubLocation = "City Library";
            bookClub.MeetingDate = "Every Tuesday at 6 PM";

            Console.WriteLine("Club Information:");
            Console.WriteLine($"Type: {bookClub.ClubType}");
            Console.WriteLine($"Location: {bookClub.ClubLocation}");
            Console.WriteLine($"Meeting Date: {bookClub.MeetingDate}");
            Console.WriteLine("\nClub Members:");

            for (int i = 0; i < Size; i++)
            {
                if (bookClub[i] != string.Empty)
                {
                    Console.WriteLine($"Member {i + 1}: {bookClub[i]}");
                }
            }
        }
    }
}
