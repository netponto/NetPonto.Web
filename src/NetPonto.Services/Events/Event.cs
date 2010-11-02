using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetPonto.Infrastructure;

namespace NetPonto.Services.Events
{
    public class Event : IEntity
    {
        public virtual int Id { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [Required]
        public virtual DateTimeOffset Date { get; set; }

        [StringLength(2048)]
        public virtual string Description { get; set; }
        public virtual Uri LinkToFotos { get; set; }
        public virtual IList<SchedulePart> Schedule { get; protected set; }

        public virtual void SetStandardSchedule()
        {
            Schedule = Schedule ?? new List<SchedulePart>();
            Schedule.Add(new SchedulePart(9, 30, "Recepção dos participantes"));
            Schedule.Add(new SchedulePart(10, 0, "---Apresentação 1",
                                          new Presentation() {Name = "Name", Description = "Description"}));
            Schedule.Add(new SchedulePart(11, 30, "Coffee-break"));
            Schedule.Add(new SchedulePart(12, 00, "---Apresentação 2",
                                          new Presentation() {Name = "Name", Description = "Description"}));
            Schedule.Add(new SchedulePart(13, 30, "Painel de Discussão"));
        }
    }
}