using Hospital_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doctor/Details/5
        public ActionResult Details()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Appoinment> appoinments = db.Appoinments.ToList();
            return View(appoinments);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult doctor_after_login()
        {
            return View();
        }
        // GET: Doctor/Edit/5
        public ActionResult Edit(string ID)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appoinment appoinments = db.Appoinments.Find(ID);
            if (appoinments == null)
            {
                return HttpNotFound();
            }
            return View(appoinments);

            

        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(Appoinment appoinments)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            db.Entry(appoinments).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
        public ActionResult View_test_result()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Patient> patients = db.Patients.ToList();
            return View(patients);
        }
        public ActionResult Patient_details(string id)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        public ActionResult add_test_results(string id)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            //facilityappoinment facilityappoinment = db.Facilityappoinments.Find(Username);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        [HttpPost]
        public ActionResult add_test_results(Patient patient)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            db.Entry(patient).State = EntityState.Modified;
            ViewBag.message = "Test result updated";
            db.SaveChanges();
            return View();
        }
        public ActionResult view_testresult_patient()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Patient> patients = db.Patients.ToList();
            return View(patients);
        }
        public ActionResult see_testresult_patient(string id)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }
        public ActionResult add_records()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_records(Patient_record patient_Record)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                Random rd = new Random();
                patient_Record.ID = "REC" + rd.Next(1001, 9999).ToString();
                db.Patient_Records.Add(patient_Record);
                ViewBag.popup = "Records inserted successfully";
                db.SaveChanges();
                ViewBag.Message = "Patient Registration Successful";
            }
            return View(patient_Record);
        }
    }
}
