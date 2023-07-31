using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateMovieModel Model = new UpdateMovieModel();
        public int Movie_Id { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.MovieId == Movie_Id);
            if (movie is null)
                throw new InvalidOperationException("The movie is already available.");


            movie.MovieName = Model.MovieName != default ? Model.MovieName : movie.MovieName;
            movie.MovieYear = Model.MovieYear != default ? Model.MovieYear : movie.MovieYear;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {

        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public int GenreId { get; set; }
        public decimal Price { get; set; }
    }
}
