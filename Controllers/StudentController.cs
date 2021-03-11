using Alkemy_School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Alkemy_School.Controllers
{
    public class StudentController : Controller
    {
        SchoolEntities1 db = new SchoolEntities1();


        public ActionResult Index()
        {

            if (Session["Username"] == null)
            {
                string message;
                message = "No Has Iniciado Session";
                return RedirectToAction("Index", "Home", new { message });
            }

            try
            {
                var person = (Person)Session["Person"];
                ViewBag.Title = "Bienvenido " + person.Names;

                return View();
            }

            catch (Exception)
            {
                return RedirectToAction("Index", "Home");

            }

        }

        public ActionResult NewInscription()
        {
            return View(db.VM_Course.ToList());
        }

      
        public ActionResult Confirm_Insc()
        {
            int IDC = Convert.ToInt32(Request.QueryString["IDC"]);
            int IDT = Convert.ToInt32(Request.QueryString["IDT"]);
            var item = db.VM_Course.ToList();
            var Materia = item.Find(e => e.ID_Course == IDC && e.ID_Timetable == IDT);
            string message = "asda";

            return RedirectToAction("Index", "Student", new { message });
        }

        public bool Incription(VM_Course item)
        {


            return false;

        }

        public ActionResult AllCourses()
        {
            return View();
        }

        public ActionResult MyInscriptions()
        {
            List<VM_Course> list = MyCourses();
            return View(list);
        }

        public List<VM_Course> MyCourses()
        {
            int id;
            id = ((Username)Session["Username"]).DNI;
            List<Inscription_by_Student> inscr = db.Inscription_by_Student.ToList().FindAll(e => e.DNI_Person == id);
            List<VM_Course> list = new List<VM_Course>();
            foreach (var item in inscr)
            {
                list.Add(db.VM_Course.ToList().Find(e => e.ID_Course == item.ID_Course && e.ID_Timetable == item.ID_Timetable));
            }

            return list;
        }
        public ActionResult DeleteInscription()
        {
            return View();
        }
    }
}
