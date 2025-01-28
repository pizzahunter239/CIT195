using System;

namespace musicArray
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
            private Genre? _Genre;

            public void SetTitle(string title)
            {
                _Title = title;
            }

            public void SetArtist(string artist)
            {
                _Artist = artist;
            }

            public void SetAlbum(string album)
            {
                _Album = album;
            }

            public void SetLength(string length)
            {
                _Length = length;
            }

            public void SetGenre(Genre genre)
            {
                _Genre = genre;
            }

            public string Display()
            {
                return $"Title: {_Title}\nArtist: {_Artist}\nAlbum: {_Album}\nLength: {_Length} minutes\nGenre: {_Genre}";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Please enter the song title:");
                    collection[i].SetTitle(Console.ReadLine());

                    Console.WriteLine("Who is the artist?");
                    collection[i].SetArtist(Console.ReadLine());

                    Console.WriteLine("What album is it on?");
                    collection[i].SetAlbum(Console.ReadLine());

                    Console.WriteLine("What is the song length?");
                    collection[i].SetLength(Console.ReadLine());

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
                    collection[i].SetGenre(tempGenre);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }
    }
}