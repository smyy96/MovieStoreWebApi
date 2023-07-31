using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator() 
        {
            RuleFor(x => x.model.GenreName).MinimumLength(4).When(x => x.model.GenreName.Trim() != string.Empty)
                .WithMessage("Genre name must be at least 3 characters long.");
        }
    }
}
