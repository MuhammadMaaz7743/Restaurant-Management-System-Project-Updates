using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Restaurant_Management_System_RMS.Models
{
    public class LoginAdmin
    {
        bool check;

        [Required(ErrorMessage = "Username Is Required.")]
        [Display(Name = "UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Autherize_Admin(string Username, string Password)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select count(*) from Admin_Info where Name='" + Username + "' and Password='" + Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            check = Convert.ToBoolean(cmd.ExecuteScalar());
            return check;
        }
    }

    public class LoginStaff
    {
        bool check;

        [Required(ErrorMessage = "Username Is Required.")]
        [Display(Name = "UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Autherize_Staff(string Username, string Password)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "select count(*) from Staff_Info where Name='" + Username + "' and Password='" + Password + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            check = Convert.ToBoolean(cmd.ExecuteScalar());
            return check;
        }
    }
        public class LoginGuest
        {
            public int Guest_ID { get; set; }

            [Required(ErrorMessage = "Guest_Name Is Required.")]
            [Display(Name = "Guest_Name")]
            [StringLength(25, MinimumLength = 6, ErrorMessage = "Guest_Name must be between 6 and 25 characters.")]
            [DataType(DataType.Text,ErrorMessage="Only Alphabate can Accepted! ")]
            public string Guest_Name { get; set; }

            [Required(ErrorMessage = "Guest_CNIC Is Required.")]
            [Display(Name = "Guest_CNIC")]
            [StringLength(14, ErrorMessage = "Guest_CNIC cannot be longer than 14 characters.")]
            [DataType(DataType.CreditCard, ErrorMessage = "Provided Guest_CNIC not valid")]
            public string Guest_CNIC { get; set; }

            [Required(ErrorMessage = "Guest_Mobile_No Is Required.")]
            [Display(Name = "Guest_Mobile_No")]
            [StringLength(11, ErrorMessage = "Guest_Mobile_No cannot be longer than 11 characters.")]
            [DataType(DataType.PhoneNumber, ErrorMessage = "Provided Guest_Mobile_No not valid")]
            public string Guest_Mobile_No { get; set; }
            
            [Required(ErrorMessage = "Guest_Email Is Required.")]
            [Display(Name = "Guest_Email")]
            [DataType(DataType.EmailAddress)]
            public string Guest_Email { get; set; }

            public void AddGuest(LoginGuest Guest)
            {
                string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertGuestInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Guest_Name", Guest.Guest_Name);
                cmd.Parameters.AddWithValue("@Guest_CNIC", Guest.Guest_CNIC);
                cmd.Parameters.AddWithValue("@Guest_Mobile_No", Guest.Guest_Mobile_No);
                cmd.Parameters.AddWithValue("@Guest_Email", Guest.Guest_Email);
                cmd.ExecuteNonQuery();
                con.Close();
            }
    }
}