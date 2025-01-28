using System;

namespace funWithMusic
{
    class Program
    {
        enum Genre
        {
            Classic,
            Metal,
            Alternative,
            Jazz,
            Pop
        }
        struct Music
        {
            private string _Title;
            private string _Artist;
            private string _Album;
            private string _Length;
            private Genre _Genre;

            public Music(string title, string artist, string album, string length, Genre genre)
            {
                _Title = title;
                _Artist = artist;
                _Album = album;
                _Length = length;
                _Genre = genre;
            }

            public string GetTitle()
            {
                return _Title;
            }

            public void SetTitle(string title)
            {
                _Title = title;
            }

            public string GetLength()
            {
                return _Length;
            }

            public void SetLength(string length)
            {
                _Length = length;
            }

            public string Display()
            {
                return $"Title: {_Title}\nArtist: {_Artist}\nAlbum: {_Album}\nLength: {_Length} minutes\nGenre: {_Genre}";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the song title:");
            string tempTitle = Console.ReadLine();

            Console.WriteLine("Who is the artist?");
            string tempArtist = Console.ReadLine();

            Console.WriteLine("What album is it on?");
            string tempAlbum = Console.ReadLine();

            Console.WriteLine("What is the song length?");
            string tempLength = Console.ReadLine();

            Console.WriteLine("What is the music genre?");
            Console.WriteLine("C - Classic\nM - Metal\nA - Alternative\nJ - Jazz\nP - Pop");
            Genre tempGenre = Genre.Classic;
            char genreInput = char.Parse(Console.ReadLine().ToUpper());

            switch (genreInput)
            {
                case 'C':
                    tempGenre = Genre.Classic;
                    break;
                case 'M':
                    tempGenre = Genre.Metal;
                    break;
                case 'A':
                    tempGenre = Genre.Alternative;
                    break;
                case 'J':
                    tempGenre = Genre.Jazz;
                    break;
                case 'P':
                    tempGenre = Genre.Pop;
                    break;
                default:
                    Console.WriteLine("Invalid input, defaulting to Classic.");
                    tempGenre = Genre.Classic;
                    break;
            }

            Music music = new Music(tempTitle, tempArtist, tempAlbum, tempLength, tempGenre);

            Console.WriteLine("\nWhat is the next song on the album?");
            string nextTitle = Console.ReadLine();

            Console.WriteLine("What is the length of the song?");
            string nextLength = Console.ReadLine();

            Music moreMusic = music;
            moreMusic.SetTitle(nextTitle);
            moreMusic.SetLength(nextLength);

            Console.WriteLine("\n" + music.Display());
            Console.WriteLine("\n" + moreMusic.Display());
        }
    }
}
