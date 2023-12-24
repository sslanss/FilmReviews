using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    public class UserRateOnReviewEntity:BaseEntity
    {
        public required UserEntity User { get; set; }
        public required ReviewEntity Review { get; set; }
        public required int Rate {  get; set; }
    }
}
