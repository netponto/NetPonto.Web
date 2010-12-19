using System;
using System.ComponentModel.DataAnnotations;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Presentation : IEntity
    {
        public virtual int Id { get; set; }

        [StringLength(2048)]
        public virtual string Description { get; set; }

        [StringLength(255)]
        public virtual string Presenter { get; set; }
        public virtual Uri LinkToSlides { get; set; }
        public virtual Uri LinkToVideo { get; set; }
    }
}