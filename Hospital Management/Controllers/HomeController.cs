using Hospital_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hospital_Management.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Patient_Registration()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Patient_Registration(Patient patient)
        {
            
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                Random rd = new Random();
                patient.Patient_ID = "PAT" + rd.Next(1001, 9999).ToString();
                db.Patients.Add(patient);
                db.SaveChanges();
                ViewBag.Message = "Patient Registration Successful" + "\nYour user ID is:" + patient.Patient_ID; ;
            }
            return View(patient);
        }
        public ActionResult Doctor_Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Doctor_Registration(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                Random rd = new Random();
                doctor.Doctor_ID = "DOC" + rd.Next(1001, 9999).ToString();
                db.Doctors.Add(doctor);
                db.SaveChanges();
                ViewBag.Message1 = "Doctor Registration Successful"+"\nYour user ID is:"+doctor.Doctor_ID;
            }
            return View(doctor);
        }
        /*public ActionResult Hadmin_Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Hadmin_Registration(HospitalAdmin hospitalAdmin)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                db.HospitalAdmins.Add(hospitalAdmin);
                db.SaveChanges();
                ViewBag.Message = "Hospital admin Registration Successful";
            }
            return View(hospitalAdmin);
        }*/
        public ActionResult HospitalHome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HospitalHome(string UserRole)
        {
            if (UserRole == "Patient")
            {
                return RedirectToAction("PatientLogin");
            }
            else if (UserRole == "Doctor")
            {
                return RedirectToAction("DoctorLogin");
            }
            else if (UserRole == "Hospital Admin")
            {
                return RedirectToAction("Hadmin_Login");
            }
            else
            {
                ViewBag.Message = "** Please Choose Your Role **";
            }
            return View();
        }
        public ActionResult PatientLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PatientLogin(Patient patient)

        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            
            {
                var searchpatient = db.Patients.Where(x => x.Username == patient.Username &&
                  x.Password == patient.Password).FirstOrDefault();
                if (searchpatient != null) //ie login successful
                {
                   
                    return RedirectToAction("patient_after_login","Hospital");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(patient);
        }
        public ActionResult DoctorLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoctorLogin(Doctor doctor)

        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
           
            {
                var searchAdmin = db.Doctors.Where(x => x.Username == doctor.Username &&
                  x.Password == doctor.Password).FirstOrDefault();
                if (searchAdmin != null) //ie login successful
                {
                    
                    return RedirectToAction("doctor_after_login","Doctor");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(doctor);
        }
        public ActionResult Hadmin_Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Hadmin_Login(HospitalAdmin hospitalAdmin)

        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            
            {
                var searchAdmin = db.HospitalAdmins.Where(x => x.Username == hospitalAdmin.Username &&
                  x.Password == hospitalAdmin.Password).FirstOrDefault();
                if (searchAdmin != null) //ie login successful
                {
                    Session["hID"] = searchAdmin.Hospital_ID;
                    Session["hname"] = searchAdmin.Hospital_name;
                    Session["HAdmin"] = searchAdmin;
                    return RedirectToAction("Hadmin_after_login","Hospital");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(hospitalAdmin);
        }
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Admin admin)

        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();

            {
                var searchAdmin = db.Admins.Where(x => x.Username == admin.Username &&
                  x.Password == admin.Password).FirstOrDefault();
                if (searchAdmin != null) //ie login successful
                {

                    return RedirectToAction("Admin_login");
                }
                else
                {
                    ViewBag.ErrorMessage = "** Login Failed..Please check your input **";
                }
            }
            return View(admin);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }






    }
    
}