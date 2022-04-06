using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Patient
    {
        
        public string Patient_ID { get; set; }
        
        [Required(ErrorMessage = "* Username Required")]
        [Key]
        public string Username { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "* Patient Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Mobile Number Required")]
        [Display(Name = "Contact Number")]
        public long MobileNumber { get; set; }
        [Required(ErrorMessage = "* Gender Required")]
        public string Gender { get; set; }
        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "* Email Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailID { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dateofbirth { get; set; }
        public string Test_results { get; set; }
    }
}