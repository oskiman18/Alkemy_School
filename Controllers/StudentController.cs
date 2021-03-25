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
        School_Entities db = new School_Entities();

        [HttpGet]
        public ActionResult Index(string message)
        {

            if (Session["Username"] == null)
            {

                message = "No Has Iniciado Session";
                return RedirectToAction("Index", "Home", new { message });
            }

            try
            {
                var person = (Person)Session["Person"];
                ViewBag.Title = "Bienvenido " + person.Names;
                ViewBag.Action = message;

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
            string message;
            try
            {
                int IDC = Convert.ToInt32(Request.QueryString["IDC"]),
                 IDT = Convert.ToInt32(Request.QueryString["IDT"]);
                var item = db.VM_Course.ToList();
                var Materia = item.Find(e => e.ID_Course == IDC && e.ID_Timetable == IDT);
                if (Check_Availeable(IDT, IDC) == 1)
                {
                    Inscription(IDC, IDT);
                    message = "Inscripcion Confirmada";
                    return RedirectToAction("Index", "Student", new { message });
                }
                else
                {
                    message = "Error Tipo: " + Check_Availeable(IDT, IDC).ToString();
                    return RedirectToAction("Index", "Student", new { message });
                }
            }
            catch (Exception)
            {
                message = "Error en la base de datos";
                return RedirectToAction("Index", "Student", new { message });
            }

        }

        public void Inscription(int IDC, int IDT)
        {
            try
            {
                var inscription = new Inscription_by_Student();
                inscription.DNI_Person = ((Person)Session["Person"]).DNI;
                inscription.ID_Course = (short)IDC;
                inscription.ID_Timetable = (short)IDT;
                inscription.Date_Inscr = DateTime.Now;
                db.Inscription_by_Student.Add(inscription);
                db.SaveChanges();

            }
            catch (Exception)
            {
            }
        }

        private int Check_Availeable(int IDT, int IDC)
        {
            var person = (Person)Session["Person"];
            var list_hour = db.Timetable.ToList();
            var hour = list_hour.Find(e => e.ID == IDT);
            foreach (var item in db.Inscription_by_Student.ToList())
            {
                if (person.DNI == item.DNI_Person && item.ID_Timetable == IDT)
                {
                    return 2;
                }
                if (person.DNI == item.DNI_Person && item.ID_Course == IDC)
                {
                    return 3;
                }


            }


            return 1;
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
            int IDC = Convert.ToInt32(Request.QueryString["IDC"]),
                IDT = Convert.ToInt32(Request.QueryString["IDT"]),
                DNI = ((Person)Session["Person"]).DNI;
            ;
            var list = db.Inscription_by_Student.ToList();
            var insc = list.Find(E => E.ID_Course == IDC && E.ID_Timetable == IDT && E.DNI_Person == DNI);
            db.Inscription_by_Student.Remove(insc);
            db.SaveChanges();
            string message = "Inscripcion Eliminada";

            return RedirectToAction("Index", "Student", new { message });

        }

        public ActionResult Userinfo()
        {
           
            var item = db.VM_User.ToList().Find(E => E.Documento == ((Person)Session["Person"]).DNI); 
            return View(item);
        }

    }
}
