﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.DataAccess.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; } //ключ в бд
        public Guid ExternalId { get; set; } // unique index - unique optional
        public DateTime ModificationTime { get; set; } // optional
        public DateTime CreationTime { get; set; } //optional
    }
}
