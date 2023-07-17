using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class FilmController : Controller
    {
        public static List<Movie> MovieList = new List<Movie>
        {
            new Movie
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
                }

        };

        [HttpGet]
        public List<Movie> Get()
        {
            var movieList = MovieList.OrderBy(x => x.MovieId).ToList<Movie>();
            return movieList;
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var movie = MovieList.Where(x => x.MovieId == id).FirstOrDefault();
            if (movie is null)
                return NotFound();
            return Ok(movie);
            
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            var movie = MovieList.SingleOrDefault(x => x.MovieName == newMovie.MovieName);
            if (movie is not null)
                return BadRequest();

            MovieList.Add(newMovie);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updateMovie)
        {
            var movie = MovieList.Find(x => x.MovieId == id);
            if (movie is null)
                return NotFound();

            movie.MovieName = updateMovie.MovieName != default ? updateMovie.MovieName : movie.MovieName;
            movie.MovieYear = updateMovie.MovieYear != default ? updateMovie.MovieYear : movie.MovieYear;
            movie.GenreId = updateMovie.GenreId != default ? updateMovie.GenreId : movie.GenreId;
            movie.Director = updateMovie.Director != default ? updateMovie.Director : movie.Director;
            movie.Actors = updateMovie.Actors != default ? updateMovie.Actors : movie.Actors;
            movie.Price = updateMovie.Price != default ? updateMovie.Price : movie.Price;

            return Ok(movie);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = MovieList.Where(x => x.MovieId == id).SingleOrDefault();
            if (movie is null)            
                return NotFound();

            MovieList.Remove(movie);
            return Ok();
        }
    }
}
