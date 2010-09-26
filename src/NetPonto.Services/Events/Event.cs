using System;
using System.Collections.Generic;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public Uri LinkToFotos { get; set; }
        public IList<Presentation> Presentations { get; set; }
    }
}