using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using NetPonto.Infrastructure.Validation;

namespace NetPonto.Web.Models.Event
{
    [UseAnnotationsFrom(typeof(Services.Events.Event))]
    public class Edit
    {
        [UseAnnotationsFrom(typeof(Services.Events.Presentation))]
        public class Presentation
        {
            [HiddenInput(DisplayValue = false)]
            public int Id { get; set; }
            [UIHint("WymEditor")]
            public string Description { get; set; }
            public string Presenter { get; set; }
            public string SlideshareEmbedCode { get; set; }
            public Uri LinkToVideo { get; set; }
        }

        [UseAnnotationsFrom(typeof (Services.Events.SchedulePart))]
        public class SchedulePart
        {
            [HiddenInput(DisplayValue = false)]
            public int? Id { get; set; }
            [Required]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:00}")]
            public int? Hours { get; set; }
            [Required]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:00}")]
            public int? Minutes { get; set; }
            public string Name { get; set; }
            public Presentation Presentation { get; set; }
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }

        [UIHint("WymEditor")]
        public string Description { get; set; }

        public DateTimeOffset Date { get; set; }
        public List<SchedulePart> Schedule { get; set; }
    }
}