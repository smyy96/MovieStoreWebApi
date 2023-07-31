using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.MovieOperations.Commands
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var movie = new Movie() { MovieName = "Film 20", Actors = new List<Actor>() { new Actor { ActorName = "Actor 3" } }, DirectorId = 1, GenreId = 2, MovieYear = 2020, Price = 100 };
            _context.Movies.Add(movie);
            _context.SaveChanges();


            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            command.Model = new CreateMovieModel() { MovieName = movie.MovieName };


            //act & assert

            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("The movie is already available.");

        }


        [Fact]
        public void WhenValidInputAreGiven_Movie_ShouldBeCreated()
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            CreateMovieModel model = new CreateMovieModel() { MovieName = "Film Title", GenreId = 2, MovieYear = 2020, Price = 100 };
            command.Model=model;

            //act

            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var movie = _context.Movies.SingleOrDefault(movie => movie.MovieName == model.MovieName);
            movie.Should().NotBeNull();
            movie.GenreId.Should().Be(model.GenreId);
            movie.MovieYear.Should().Be(model.MovieYear);
            movie.Price.Should().Be(model.Price);


        }
    }
}
