using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entity
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        public string? GenreName { get; set; }
    }
}


/* ACTION=1,
        ADVENTURE,
        ANIMATION,
        COMEDY,
        CRIME,
        DOCUMENTARY,
        DRAMA,
        FANTASY,
        HORROR,
        MYSTERY,
        ROMANCE,
        SCIENCE_FICTION,
        THRILLER,
        WESTERN,
        HISTORICAL,
        MUSICAL,
        WAR,
        SUSPENSE */