using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Films.Entities
{
    public class FilmModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required FilmDirectorModel Director { get; set; }

        public List<ReviewModel>? Reviews { get; set; }
    }
}
