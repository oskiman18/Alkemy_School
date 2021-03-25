using Alkemy_School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy_School.Controllers
{
    public class AdminController : Controller
    {
        School_Entities db = new School_Entities();

        // GET: Admin
        public ActionResult Index()
        {
            string message;

            if (Session["Username"] == null)
            {
                message = "No Has Iniciado Session";
                return RedirectToAction("Index", "Home", new { message });
            }
            else if (((Username)Session["Username"]).Access == 0)
            {
                message = "No Tienes Acceso";
                return RedirectToAction("Index", "Home", new { message });
            }
            var person = (Person)Session["Person"];


            ViewBag.Title = "Bienvenido " + person.Names;

            return View();
        }

        public ActionResult Manage_Teachers()
        {
            return View();
        }
        public ActionResult Manage_Course()
        {
            return View();
        }
        public ActionResult Manage_Students()
        {
            return View();
        }
    }
}
