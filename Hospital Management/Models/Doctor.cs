using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class Doctor
    {
        
       
        public string Doctor_ID { get; set; }
        
        [Required(ErrorMessage = "* Username Required")]
        [Key]
      
        public string Username { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-z])(?=.*[0-9])(?=.*?[!@#$%\^&*\(\)\-_+=;:'""\/\[\]{},.<>|`]).{8,32}", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }
        [Required(ErrorMessage = " * Patient Name Required")]
        public string Name { get; set; }
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([7-9][0-9]{9})$", ErrorMessage = "Invalid Mobile Number.")]
        public long MobileNumber { get; set; }
        [Required(ErrorMessage = "* Gender Required")]
        public string Gender { get; set; }
        [Display(Name = "Email ID:")]
        [Required(ErrorMessage = "* Email Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailID { get; set; }
        [Display(Name = "Date of Birth :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dateofbirth { get; set; }
        [Required(ErrorMessage = "* Qualification Required")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "* Speciality Required")]
        public string Speciality { get; set; }
        [Required(ErrorMessage = "* Experience Required")]
        public double Experience { get; set; }
        [Display(Name = "Hospital Name")]
        [Required(ErrorMessage = "* This field is Required")]

        public string Hospital_name { get; set; }
        [Display(Name = "Day of week available:")]
        [Required(ErrorMessage = "* This field is Required")]

        public string Day_available { get; set; }
        [Display(Name = "Time Available:")]
        public string time_available { get; set; }


    }
}