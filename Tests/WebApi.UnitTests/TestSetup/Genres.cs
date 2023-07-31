using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
                        new Genre { GenreName = "ACTION" },
                        new Genre { GenreName = "ADVENTURE" }
                        );
        }
    }
}
