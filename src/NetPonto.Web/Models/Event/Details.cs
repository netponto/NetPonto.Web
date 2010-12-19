using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetPonto.Web.Models.Event
{
    public class Details 
    {
        public class Presentation
        {
            public string Description { get; set; }
            public string Presenter { get; set; }
            public string SlideshareEmbedCode { get; set; }
            public string EmbeddedPresentation { get; set; }
            public string EmbeddedVideo { get; set; }
            public Uri LinkToVideo { get; set; }
        }

        public class SchedulePart
        {
            [DisplayFormat(DataFormatString = "{0:00}")]
            public int? Hours { get; set; }
            [DisplayFormat(DataFormatString = "{0:00}")]
            public int? Minutes { get; set; }
            public string Name { get; set; }
            public Presentation Presentation { get; set; }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public List<SchedulePart> Schedule { get; set; }
    }
}