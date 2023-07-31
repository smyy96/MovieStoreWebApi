using FluentValidation;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(movie => movie.Movie_Id)
                .GreaterThan(0).WithMessage("Invalid movie ID.");
        }
    }
}
