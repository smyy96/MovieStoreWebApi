using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator: AbstractValidator<DeleteGenreCommand>
    {

        public DeleteGenreCommandValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0).WithMessage("Invalid genre ID.");
        }
    }
}
