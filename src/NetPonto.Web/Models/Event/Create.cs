using System;

namespace NetPonto.Web.Models.Event
{
    public class Create
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? Date { get; set; }   
    }
}