using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Hospital_Management.Models
{
    public class Admin
    {
        [Key]
        [Required(ErrorMessage = "* Username Required")]

        public string Username { get; set; }
        [Required(ErrorMessage = "* Password Required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-z])(?=.*[0-9])(?=.*?[!@#$%\^&*\(\)\-_+=;:'""\/\[\]{},.<>|`]).{8,32}", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }
    }
}