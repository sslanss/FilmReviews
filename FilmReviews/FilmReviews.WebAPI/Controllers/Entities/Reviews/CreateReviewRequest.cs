using FilmReviews.BL.Films.Entities;
using FilmReviews.BL.Users.Entities;
using FilmReviews.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace FilmReviews.WebAPI.Controllers.Entities.Reviews
{
    public class CreateReviewRequest 
    {
        public required UserModel User { get; set; }
        public required FilmModel Film { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required ReviewEntity.ReviewStatus Status { get; set; } = ReviewEntity.ReviewStatus.Unpublished;
    }
}
