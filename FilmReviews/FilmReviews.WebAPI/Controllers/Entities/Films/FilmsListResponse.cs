using FilmReviews.BL.Films.Entities;
using FilmReviews.BL.Users.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Films
{
    public class FilmsListResponse
    {
        public List<FilmModel>? Films { get; set; }
    }
}
