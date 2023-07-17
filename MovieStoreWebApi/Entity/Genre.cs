using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entity
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
