using AutoMapper;
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

        private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            GetMovieQuery getMovieQuery = new GetMovieQuery(_context, _mapper);
            var result = getMovieQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieDetailViewModel result;
            try
            {
                GetMovieDetailQuery getMovieDetailQuery = new GetMovieDetailQuery(_context, _mapper);
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
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            try
            {
                command.Model = newMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            
            return Ok("Success");
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
