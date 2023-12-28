using System.ComponentModel.DataAnnotations;

namespace FilmReviews.WebAPI.Controllers.Entities.FilmDirectors
{
    public class CreateFilmDirectorRequest 
    {
        public required string Name { get; set; }
    }
}
