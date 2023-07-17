using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.DBOperations
{
    public class MovieStoreDbContext : DbContext //EF paketi ile dbContext sınıfından kalıtım aldık.
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
