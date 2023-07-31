using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Application.MovieOperations.Queries.GetMovie
{
    public class GetMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMovieQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movieList = _dbContext.Movies.Include(x=>x.Genre).OrderBy(x => x.MovieId).ToList();
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
