using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IMovieStoreDbContext _dbcontext;
        public UpdateGenreModel model { get; set; }
        public int GenreId { get; set; }

        public UpdateGenreCommand(IMovieStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        { 
            var genre = _dbcontext.Genres.SingleOrDefault(x=>x.GenreId == this.GenreId);
            if (genre == null)
                throw new InvalidOperationException("Genre Not Found!");
            if (_dbcontext.Genres.Any(x => x.GenreName.ToLower() == model.GenreName.ToLower() && x.GenreId != this.GenreId)) 
                throw new InvalidOperationException("Genre already exists");

            genre.GenreName = model.GenreName.Trim();
            _dbcontext.Genres.Update(genre);
            _dbcontext.SaveChanges();

        }
    }

    public class UpdateGenreModel
    {
        public string? GenreName { get; set; }
    }
       
}
