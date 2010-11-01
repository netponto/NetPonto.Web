using System;

namespace NetPonto.Web.Models.Event
{
    public class Details 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}