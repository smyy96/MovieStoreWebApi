using FluentValidation;

namespace MovieStoreWebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(movie => movie.MovieId)
                .GreaterThan(0).WithMessage("Invalid movie ID.");
        }
    }
}
