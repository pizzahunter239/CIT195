using System;

namespace MusicLibraryApp
{
    public class Song
    {
        // Properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public int DurationInSeconds { get; set; }
        public double Rating { get; set; } // Rating from 0.0 to 5.0

        // Constructor
        public Song(string title, string artist, int durationInSeconds, double rating)
        {
            Title = title;
            Artist = artist;
            DurationInSeconds = durationInSeconds;
            Rating = rating;
        }

        // Display method for easy output
        public void Display()
        {
            Console.WriteLine($"'{Title}' by {Artist} - {DurationInSeconds / 60}:{DurationInSeconds % 60:D2} - Rating: {Rating:F1}/5.0");
        }

        // 1. Unary operator overload: ++ (increases rating by 0.5, max 5.0)
        public static Song operator ++(Song song)
        {
            if (song.Rating < 5.0)
            {
                song.Rating = Math.Min(5.0, song.Rating + 0.5);
            }
            return song;
        }

        // 2. Comparison operator overload: > (compares songs based on rating)
        public static bool operator >(Song song1, Song song2)
        {
            return song1.Rating > song2.Rating;
        }

        // 2. Comparison operator overload: < (compares songs based on rating)
        public static bool operator <(Song song1, Song song2)
        {
            return song1.Rating < song2.Rating;
        }

        // 3. Binary operator overload: + (combines two songs into a mashup with averaged rating)
        public static Song operator +(Song song1, Song song2)
        {
            string mashupTitle = $"{song1.Title} x {song2.Title} (Mashup)";
            string mashupArtist = $"{song1.Artist} & {song2.Artist}";
            int combinedDuration = (song1.DurationInSeconds + song2.DurationInSeconds) / 2; // Average duration
            double combinedRating = (song1.Rating + song2.Rating) / 2; // Average rating

            return new Song(mashupTitle, mashupArtist, combinedDuration, combinedRating);
        }

        // For completeness, implementing == and != operators
        public static bool operator ==(Song song1, Song song2)
        {
            if (ReferenceEquals(song1, null) && ReferenceEquals(song2, null))
                return true;
            if (ReferenceEquals(song1, null) || ReferenceEquals(song2, null))
                return false;

            return song1.Title == song2.Title &&
                   song1.Artist == song2.Artist &&
                   song1.DurationInSeconds == song2.DurationInSeconds;
        }

        public static bool operator !=(Song song1, Song song2)
        {
            return !(song1 == song2);
        }

        // Override Equals and GetHashCode for proper object equality
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Song other = (Song)obj;
            return this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Artist, DurationInSeconds);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Music Library - Song Class with Operator Overloading\n");

            // Creating song objects
            Song song1 = new Song("Bohemian Rhapsody", "Queen", 354, 4.5);
            Song song2 = new Song("Hotel California", "Eagles", 390, 4.0);
            Song song3 = new Song("Imagine", "John Lennon", 183, 3.5);

            // Displaying original songs
            Console.WriteLine("Original Songs:");
            song1.Display();
            song2.Display();
            song3.Display();
            Console.WriteLine();

            // Using unary operator (++)
            Console.WriteLine("After increasing rating with ++ operator:");
            song1++;
            song2++;
            song2++; // Doing it twice for song2
            song1.Display();
            song2.Display();
            Console.WriteLine();

            // Using comparison operators
            Console.WriteLine("Comparison Operators Results:");
            Console.WriteLine($"Is '{song1.Title}' rated higher than '{song2.Title}'? {song1 > song2}");
            Console.WriteLine($"Is '{song3.Title}' rated higher than '{song2.Title}'? {song3 > song2}");
            Console.WriteLine($"Is '{song3.Title}' rated lower than '{song1.Title}'? {song3 < song1}");
            Console.WriteLine();

            // Using binary operator (+)
            Console.WriteLine("Creating mashups with + operator:");
            Song mashup1 = song1 + song2;
            mashup1.Display();

            Song mashup2 = song2 + song3;
            mashup2.Display();
            Console.WriteLine();

            // Demonstrating all three types of operators together
            Console.WriteLine("Combining operators in sequence:");
            Song newSong = new Song("Yesterday", "The Beatles", 125, 3.0);
            Console.WriteLine("Starting with:");
            newSong.Display();

            newSong++; // Unary: increase rating
            Console.WriteLine("After ++:");
            newSong.Display();

            Console.WriteLine($"Is it now rated higher than '{song3.Title}'? {newSong > song3}"); // Comparison

            Song finalMashup = newSong + song1; // Binary: create mashup
            Console.WriteLine("Final mashup with highest rated song:");
            finalMashup.Display();
        }
    }
}