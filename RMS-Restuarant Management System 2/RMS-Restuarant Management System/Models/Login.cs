using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;

namespace RMS_Restuarant_Management_System.Models
{
    public class LoginAdmin
    {
        bool check;
        [Required(ErrorMessage = "Username Is Required.")]
        [Display(Name = "Username")]
        public int Admin_ID { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Autherize_Admin(int Username, string Password)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select count(*) from Admin_Login_DB where User_Id='" + Username + "' and Password='" + Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            check = Convert.ToBoolean(cmd.ExecuteScalar());
            return check;
        }
    }

    public class LoginStaff
    {
        bool check;
        [Required(ErrorMessage = "Username Is Required.")]
        [Display(Name = "Username")]
        public int Staff_ID { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Autherize_Staff(int Username, string Password)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select count(*) from Staff_Login_DB where User_Id='" + Username + "' and Password='" + Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            check = Convert.ToBoolean(cmd.ExecuteScalar());
            return check;
        }
    }
}