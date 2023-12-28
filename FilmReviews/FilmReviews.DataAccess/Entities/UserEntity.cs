using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity: IdentityUser<int>, IBaseEntity
    {
        public Guid ExternalId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public virtual ICollection<ReviewEntity>? Reviews { get; set; }
        public required bool IsAdmin { get; set; }
        public virtual ICollection<UserRateOnReviewEntity>? UserRates { get; set; }
    }

    public class UserRoleEntity : IdentityRole<int> { }
}
