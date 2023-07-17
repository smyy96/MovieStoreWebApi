using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : Controller
    {
        private readonly MovieStoreDbContext _context;

        public MovieController(MovieStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public List<Movie> Get()
        {
            var movieList = _context.Movies.OrderBy(x => x.MovieId).ToList<Movie>();
            return movieList;
        }


        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var movie = _context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            if (movie is null)
                return NotFound();
            return Ok(movie);
            
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie newMovie)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieName == newMovie.MovieName);
            if (movie is not null)
                return BadRequest();

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updateMovie)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieId == id);
            if (movie is null)
                return NotFound();

            movie.MovieName = updateMovie.MovieName != default ? updateMovie.MovieName : movie.MovieName;
            movie.MovieYear = updateMovie.MovieYear != default ? updateMovie.MovieYear : movie.MovieYear;
            movie.GenreId = updateMovie.GenreId != default ? updateMovie.GenreId : movie.GenreId;
            movie.Director = updateMovie.Director != default ? updateMovie.Director : movie.Director;
            movie.Actors = updateMovie.Actors != default ? updateMovie.Actors : movie.Actors;
            movie.Price = updateMovie.Price != default ? updateMovie.Price : movie.Price;

            _context.SaveChanges();

            return Ok(movie);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Where(x => x.MovieId == id).SingleOrDefault();
            if (movie is null)            
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
