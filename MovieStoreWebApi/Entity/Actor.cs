﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entity
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }
        public string? ActorName { get; set; }
        public string? ActorSurname { get; set; }
        public List<Movie> StarringMovie { get; set; }
    }
}
