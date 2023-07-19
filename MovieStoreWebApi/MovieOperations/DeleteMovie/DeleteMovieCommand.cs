using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieStoreDbContext _dbContext;

        public int Movie_Id { get; set; }

        public DeleteMovieCommand(MovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.Where(x => x.MovieId == Movie_Id).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("The movie is already available.");

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}
