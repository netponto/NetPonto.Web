using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            try
            {
                var @event = new Event();
                @event.Name = newEvent.Name;
                @event.Description = newEvent.Description;
                @event.Date = newEvent.Date;
                _repository.SaveOrUpdate(@event);

                return RedirectToAction("Details", new {id = @event.Id});
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Event/Edit/5
        [Authorize(Roles = SiteRoles.Administrator)]
        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
            return View();
        }

        //
        // POST: /Event/Edit/5
        [Authorize(Roles = SiteRoles.Administrator)]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            throw new NotImplementedException();
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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