using FluentAssertions;
using MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Film 1",0,0,0)]
        [InlineData("Film 1",2,0,0)]
        [InlineData("Film 1",0,2020,0)]
        [InlineData("Film 1",0,0,100)]
        [InlineData("aa",1,2020,100)]
        [InlineData("Film 1",5,2080,10)]
        [InlineData("",0,0,0)]
        [InlineData("",3,0,800)]
        [InlineData(" ",2,2020,800)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeErrors(string movieName, int genreıd, int Year, int price)
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel()
            {
                MovieName = movieName,
                GenreId = genreıd,
                MovieYear = Year,
                Price = price
            };

            //act
            CreateMovieCommandValidator validations = new CreateMovieCommandValidator();
            var result = validations.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);


        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeErrors()
        {
            //arrange
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel()
            {
                MovieName = "Film",
                GenreId = 1,
                MovieYear = 1996,
                Price = 100
            };

            //act
            CreateMovieCommandValidator validations = new CreateMovieCommandValidator();
            var result = validations.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);


        }
    }
}
