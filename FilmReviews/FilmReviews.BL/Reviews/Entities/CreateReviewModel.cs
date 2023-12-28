using FilmReviews.BL.Films.Entities;
using FilmReviews.BL.Users.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Reviews.Entities
{
    public class CreateReviewModel
    {
        public required UserModel User { get; set; }
        public required FilmModel Film { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required ReviewEntity.ReviewStatus Status { get; set; } = ReviewEntity.ReviewStatus.Unpublished;
    }
}
