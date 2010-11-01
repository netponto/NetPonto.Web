using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(new Models.Event.Details{Name= @event.Name, Description = @event.Description, Date = @event.Date});
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

            var eventModel = Mapper.Map<Event, Models.Event.Edit>(@event);

            return View(eventModel);
        }

        //
        // POST: /Event/Edit/5
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
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