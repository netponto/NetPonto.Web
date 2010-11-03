using AutoMapper;
using NetPonto.Infrastructure.StartupTasks;
using NetPonto.Services.Events;

namespace NetPonto.Web.StartupTasks
{
    public class SetupAutomapper : IStartupTask
    {
        public void Execute()
        {
            Mapper.CreateMap<Event, Models.Event.Edit>();
            Mapper.CreateMap<SchedulePart, Models.Event.Edit.SchedulePart>();
            Mapper.CreateMap<Presentation, Models.Event.Edit.Presentation>();

            Mapper.CreateMap<Models.Event.Edit.SchedulePart, SchedulePart>()
                .ForMember(s => s.Presentation, c => c.UseDestinationValue());

            Mapper.CreateMap<Models.Event.Edit.Presentation, Presentation>();
            Mapper.CreateMap<Models.Event.Edit, Event>()
                .ForMember(e => e.Schedule, c => c.Ignore());

            Mapper.CreateMap<Models.Event.Create, Event>()
                .ForMember(e => e.Schedule, c => c.Ignore());

            Mapper.CreateMap<Event, Models.Event.Details>();
        }
    }
}