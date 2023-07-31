using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.DBOperations
{
    public interface IMovieStoreDbContext
    {
         DbSet<Movie> Movies { get; set; }
         DbSet<Genre> Genres { get; set; }
         DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
