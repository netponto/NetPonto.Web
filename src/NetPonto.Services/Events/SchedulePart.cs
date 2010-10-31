using System.ComponentModel.DataAnnotations;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class SchedulePart : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual int Hours { get; set; }

        [Required]
        public virtual int Minutes { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }
               
        public virtual Presentation Presentation { get; set; }
    }
}