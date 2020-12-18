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
    public class Delete_Staff_Info
    {
        public int Staff_ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone_No { get; set; }
        public string CNIC_No { get; set; }
        public string Permanent_Address { get; set; }
        public string Temporary_Address { get; set; }
        public string Email_Address { get; set; }
        public string Branch { get; set; }
        public string Shift_Timing { get; set; }

        public List<Delete_Staff_Info> GetAllStaffList()
        {
            List<Delete_Staff_Info> StaffList = new List<Delete_Staff_Info>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from DeleteStaff_Info";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StaffList.Add(new Delete_Staff_Info
                {
                    Staff_ID = Convert.ToInt32(reader[0]),
                    Name = reader[1].ToString(),
                    Password = reader[2].ToString(),
                    Phone_No = reader[3].ToString(),
                    CNIC_No = reader[4].ToString(),
                    Permanent_Address = reader[5].ToString(),
                    Temporary_Address = reader[6].ToString(),
                    Email_Address = reader[7].ToString(),
                    Branch = reader[8].ToString(),
                    Shift_Timing = reader[9].ToString()
                });
            }
            reader.Close();
            return StaffList;
        }
    }
}