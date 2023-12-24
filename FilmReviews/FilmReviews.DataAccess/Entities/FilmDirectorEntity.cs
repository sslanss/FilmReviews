using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    public class FilmDirectorEntity:BaseEntity
    {
        public required string Name {  get; set; }
        public virtual ICollection<FilmEntity>? Films{ get; set; }
    }
}
