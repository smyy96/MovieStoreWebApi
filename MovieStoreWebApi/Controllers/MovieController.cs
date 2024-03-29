﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreWebApi.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreWebApi.Application.MovieOperations.Queries.GetMovie;
using MovieStoreWebApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : Controller
    {
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDbContext context, IMapper mapper)
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
                GetMovieDetailQueryValidator validations = new GetMovieDetailQueryValidator();
                validations.ValidateAndThrow(getMovieDetailQuery);
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
           
            command.Model = newMovie;
            CreateMovieCommandValidator validations = new CreateMovieCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();

            return Ok(newMovie);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updateMovie)
        {
            try
            {
                UpdateMovieCommand command = new UpdateMovieCommand(_context);
                command.Movie_Id = id;
                command.Model = updateMovie;

                UpdateMovieCommandValidator validations = new UpdateMovieCommandValidator();
                validations.ValidateAndThrow(command);

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

            //try
            //{
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.Movie_Id = id;
                DeleteMovieCommandValidator validations = new DeleteMovieCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}

            return Ok();
        }
    }
}
