using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Appoinment
    {
        [Key]
        public string ID { get; set; }
        public string Patient_ID { get; set; }
        [ForeignKey("Patient_ID")]
        public virtual Patient Patient { get; set; }
        public string Doctor_ID { get; set; }
        [ForeignKey("Doctor_ID")]
        public virtual Doctor Doctor { get; set; }
        [Display(Name = "Date of appoinment :")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Appoinment_date { get; set; }
        [Display(Name = "Facility Name:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Facility_name { get; set; }
        [Required(ErrorMessage = "* This field is Required")]
        [Display(Name = "Hospital Name:")]
        public string Hospital_name { get; set; }
        [Display(Name = "Doctor Name:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Doctor_name { get; set; }
        public string status { get; set; }
        public string Test_result { get; set; }

    }
}