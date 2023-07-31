using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entity
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        public string? DirectorName { get; set; }
        public string? direktorSurname { get; set; }
        public List<Movie> MoviesDirected { get; set; }
    }
}
