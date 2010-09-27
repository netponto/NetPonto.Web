using System;
using System.Collections.Generic;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Event : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTimeOffset Date { get; set; }
        public virtual string Description { get; set; }
        public virtual Uri LinkToFotos { get; set; }
        public virtual IList<Presentation> Presentations { get; set; }
    }
}