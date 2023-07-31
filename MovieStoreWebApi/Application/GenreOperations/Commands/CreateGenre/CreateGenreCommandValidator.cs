using FluentValidation;
using MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator: AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator() 
        { 
            RuleFor(x=>x.Model.GenreName).NotEmpty().MinimumLength(4).WithMessage("Genre cannot be empty and must be a minimum of 4 characters.");
        }
    }
}
