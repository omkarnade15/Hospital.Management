using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class facilityappoinment
    {
        [Key]
        public string ID { get; set; }
        public string Patient_ID { get; set; }
        [ForeignKey("Patient_ID")]
        public virtual Patient Patient { get; set; }


        [Display(Name = "Date of appoinment :")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Appoinment_date { get; set; }
        [Display(Name = "Facility Name:")]

        public string Facility_name { get; set; }
        [Required(ErrorMessage = "* This field is Required")]
        [Display(Name = "Hospital Name:")]
        public string Hospital_name { get; set; }

        public string Hadmin_ID { get; set; }
        [ForeignKey("Hadmin_ID")]
        public virtual HospitalAdmin HospitalAdmin { get; set; }
        public string status { get; set; }
        public string Test_result { get; set; }

    }
}