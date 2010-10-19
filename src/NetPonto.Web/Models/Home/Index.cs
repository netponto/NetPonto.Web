using System.Collections.Generic;

namespace NetPonto.Web.Models.Home
{
    public class Index
    {
        public class SchedulePart
        {
            public string Hours { get; set; }
            public string Minutes { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string UserDisplayName { get; set; }
            public string UserUrl { get; set; }
        }

        public Index()
        {
            Schedule = new List<SchedulePart>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<SchedulePart> Schedule { get; set; }
    }
}