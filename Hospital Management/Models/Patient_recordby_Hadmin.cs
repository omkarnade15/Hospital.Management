using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Models
{
    public class Patient_recordby_Hadmin
    {
        [Key]
        public string ID { get; set; }
        [Display(Name = "Patient Name:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Name_of_patient { get; set; }
        [Display(Name = "Patient Age:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Age { get; set; }
        [Display(Name = "Patient Sugar Level:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string sugar_level { get; set; }
        [Display(Name = "Patient Blood Pressure Level:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string BP_level { get; set; }
        [Display(Name = "Any Previous Disease:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string previous_diseases { get; set; }
        [Display(Name = "Latest test results:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string latest_test_results { get; set; }
        [Display(Name = "Admission Details:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Admission_details { get; set; }
        [Display(Name = "Discharge Details:")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Discharge_details { get; set; }
    }
}