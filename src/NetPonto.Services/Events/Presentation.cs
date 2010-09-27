using System;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Presentation : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int OrderInEvent { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Presenter { get; set; }
        public virtual Uri LinkToSlides { get; set; }
        public virtual Uri LinkToVideo { get; set; }
    }
}