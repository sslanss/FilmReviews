using FilmReviews.BL.Films.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.FilmDirectors.Entities
{
    public class UpdateFilmDirectorModel
    {
        public string Name { get; set; }
        public List<FilmModel>? Films { get; set; }
    }
}
