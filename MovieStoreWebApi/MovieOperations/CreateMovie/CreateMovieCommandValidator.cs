using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MovieStoreWebApi.MovieOperations.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(movie => movie.Model.MovieName)
            .NotEmpty().WithMessage("Movie name cannot be empty.")
            .MinimumLength(3).WithMessage("Movie name must be at least 3 characters long.");

            RuleFor(movie => movie.Model.MovieYear)
                .InclusiveBetween(1, DateTime.Today.Year).WithMessage("Invalid movie year."); ;

            RuleFor(movie => movie.Model.GenreId)
                .GreaterThan(0).WithMessage("Invalid genre ID.");

            RuleFor(movie => movie.Model.Price)
                .GreaterThan(0).WithMessage("Invalid price.");
        }
    }
    
}
