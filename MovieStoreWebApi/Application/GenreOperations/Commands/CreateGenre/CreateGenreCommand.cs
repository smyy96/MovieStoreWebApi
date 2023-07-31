using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public CreateGenreCommand( IMovieStoreDbContext dbContext)
        {            
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.GenreName == Model.GenreName);
            if (genre is not null)
                throw new InvalidOperationException("The movie is already available.");
            genre = new Entity.Genre();
            genre.GenreName = Model.GenreName;
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string GenreName { get; set; }
    }
}
