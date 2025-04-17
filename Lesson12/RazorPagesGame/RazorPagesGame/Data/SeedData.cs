using Microsoft.EntityFrameworkCore;
using RazorPagesGame.Data;
using RazorPagesGame.Models;

namespace RazorPagesGame.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesGameContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesGameContext>>()))
            {
                if (context == null || context.Game == null || context.Studio == null)
                {
                    throw new ArgumentNullException("Null RazorPagesGameContext");
                }

                // Look for any studios
                if (context.Studio.Any())
                {
                    return;   // DB has been seeded
                }

                // Add studios
                var studios = new Studio[]
                {
                    new Studio
                    {
                        Name = "Nintendo",
                        FoundedDate = DateTime.Parse("1889-9-23"),
                        Headquarters = "Kyoto, Japan"
                    },
                    new Studio
                    {
                        Name = "Rockstar Games",
                        FoundedDate = DateTime.Parse("1998-12-1"),
                        Headquarters = "New York, USA"
                    },
                    new Studio
                    {
                        Name = "CD Projekt Red",
                        FoundedDate = DateTime.Parse("2002-2-1"),
                        Headquarters = "Warsaw, Poland"
                    }
                };

                context.Studio.AddRange(studios);
                context.SaveChanges();

                // Add games
                var games = new Game[]
                {
                    new Game
                    {
                        Title = "The Legend of Zelda: Breath of the Wild",
                        ReleaseDate = DateTime.Parse("2017-3-3"),
                        Genre = "Action-Adventure",
                        Price = 59.99M,
                        Rating = "E10+",
                        StudioID = studios[0].ID  // Nintendo
                    },
                    new Game
                    {
                        Title = "Red Dead Redemption 2",
                        ReleaseDate = DateTime.Parse("2018-10-26"),
                        Genre = "Action-Adventure",
                        Price = 49.99M,
                        Rating = "M",
                        StudioID = studios[1].ID  // Rockstar Games
                    },
                    new Game
                    {
                        Title = "The Witcher 3: Wild Hunt",
                        ReleaseDate = DateTime.Parse("2015-5-19"),
                        Genre = "RPG",
                        Price = 39.99M,
                        Rating = "M",
                        StudioID = studios[2].ID  // CD Projekt Red
                    },
                    new Game
                    {
                        Title = "Super Mario Odyssey",
                        ReleaseDate = DateTime.Parse("2017-10-27"),
                        Genre = "Platformer",
                        Price = 59.99M,
                        Rating = "E",
                        StudioID = studios[0].ID  // Nintendo
                    },
                    new Game
                    {
                        Title = "Grand Theft Auto V",
                        ReleaseDate = DateTime.Parse("2013-9-17"),
                        Genre = "Action-Adventure",
                        Price = 29.99M,
                        Rating = "M",
                        StudioID = studios[1].ID  // Rockstar Games
                    },
                    new Game
                    {
                        Title = "Cyberpunk 2077",
                        ReleaseDate = DateTime.Parse("2020-12-10"),
                        Genre = "RPG",
                        Price = 49.99M,
                        Rating = "M",
                        StudioID = studios[2].ID  // CD Projekt Red
                    }
                };

                context.Game.AddRange(games);
                context.SaveChanges();
            }
        }
    }
}