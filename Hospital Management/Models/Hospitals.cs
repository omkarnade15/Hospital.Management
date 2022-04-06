using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Hospital
    {
        [Key]
        public string Hospital_ID { get; set; }


        public string Hospital_name { get; set; }
        public string Doctor_ID { get; set; }

        [ForeignKey("Doctor_ID")]
        public virtual Doctor Doctor{ get; set; }
        public string Hospital_address { get; set; }

    }
}