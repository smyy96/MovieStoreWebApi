using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.MovieOperations.GetMovie;

namespace MovieStoreWebApi.MovieOperations.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public int MovieId { get; set; }

        public GetMovieDetailQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(x => x.MovieId == MovieId).FirstOrDefault();
            if (movie is null)
                throw new InvalidOperationException("The movie is already available.");

            MovieDetailViewModel result = _mapper.Map<MovieDetailViewModel>(movie);           
                        
            return result;
        }
    }

    public class MovieDetailViewModel
    {

        public string? MovieName { get; set; }
        public int MovieYear { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
