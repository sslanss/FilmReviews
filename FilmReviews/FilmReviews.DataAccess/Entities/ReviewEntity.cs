using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    public class ReviewEntity:BaseEntity
    {
        public enum ReviewStatus { Published, Unpublished };
        public required UserEntity User { get; set; }
        public required FilmEntity Film { get; set; }
        public required string Title {  get; set; }
        public required string Content { get; set; }
        public required ReviewStatus Status { get; set; } = ReviewStatus.Unpublished;
        public virtual ICollection<UserRateOnReviewEntity>? UserRates{ get; set; }


    }
}
