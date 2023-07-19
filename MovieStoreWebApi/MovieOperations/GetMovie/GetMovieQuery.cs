using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.MovieOperations.GetMovie
{
    public class GetMovieQuery
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMovieQuery(MovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(x => x.MovieId).ToList<Movie>();
            List<MovieViewModel> result = _mapper.Map<List<MovieViewModel>>(movieList);
            return result;
        }
    }



    public class MovieViewModel
    {
        
        public string? MovieName { get; set; }
        public int MovieYear { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
