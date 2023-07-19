using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;
using MovieStoreWebApi.MovieOperations.CreateMovie;
using MovieStoreWebApi.MovieOperations.DeleteMovie;
using MovieStoreWebApi.MovieOperations.GetMovie;
using MovieStoreWebApi.MovieOperations.GetMovieDetail;
using MovieStoreWebApi.MovieOperations.UpdateMovie;

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
        public IActionResult Get()
        {
            GetMovieQuery getMovieQuery = new GetMovieQuery(_context);
            var result = getMovieQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailViewModel result;
            try
            {
                GetMovieDetailQuery getMovieDetailQuery = new GetMovieDetailQuery(_context);
                getMovieDetailQuery.MovieId = id;
                result = getMovieDetailQuery.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
            
        }


        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context);
            try
            {
                command.Model = newMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updateMovie)
        {
            try
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_context);
                command.Movie_Id = id;
                command.Model = updateMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {

            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.Movie_Id = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
