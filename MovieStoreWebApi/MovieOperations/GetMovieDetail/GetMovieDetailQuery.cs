using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.MovieOperations.GetMovie;

namespace MovieStoreWebApi.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieStoreDbContext _dbContext;

        public int MovieId { get; set; }

        public GetMovieDetailQuery(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(x => x.MovieId == MovieId).FirstOrDefault();
            if (movie is null)
                throw new InvalidOperationException("The movie is already available.");

            MovieDetailViewModel result = new MovieDetailViewModel();
            result.MovieName = movie.MovieName;
            result.Genre = ((GenreEnum)movie.GenreId).ToString();
            result.MovieYear = movie.MovieYear;
            result.Price = movie.Price;
                        
            return result;
        }
    }

    public class MovieDetailViewModel
    {

        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
