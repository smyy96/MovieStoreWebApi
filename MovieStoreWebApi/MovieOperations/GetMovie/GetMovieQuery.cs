using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.MovieOperations.GetMovie
{
    public class GetMovieQuery
    {
        private readonly MovieStoreDbContext _dbContext;

        public GetMovieQuery(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(x => x.MovieId).ToList<Movie>();
            List<MovieViewModel> result = new List<MovieViewModel>();
            foreach (var movie in movieList)
            {
                result.Add(new MovieViewModel()
                {
                    MovieName = movie.MovieName,
                    Genre = ((GenreEnum)movie.GenreId).ToString(),
                    MovieYear = movie.MovieYear,
                    Price = movie.Price

                });
            }
            return result;
        }
    }



    public class MovieViewModel
    {
        
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
