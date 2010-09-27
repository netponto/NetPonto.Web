
using System.Collections.Generic;

namespace NetPonto.Web.Models.Event
{
    public class Index
    {
        public IEnumerable<Services.Events.Event> Events { get; set; }
        public int Count { get; set; }
    }
}