using System;
using NetPonto.Infrastructure.Validation;

namespace NetPonto.Web.Models.Event
{
    [UseAnnotationsFrom(typeof(Services.Events.Event))]
    public class Create
    {
        public string Name { get; set; }
        public DateTimeOffset? Date { get; set; }   
    }
}