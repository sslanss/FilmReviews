using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    [Table("film_directors")]
    public class FilmDirectorEntity:BaseEntity
    {
        public required string Name {  get; set; }
        public virtual ICollection<FilmEntity>? Films{ get; set; }
    }
}
