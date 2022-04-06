using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class HospitalFaciltyMapping
    {
        
        public string ID { get; set; }
        [Key]
        public string Facility_ID { get; set; }
        public string Facility_name { get; set; }
        public string Hospital_name { get; set; }
        public string Hospital_ID { get; set; }
        [ForeignKey("Hospital_ID")]
        public virtual Hospital Hospital { get; set; }
        public string Hadmin_ID { get; set; }
        [ForeignKey("Hadmin_ID")]
        public virtual HospitalAdmin HospitalAdmin { get; set; }
        public string Doctor_ID { get; set; }
        [ForeignKey("Doctor_ID")]
        public virtual Doctor Doctor { get; set; }

    }
        

    
}