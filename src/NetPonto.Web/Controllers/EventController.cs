using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using NetPonto.Infrastructure;
using NetPonto.Services;
using NetPonto.Services.Events;

namespace NetPonto.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IRepository<Event> _repository;

        public EventController(IRepository<Event> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Event/
        public ActionResult Index()
        {
            var events = _repository.LoadAll();
            return View(new Models.Event.Index {Events = events, Count = events.Count()});
        }

        //
        // GET: /Event/Details/5
        public ActionResult Details(int id)
        {
            var @event = _repository.Get(id);
            return View(Mapper.Map<Event, Models.Event.Details>(@event));
        }

        //
        // GET: /Event/Create
        [Authorize(Roles = SiteRoles.Administrator)]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Event/Create
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult Create(Models.Event.Create newEvent)
        {
            var evt = Mapper.Map<Models.Event.Create, Event>(newEvent);
            evt.SetStandardSchedule();

            _repository.SaveOrUpdate(evt);

            return RedirectToAction("Edit", new {id = evt.Id});
        }
        
        //
        // GET: /Event/Edit/5
        [Authorize(Roles = SiteRoles.Administrator)]
        public ActionResult Edit(int id)
        {
            var @event = _repository.Get(id);

            return View(Mapper.Map<Event, Models.Event.Edit>(@event));
        }

        //
        // POST: /Event/Edit/5
        [ValidateInput(false)]
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Event.Edit incomingEvent)
        {
            var evt = _repository.Get(incomingEvent.Id);

            Mapper.Map(incomingEvent, evt);
            var schedules = evt.Schedule.ToDictionary(s => s.Id);

            foreach (var incomingPart in incomingEvent.Schedule)
            {
                Mapper.Map(incomingPart, schedules[incomingPart.Id.Value]);
            }

            _repository.SaveOrUpdate(evt);

            return RedirectToAction("Edit", new {id = incomingEvent.Id});
        }
        
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult AddSchedule(int id, Models.Event.Edit.SchedulePart part)
        {
            var evt = _repository.Get(id);

            var newPart = Mapper.Map<Models.Event.Edit.SchedulePart, SchedulePart>(part);
            newPart.Id = 0;

            evt.Schedule.Add(newPart);

            _repository.SaveOrUpdate(evt);
            
            return RedirectToAction("Edit", new {id = evt.Id});
        }

        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult AddPresentation(int id, int schedulePartId)
        {
            var evt = _repository.Get(id);

            var schedulePart = evt.Schedule.SingleOrDefault(e => e.Id == schedulePartId);

            if (schedulePart == null)
                throw new InvalidOperationException(string.Format("No schedulePart found with id {0}", schedulePartId));

            if (schedulePart.Presentation == null)
            {
                schedulePart.Presentation = new Presentation();
            }
            _repository.SaveOrUpdate(evt);

            return RedirectToAction("Edit", new {id = evt.Id});
        }
        
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult RemovePresentation(int id, int schedulePartId)
        {
            var evt = _repository.Get(id);

            var schedulePart = evt.Schedule.SingleOrDefault(e => e.Id == schedulePartId);

            if (schedulePart == null)
                throw new InvalidOperationException(string.Format("No schedulePart found with id {0}", schedulePartId));

            schedulePart.Presentation = null;
            
            _repository.SaveOrUpdate(evt);

            return RedirectToAction("Edit", new {id = evt.Id});
        }

        //
        // GET: /Event/Delete/5
        [Authorize(Roles = SiteRoles.Administrator)] 
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();

            return View();
        }

        //
        // POST: /Event/Delete/5
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            throw new NotImplementedException();

            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}