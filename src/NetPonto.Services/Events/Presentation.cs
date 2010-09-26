using System;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Presentation : IEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Presenter { get; set; }
        public Uri LinkToSlides { get; set; }
        public Uri LinkToVideo { get; set; }
    }
}