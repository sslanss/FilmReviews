using FilmReviews.BL.Reviews.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Films
{
    public class UpdateFilmRequest
    {
        public string Name { get; set; }

        public List<ReviewModel>? Reviews { get; set; }
    }
}
