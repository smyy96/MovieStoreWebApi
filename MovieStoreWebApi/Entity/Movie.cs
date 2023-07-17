using System.IO;

namespace MovieStoreWebApi.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public string GenreId { get; set; }
        public Director Director { get; set; }
        public List<Actor> Actors { get; set; }    
        public decimal Price { get; set; }
    }
}
