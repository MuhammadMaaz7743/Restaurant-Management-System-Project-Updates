using System;
using System.Web;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Restaurant_Management_System_RMS.Models
{
    public class Guest_List
    {
         public int Guest_ID { get; set; }

        [Required(ErrorMessage = "Guest_Name Is Required.")]
        [Display(Name = "Guest_Name")]
        public string Guest_Name { get; set; }

        [Required(ErrorMessage = "Guest_CNIC Is Required.")]
        [Display(Name = "Guest_CNIC")]
        public string Guest_CNIC { get; set; }

        [Required(ErrorMessage = "Guest_Mobile_No Is Required.")]
        [Display(Name = "Guest_Mobile_No")]
        public string Guest_Mobile_No { get; set; }

        [Required(ErrorMessage = "Guest_Email Is Required.")]
        [Display(Name = "Guest_Email")]
        public string Guest_Email { get; set; }

        public List<Guest_List> GetAllGuestList()
        {
            List<Guest_List> GuestList = new List<Guest_List>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Guest_Info";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GuestList.Add(new Guest_List
                {
                    Guest_ID = Convert.ToInt32(reader[0]),
                    Guest_Name = reader[1].ToString(),
                    Guest_CNIC = reader[2].ToString(),
                    Guest_Mobile_No = reader[3].ToString(),
                    Guest_Email = reader[4].ToString()
                });
            }
            reader.Close();
            return GuestList;
        }
    }
}