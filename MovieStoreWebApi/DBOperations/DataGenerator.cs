using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using(var context=new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>())) 
            { 
                if(context.Movies.Any()) 
                {
                    return;
                }

                context.Movies.AddRange(new Movie
                {
                    MovieId = 1,
                    MovieName = "Film 1",
                    MovieYear = 2021,
                    GenreId = "Action",
                    Director = new Director { DirectorName = "Director 1" },
                    Actors = new List<Actor>
                    {
                        new Actor { ActorName = "Actor 1" },
                        new Actor { ActorName = "Actor 2" }
                    },
                    Price = 9.99m
                },
                new Movie
                {
                    MovieId = 2,
                    MovieName = "Film 2",
                    MovieYear = 2020,
                    GenreId = "Comedy",
                    Director = new Director { DirectorName = "Director 2" },
                    Actors = new List<Actor>
                    {
                        new Actor { ActorName = "Actor 3" },
                        new Actor { ActorName = "Actor 4" }
                    },
                    Price = 7.99m
                },
                new Movie
                {
                    MovieId = 3,
                    MovieName = "Film 3",
                    MovieYear = 2019,
                    GenreId = "Drama",
                    Director = new Director { DirectorName = "Director 3" },
                    Actors = new List<Actor>
                    {
                        new Actor { ActorName = "Actor 5" },
                        new Actor { ActorName = "Actor 6" }
                    },
                    Price = 12.99m
                });

                context.SaveChanges();
            }
        }
    }
}
