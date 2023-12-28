using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.BL.Reviews.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.FilmDirectors
{
    public class FilmDirectorsListResponse
    {
        public List<FilmDirectorModel>? FilmDirectors { get; set; }
    }
}
