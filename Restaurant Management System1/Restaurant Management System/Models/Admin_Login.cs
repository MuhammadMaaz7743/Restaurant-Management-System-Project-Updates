using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Management_System.Models
{
    public class Admin_Login
    {
        [Required]
            [Display(Name = "Username")]
            public int User_id { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
        public class Staff_Login
        {
            [Required]
            [Display(Name = "Username")]
            public int User_id { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
}