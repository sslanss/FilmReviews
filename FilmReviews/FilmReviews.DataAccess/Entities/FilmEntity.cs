using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    [Table("films")]
    public class FilmEntity:BaseEntity
    {
        public required string Name {  get; set; }
        public required FilmDirectorEntity Director { get; set; }

        public virtual ICollection<ReviewEntity>? Reviews { get; set; }
    }
}
