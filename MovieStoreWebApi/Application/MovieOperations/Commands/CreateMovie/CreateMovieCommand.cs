using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {

        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);
            if (movie is not null)
                throw new InvalidOperationException("The movie is already available.");

            movie = _mapper.Map<Movie>(Model); // Modeldeki değerleri Movie entitysine mapliyoruz.

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }


    public class CreateMovieModel
    {

        public string? MovieName { get; set; }
        public int MovieYear { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
    }
}
