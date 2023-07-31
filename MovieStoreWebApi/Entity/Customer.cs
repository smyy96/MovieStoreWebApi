using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entity
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public List<Movie> MoviesBought { get; set; }
        public List<Genre> FavoriteGenre { get; set; }
    }
}
