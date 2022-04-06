using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management.Models
{
    public class Billing
    {
        [Key]
        public string ID { get; set; }
        public string Patient_ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("Name")]
        public virtual Patient Patient { get; set; }
        public string bill_type1 { get; set; }
        public string bill_type2 { get; set; }
        public string bill_type3 { get; set; }
        public int bill_amount1 { get; set; }
        public int bill_amount2 { get; set; }
        public int bill_amount3 { get; set; }
        public int total_amount { get; set; }
    }
}