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
        School_Entities db = new School_Entities();
        

        [HttpGet]
        public ActionResult Index(string message)
        {

            ViewBag.Error = message;
            Session["Username"] = null;
            Session["Person"] = null;
            return View();
        }




        public ActionResult CheckLogin(string docket, string dni)
        {
            string message;
            if (docket == "" || dni == "")

            {
                message = "Falta ingresar Datos";
                return RedirectToAction("Index", "Home", new { message });
            }
            try
            {
                int Docket = int.Parse(docket);
                int DNI = int.Parse(dni);

                Session["Username"] = db.Username.ToList().Find(E => E.Docket == Docket);
                Session["Person"] = db.Person.ToList().Find(E => E.DNI == DNI);

                string page = "";
                switch (CheckAdmin(Docket, DNI))
                {
                    case 1:
                        {
                            page = "Student";
                        }; break;

                    case 2:
                        {
                            page = "Admin";
                        }; break;
                    case 0:
                        {

                            page = "Home";
                        }
                        break;
                }

                return RedirectToAction("Index", page);

            }
            catch (Exception)
            {
                message = "Los datos ingresados del tipo valido";
                return RedirectToAction("Index", "Home", new { message });
            }
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

        public ActionResult Details()
        {
            int IDC = Convert.ToInt32(Request.QueryString["IDC"]);
            var list = db.VM_Course.ToList();
            var item = list.Find(E => E.ID_Course == IDC);
          
            
            return View(item);
        }
    }
}