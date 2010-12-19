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

        [StringLength(128)]
        public virtual string SlideshareEmbedCode { get; set; }

        public virtual Uri LinkToVideo { get; set; }
    }
}