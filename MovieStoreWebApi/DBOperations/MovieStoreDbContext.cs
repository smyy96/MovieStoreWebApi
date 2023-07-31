using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entity;

namespace MovieStoreWebApi.DBOperations
{
    public class MovieStoreDbContext :DbContext, IMovieStoreDbContext //Entity Framework Core tarafından sağlanan DbContext sınıfından türetilmiştir.
    {
        /*
         * (DbContextOptions<MovieStoreDbContext>sınıfı MovieStoreDbContext türündeki bir veritabanı bağlamının yapılandırma seçeneklerini temsil eder.
         * MovieStoreDbContext için geçerli olan yapılandırma seçeneklerini içerir ve bu seçenekler veritabanı bağlantısının nasıl yapılacağını belirler.
         * Yapılandırma, bir sistem, uygulama veya bileşenin çalışma şeklini ve davranışını belirlemek için yapılan ayarlamalar ve seçeneklerdir. 
         *  
         */


        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; } //Veritabanındaki filmlerin koleksiyonunu temsil ediyor
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
