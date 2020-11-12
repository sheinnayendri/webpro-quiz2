using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using webpro_quiz2.Models;

namespace webpro_quiz2.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEvent(@event ev)
        {
            using (EventsCoEntities db = new EventsCoEntities())
            {
                ev.event_organizer = Convert.ToInt32(Session["user_id"]) + 1;
                db.events.Add(ev);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "User", new { area = "" });
            }
                
        }
        
        public ActionResult EditEvent(int id)
        {
            using (EventsCoEntities db = new EventsCoEntities())
            {
                var data = db.events.Where(x => x.event_id == id).SingleOrDefault();
                return View();
            }
                
        }

        [HttpPost]
        public ActionResult EditEvent(int id, @event ev)
        {
            using (EventsCoEntities db = new EventsCoEntities())
            {
                var e = (from a in db.events where a.event_id == id select a).FirstOrDefault();
                e.event_name = ev.event_name;
                e.event_place = ev.event_place;
                e.event_price = ev.event_price;
                e.event_start_date = ev.event_start_date;
                e.event_start_time = ev.event_start_time;
                e.event_end_date = ev.event_end_date;
                e.event_end_time = ev.event_end_time;
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard", "User", new { area = "" });
        }

        public ActionResult DeleteEvent(int id)
        {
            using (EventsCoEntities db = new EventsCoEntities())
            {
                var data = db.events.FirstOrDefault(x => x.event_id == id);
                    db.events.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Dashboard", "User", new { area = "" });
            }
        }


    }

}