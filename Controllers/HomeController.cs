using Alkemy_School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_School.Controllers
{
    public class HomeController : Controller
    {
        Alkemy_SchoolEntities db = new Alkemy_SchoolEntities();



        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyPage(int Docket, int DNI)
        {
            Session["Username"] = db.Username.ToList().Find(E => E.Docket == Docket);
            Session["Person"] = db.Person.ToList().Find(E => E.DNI == DNI);
            string page = "";
            switch (CheckAdmin(Docket,DNI))
            {
                case 1:
                    {
                        page = "Student";
                    }; break;

                case 2:
                    {
                        page = "Contact";
                    }; break;
                case 0:
                    {
                        page="Index";
                    }
                    break;
            }

            return RedirectToAction( page, "Home");
        }

        int CheckAdmin(int dock, int DNI)
        {
            var user = db.Username.ToList().Find(e => e.Docket == dock && e.DNI == DNI);
            if (user == null)
            {
                return 0;
            }

            else if (user.Access == 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Student()
        {
            var person = (Person)Session["Person"];

            ViewBag.Title = "Bienvenido " + person.Names;

            return View();
        }
    }
}