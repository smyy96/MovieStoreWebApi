using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {

        public CreateMovieModel Model { get; set; }
        private readonly MovieStoreDbContext _dbContext;

        public CreateMovieCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle() 
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName);
            if (movie is not null)
                throw new InvalidOperationException("The movie is already available.");

            movie = new Entity.Movie();
            movie.MovieName = Model.MovieName;
            movie.MovieYear = Model.MovieYear;
            movie.GenreId = Model.GenreId;
            movie.Price = Model.Price;


            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }


    public class CreateMovieModel
    {

        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
    }
}
