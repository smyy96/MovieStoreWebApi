using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MovieStoreWebApi.Entity
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
        
        public List<Actor> Actors { get; set; }    
        public decimal Price { get; set; }
    }
}
