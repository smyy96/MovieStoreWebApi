using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _dbcontext;

        public DeleteGenreCommand(IMovieStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var genre = _dbcontext.Genres.SingleOrDefault(x => x.GenreId == this.GenreId);
            if (genre is null)
                throw new InvalidOperationException("Genre Not Found!");
            
            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();
        }
    }
}
