using System;
using System.ComponentModel.DataAnnotations;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class SchedulePart : IEntity
    {
        protected SchedulePart()
        {
        }

        public SchedulePart(int hours, int minutes, string name)
        {
            Hours = hours;
            Minutes = minutes;
            Name = name;
        }

        public SchedulePart(int hours, int minutes, string name, Presentation presentation)
            : this(hours, minutes, name)
        {
            Presentation = presentation;
        }

        public virtual int Id { get; set; }

        [Required]
        [Range(0,23)]
        public virtual int Hours { get; set; }

        [Required]
        [Range(0,59)]
        public virtual int Minutes { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }
               
        public virtual Presentation Presentation { get; set; }
    }
}