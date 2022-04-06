using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Hospitalmanagement_context:DbContext
    {
        public Hospitalmanagement_context() : base("Name=DbConnect")
        {

        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<HospitalAdmin> HospitalAdmins { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Appoinment> Appoinments { get; set; }
        public virtual DbSet<HospitalFaciltyMapping> HospitalFaciltyMappings { get; set; }
        public virtual DbSet<facilityappoinment> Facilityappoinments { get; set; }
        public virtual DbSet<Patient_record> Patient_Records { get; set; }
        public virtual DbSet<Patient_recordby_Hadmin> Patient_Recordby_Hadmins { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }




        public System.Data.Entity.DbSet<Hospital_Management.ViewModels.HospitalViewmodel> HospitalViewmodels { get; set; }
    }
}