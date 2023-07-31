using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Application.GenreOperations
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genreList = _dbContext.Genres.OrderBy(x => x.GenreId).ToList();
            List<GenreViewModel> result = _mapper.Map<List<GenreViewModel>>(genreList);
            return result;
        }
    }



    public class GenreViewModel
    {        
        public string? GenreName { get; set; }
    }
}
