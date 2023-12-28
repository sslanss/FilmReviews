using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Films.Entities
{
    public class CreateFilmModel
    {
        public required string Name { get; set; }
        public required FilmDirectorModel Director { get; set; }
    }
}
