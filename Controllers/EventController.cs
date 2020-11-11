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
    }

}