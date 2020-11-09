using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webpro_quiz2.Models;

namespace webpro_quiz2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user user)
        {
            if (ModelState.IsValid)
            {
                using (EventsCoEntities db = new EventsCoEntities())
                {
                    string pass = Crypto.Hash(user.password);
                    var rec = db.users.Where(a => a.email.Equals(user.email) && a.password.Equals(pass)).FirstOrDefault();
                    if (rec != null)
                    {
                        Session["user_id"] = rec.user_id.ToString();
                        Session["email"] = rec.email.ToString();
                        Session["fullname"] = rec.fullname.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(user);
        }

        public ActionResult Register()
        {
            if (Session["user_id"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user user)
        {
            if (ModelState.IsValid)
            {
                using (EventsCoEntities db = new EventsCoEntities())
                {
                    user.password = Crypto.Hash(user.password);
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["user_id"] = null;
            Session["email"] = null;
            Session["fullname"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}