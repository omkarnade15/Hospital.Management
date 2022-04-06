using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Facility
    {
        [Key]
        public string Facility_ID { get; set; }
        [Required]
        public string Facility_name { get; set; }
    }
}