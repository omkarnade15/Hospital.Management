using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Models
{
    public class HospitalAdmin
    {
        
        public string Hadmin_ID { get; set; }
        [Key]

        [Required(ErrorMessage = "* Username Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Hospital ID :")]
        public string Hospital_ID { get; set; }
        [Required(ErrorMessage = "* Patient Name Required")]
        public string Name { get; set; }
        [Display(Name = "Mobile Number :")]
        [Required(ErrorMessage = "* Mobile Number Required")]
        public long MobileNumber { get; set; }
        [Required(ErrorMessage = "* Gender Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "* Email Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string EmailID { get; set; }
        [Display(Name = "Date of Birth :")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dateofbirth { get; set; }
        [Display(Name = "Hospital Name :")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Hospital_name { get; set; }
        [Display(Name = "Address line 1:")]
        [Required(ErrorMessage = "* This field is Required")]
       
        public string Hospital_Addressline1 { get; set; }
        [Display(Name = "Address line 2:")]
        [Required(ErrorMessage = "* This field is Required")]

        public string Hospital_Addressline2 { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "* This field is Required")]

        public string city { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "* This field is Required")]

        public string state { get; set; }
        [Display(Name = "Pin Code")]
        [Required(ErrorMessage = "* This field is Required")]

        public string postalcode { get; set; }
        [Display(Name = "Hospital Website")]
        [Required(ErrorMessage = "* This field is Required")]
        public string Hospital_website { get; set; }
        [Display(Name = "Hospital Contact Number")]
        [Required(ErrorMessage = "* This field is Required")]
        public long Hospital_contactNumber { get; set; }
        [Display(Name = "Hospital Fax Number")]
        [Required(ErrorMessage = "* This field is Required")]
        public long Hospital_Faxnumber { get; set; }
       

    }
}