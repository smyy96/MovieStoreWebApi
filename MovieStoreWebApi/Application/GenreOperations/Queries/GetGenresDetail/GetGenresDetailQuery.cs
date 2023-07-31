using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Common;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Application.GenreOperations.Queries
{
    public class GetGenresDetailQuery
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreViewModel Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreId==this.GenreId);
            if (genre is null)
                throw new InvalidOperationException("Genre Not Found!");
            return _mapper.Map<GenreViewModel>(genre);
        }
    }



    public class GenreDetailViewModel
    {        
        public string? GenreName { get; set; }
    }
}
