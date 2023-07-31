using FluentValidation;

namespace MovieStoreWebApi.Application.GenreOperations.Queries
{
    public class GetGenresDetailQueryValidator : AbstractValidator<GetGenresDetailQuery>
    {
        public GetGenresDetailQueryValidator()
        {
            RuleFor(genre => genre.GenreId)
                .GreaterThan(0).WithMessage("Invalid genre ID.");
        }
    }
}
