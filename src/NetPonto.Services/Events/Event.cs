using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Event : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [Required]
        public virtual DateTimeOffset Date { get; set; }

        [StringLength(2048)]
        public virtual string Description { get; set; }
        public virtual Uri LinkToFotos { get; set; }
        public virtual IList<Presentation> Presentations { get; set; }
    }
}