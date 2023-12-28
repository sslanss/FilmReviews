using FilmReviews.BL.FilmDirectors.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmReviews.WebAPI.Controllers.Entities.Films
{
    public class CreateFilmRequest 
    {
        public required string Name { get; set; }
        public required FilmDirectorModel Director { get; set; }
    }
}
