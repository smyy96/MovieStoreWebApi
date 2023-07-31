using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
                new Movie
            {

                MovieName = "Film 1",
                MovieYear = 2021,
                GenreId = 1,
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

                    MovieName = "Film 2",
                    MovieYear = 2020,
                    GenreId = 2,
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

                    MovieName = "Film 3",
                    MovieYear = 2019,
                    GenreId = 2,
                    Director = new Director { DirectorName = "Director 3" },
                    Actors = new List<Actor>
                    {
                        new Actor { ActorName = "Actor 5" },
                        new Actor { ActorName = "Actor 6" }
                    },
                    Price = 12.99m
                });

        }
    }
}
