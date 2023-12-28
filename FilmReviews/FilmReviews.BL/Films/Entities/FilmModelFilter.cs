using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Films.Entities
{
    public class FilmModelFilter
    {
        public string? Name { get; set; }
        public string? DirectorName { get; set; }
    }
}
