using Hospital_Management.Migrations;
using Hospital_Management.Models;
using Hospital_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Hospital_Management.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital

        public ActionResult Hospitaladmin_hospital()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Hospitaladmin_hospital(HospitalViewmodel hospitalViewmodel)
        {
            try
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();

                Hospital hospital = new Hospital();
                {
                    hospital.Hospital_ID = hospitalViewmodel.Hospital_ID;
                    hospital.Hospital_name = hospitalViewmodel.Hospital_name;
                    


                }
                HospitalAdmin hospitalAdmin = new HospitalAdmin();
                {
                    hospitalAdmin.Hospital_ID = hospitalViewmodel.Hospital_ID;
                    hospitalAdmin.Hospital_name = hospitalViewmodel.Hospital_name;
                    hospitalAdmin.Username = hospitalViewmodel.Username;
                    hospitalAdmin.Password = hospitalViewmodel.Password;
                    hospitalAdmin.Name = hospitalViewmodel.Name;
                    hospitalAdmin.Hospital_Addressline1 = hospitalViewmodel.Hospital_Addressline1;
                    hospitalAdmin.Hospital_Addressline2 = hospitalViewmodel.Hospital_Addressline2;
                    hospitalAdmin.city = hospitalViewmodel.city;
                    hospitalAdmin.state = hospitalViewmodel.state;
                    hospitalAdmin.postalcode = hospitalViewmodel.postalcode;
                    hospitalAdmin.Hospital_website = hospitalViewmodel.Hospital_website;
                    hospitalAdmin.Hospital_Faxnumber = hospitalViewmodel.Hospital_Faxnumber;
                    hospitalAdmin.Hospital_contactNumber = hospitalViewmodel.Hospital_contactNumber;
                    hospitalAdmin.MobileNumber = hospitalViewmodel.MobileNumber;
                    hospitalAdmin.Dateofbirth = hospitalViewmodel.Dateofbirth;
                    hospitalAdmin.EmailID = hospitalViewmodel.EmailID;
                    hospitalAdmin.Gender = hospitalViewmodel.Gender;
                }
                Random rd = new Random();
                hospitalAdmin.Hadmin_ID = "HADM" + rd.Next(1001, 9999).ToString();
                db.HospitalAdmins.Add(hospitalAdmin);
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                ViewBag.Message = "Hospital admin Registration Successful";
                return View(hospitalViewmodel);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }
        
        public ActionResult Hadmin_after_login()
        {
            // Retain the Hospital Admin ID. 
            var admin = (HospitalAdmin)Session["HAdmin"];
            ViewBag.adminID = admin.Hospital_ID;
            ViewBag.adminname = admin.Hospital_name;
            if (admin != null)
            {
                var viewModel = new HospitalViewmodel
                {
                    Hospital_ID = admin.Hospital_ID,
                    Hospital_name = admin.Hospital_name
                };
                return View(viewModel);
            }
            return View();
        }
        
        public ActionResult AddFacilities()
        {

            Hospitalmanagement_context db = new Hospitalmanagement_context();
            
            var getlist = db.Hospitals.ToList();
            ViewBag.hospitallist = new SelectList(getlist,"Hospital_ID", "Hospital_name");

            //ViewBag.HospitalInfo= db.Hospitals.Select(x=>x.Hospital_name).ToList();
            //var getlist = db.Hospitals.ToList();
            //SelectList hospitallist = new SelectList(getlist, "Hospital_ID", "Hospital_name");
            //ViewBag.listname = hospitallist;
            //IEnumerable<SelectListItem> listname = db.Hospitals.Select(x => new SelectListItem() { Text = x.Hospital_name, Value = x.Hospital_name });
            //ViewBag.hospitalinfo = listname;
            var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
            ViewBag.list = list;




            return View();
        }
        [HttpPost]
        public ActionResult AddFacilities(HospitalFaciltyMapping hospitalFaciltyMapping)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                Random rd = new Random();
                hospitalFaciltyMapping.Facility_ID = "FAC" + rd.Next(1001, 9999).ToString();
            
                 var getlist = db.Hospitals.ToList();
                 ViewBag.hospitallist = new SelectList(getlist, "Hospital_ID", "Hospital_name");
                db.HospitalFaciltyMappings.Add(hospitalFaciltyMapping);

                db.SaveChanges();
                ViewBag.Message = "Facilities added sucessfully";


            }
            var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
            ViewBag.list = list;
            return View(hospitalFaciltyMapping);
        }
        public ActionResult patient_after_login()
        {
            
            
            return View();
        }
        public ActionResult hospitals_available()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Hospital> hospitals = db.Hospitals.ToList();
            return View(hospitals);


           
        }
        public ActionResult seefacilities()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<HospitalFaciltyMapping> hospitalFaciltyMappings = db.HospitalFaciltyMappings.ToList();
            return View(hospitalFaciltyMappings);

        }
        public ActionResult hospitaldetails()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Hospital> hospitals = db.Hospitals.ToList();
            return View(hospitals);

        }
        public ActionResult doctordetails()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Doctor> doctors = db.Doctors.ToList();
            return View(doctors);
        }
        public ActionResult seedoctors(string id)

        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Doctor> doctors = db.Doctors.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
          
            return View(doctor);
        }
        public ActionResult appoinmentbooking()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            var getlist = db.Doctors.ToList();
            ViewBag.doctorlist = new SelectList(getlist, "Doctor_ID", "Name");
            var getlist1 = db.Hospitals.ToList();
            ViewBag.hospitallist = new SelectList(getlist1, "Hospital_ID", "Hospital_name");
            var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult appoinmentbooking(Appoinment appoinments)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();

                var getlist = db.Doctors.ToList();
                ViewBag.doctorlist = new SelectList(getlist, "Doctor_ID", "Name");
                var getlist1 = db.Hospitals.ToList();
                ViewBag.hospitallist = new SelectList(getlist1, "Hospital_ID", "Hospital_name");
                var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
                ViewBag.list = list;
                Random rd = new Random();
                appoinments.ID = "AP" + rd.Next(1001, 9999).ToString();
                appoinments.status = "Pending";
                db.Appoinments.Add(appoinments);
                db.SaveChanges();
                ViewBag.Message = "Appoinment Booked Successfully";
            }
            return View(appoinments);
        }
        public ActionResult facilitybooking()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            //var getlist = db.Doctors.ToList();
            //ViewBag.doctorlist = new SelectList(getlist, "Doctor_ID", "Name");
            var getlist1 = db.Hospitals.ToList();
            ViewBag.hospitallist = new SelectList(getlist1, "Hospital_ID", "Hospital_name");
            var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult facilitybooking(facilityappoinment facilityappoinment)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();

                //var getlist = db.Doctors.ToList();
                //ViewBag.doctorlist = new SelectList(getlist, "Doctor_ID", "Name");
                var getlist1 = db.Hospitals.ToList();
                ViewBag.hospitallist = new SelectList(getlist1, "Hospital_ID", "Hospital_name");
                var list = new List<String>() { "OPD","Dental facility","Ward/ Indoor facility","Minor OT/ Dressing Room","Physiotherapy",
               "ECG Services","Pharmacy","Radiology/X-ray facility","Ambulance Services","" };
                ViewBag.list = list;
                Random rd = new Random();
                facilityappoinment.ID = "AP" + rd.Next(1001, 9999).ToString();
                facilityappoinment.status = "Pending";
                db.Facilityappoinments.Add(facilityappoinment);
                db.SaveChanges();
                ViewBag.Message = "Appoinment Booked Successfully";
            }
            return View(facilityappoinment);
        }

        public ActionResult appoinmentdetails()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<facilityappoinment> facilityappoinments = db.Facilityappoinments.ToList();
            return View(facilityappoinments);
        }

        public ActionResult Editappoinment(string ID)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilityappoinment facilityappoinment1 = db.Facilityappoinments.Find(ID);
            if (facilityappoinment1 == null)
            {
                return HttpNotFound();
            }
            return View(facilityappoinment1);
        }

        [HttpPost]
        public ActionResult Editappoinment(facilityappoinment facilityappoinment1)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            db.Entry(facilityappoinment1).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        public ActionResult viewappoinment_patient_facility()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<facilityappoinment> facilityappoinments = db.Facilityappoinments.ToList();
           
            return View(facilityappoinments);
        }
     
        public ActionResult facility_appoinment_details_for_patient(string id)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<facilityappoinment> facilityappoinments = db.Facilityappoinments.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilityappoinment facilityappoinment = db.Facilityappoinments.Find(id);
            if (facilityappoinment == null)
            {
                return HttpNotFound();
            }

            return View(facilityappoinment);
            
        }
        public ActionResult viewappoinment_patient_doctor()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Appoinment> appoinments = db.Appoinments.ToList();
            return View(appoinments);
        }
        public ActionResult doctor_appoinment_details_for_patient(string id)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<Appoinment> appoinments = db.Appoinments.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appoinment appoinments1 = db.Appoinments.Find(id);
            if (appoinments1 == null)
            {
                return HttpNotFound();
            }

            return View(appoinments1);

        }
        public ActionResult updateappoinment()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            List<facilityappoinment> facilityappoinments = db.Facilityappoinments.ToList();

            return View(facilityappoinments);
        }
        public ActionResult update_test_results(string ID)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facilityappoinment facilityappoinment = db.Facilityappoinments.Find(ID);
            if (facilityappoinment == null)
            {
                return HttpNotFound();
            }
            return View(facilityappoinment);
        }
        [HttpPost]
        public ActionResult update_test_results(facilityappoinment facilityappoinment)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            db.Entry(facilityappoinment).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        public ActionResult add_records()
        {
            return View();
        }
        [HttpPost]
        public ActionResult add_records(Patient_recordby_Hadmin patient_Recordby_Hadmin)
        {
            if (ModelState.IsValid)
            {
                Hospitalmanagement_context db = new Hospitalmanagement_context();
                Random rd = new Random();
                patient_Recordby_Hadmin.ID = "REC" + rd.Next(1001, 9999).ToString();
                db.Patient_Recordby_Hadmins.Add(patient_Recordby_Hadmin);
                ViewBag.popup = "Records inserted successfully";
                db.SaveChanges();
                //ViewBag.Message = "Patient Registration Successful";
            }
            return View(patient_Recordby_Hadmin);
        }
        public ActionResult billing()
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            var list = db.Patients.ToList();
            ViewBag.patients = new SelectList(list, "Patient_ID", "Name");
            var newlist = new List<String>() { "Service","Consultation","In Stay"};
            ViewBag.newlist = newlist;
            return View();
        }
        [HttpPost]
        public ActionResult billing(Billing billing)
        {
            Hospitalmanagement_context db = new Hospitalmanagement_context();
            var list = db.Patients.ToList();
            ViewBag.patients = new SelectList(list, "Patient_ID", "Name");
            var newlist = new List<String>() { "Service", "Consultation", "In Stay" };
            ViewBag.newlist = newlist;
            billing.total_amount = billing.bill_amount1 + billing.bill_amount2 + billing.bill_amount3;
           
            return View(billing);
        }
    }
}
