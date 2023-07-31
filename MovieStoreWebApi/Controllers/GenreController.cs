using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.GenreOperations;
using MovieStoreWebApi.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.Application.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.Application.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.Application.GenreOperations.Queries;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public readonly IMovieStoreDbContext _dbcontext;
        public readonly IMapper _mapper;

        public GenreController(IMovieStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres() 
        {
            GetGenresQuery query = new GetGenresQuery(_dbcontext,_mapper);
            var list=query.Handle();
            return Ok(list);

        }


        [HttpGet("id")]
        public ActionResult GetGenresDetail(int id) 
        {
            GetGenresDetailQuery query = new GetGenresDetailQuery(_dbcontext, _mapper);
            query.GenreId = id;
            GetGenresDetailQueryValidator validations = new GetGenresDetailQueryValidator();
            validations.ValidateAndThrow(query);
            var list = query.Handle();
            return Ok(list);
        }


        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel createGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_dbcontext);
            command.Model= createGenre;

            CreateGenreCommandValidator validationRules = new CreateGenreCommandValidator();
            validationRules.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }


        [HttpPut("id")]
        public IActionResult PutGenre(int id, [FromBody] UpdateGenreModel genreModel) 
        { 
            UpdateGenreCommand command = new UpdateGenreCommand(_dbcontext);
            command.GenreId= id;
            command.model = genreModel;

            UpdateGenreCommandValidator validations = new UpdateGenreCommandValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command= new DeleteGenreCommand(_dbcontext);
            command.GenreId=id;

            DeleteGenreCommandValidator validationRules = new DeleteGenreCommandValidator();
            validationRules.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
