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
    public class Staff_Registration
    {
        public int Staff_ID { get; set; }

        [Required(ErrorMessage = "Username Is Required.")]
        [Display(Name = "UserName")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 25 characters.")]
        [DataType(DataType.Text, ErrorMessage = "Only Alphabate can Accepted! ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password Is Required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile_No Is Required.")]
        [Display(Name = "Mobile_No")]
        [StringLength(11, ErrorMessage = "Mobile_No cannot be longer than 11 characters.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided Guest_Mobile_No not valid")]
        public string Phone_No { get; set; }

        [Required(ErrorMessage = "CNIC_No Is Required.")]
        [Display(Name = "CNIC_No")]
        [StringLength(14, ErrorMessage = "CNIC_No cannot be longer than 14 characters.")]
        [DataType(DataType.CreditCard, ErrorMessage = "Provided CNIC_No not valid")]
        public string CNIC_No { get; set; }

        [Required(ErrorMessage = "Permanent_Address Is Required.")]
        [Display(Name = "Permanent_Add")]
        public string Permanent_Address { get; set; }

        [Required(ErrorMessage = "Temporary_Address Is Required.")]
        [Display(Name = "Temporary_Add")]
        public string Temporary_Address { get; set; }

        [Required(ErrorMessage = "Email_Address Is Required.")]
        [Display(Name = "Email_Address")]
        public string Email_Address { get; set; }

        [Required(ErrorMessage = "Branch Is Required.")]
        [Display(Name = "Branch")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Shift_Timing Is Required.")]
        [Display(Name = "Shift_Timing")]
        public string Shift_Timing { get; set; }

        public void AddStaff(Staff_Registration Staff)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertStaffInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Staff.Name);
            cmd.Parameters.AddWithValue("@Password", Staff.Password);
            cmd.Parameters.AddWithValue("@Phone_No", Staff.Phone_No);
            cmd.Parameters.AddWithValue("@CNIC_No", Staff.CNIC_No);
            cmd.Parameters.AddWithValue("@Permanent_Address", Staff.Permanent_Address);
            cmd.Parameters.AddWithValue("@Temporary_Address", Staff.Temporary_Address);
            cmd.Parameters.AddWithValue("@Email_Address", Staff.Email_Address);
            cmd.Parameters.AddWithValue("@Branch", Staff.Branch);
            cmd.Parameters.AddWithValue("@Shift_Timing", Staff.Shift_Timing);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public List<Staff_Registration> GetAllStaffList()
        {
            List<Staff_Registration> StaffList = new List<Staff_Registration>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Staff_Info";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StaffList.Add(new Staff_Registration
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
        public Staff_Registration GetStaff_ListByID(int ID)
        {
            Staff_Registration DL = new Staff_Registration();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Staff_Info where Staff_ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    DL.Staff_ID = Convert.ToInt32(reader[0]);
                    DL.Name = reader[1].ToString();
                    DL.Password = reader[2].ToString();
                    DL.Phone_No = reader[3].ToString();
                    DL.CNIC_No = reader[4].ToString();
                    DL.Permanent_Address = reader[5].ToString();
                    DL.Temporary_Address = reader[6].ToString();
                    DL.Email_Address = reader[7].ToString();
                    DL.Branch = reader[8].ToString();
                    DL.Shift_Timing = reader[9].ToString();
            }
            reader.Close();
            return DL;
        }
        public void UpdateStaff_List(Staff_Registration list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Staff_Info set Name='" + list.Name + "',Password='" + list.Password + "',Phone_No='" + list.Phone_No + "',CNIC_No='" + list.CNIC_No + "',Permanent_Address='" + list.Permanent_Address + "',Temporary_Address='" + list.Temporary_Address + "',Email_Address='" + list.Email_Address + "',Branch='" + list.Branch + "',Shift_Timing='" + list.Shift_Timing + "' Where Staff_ID='" + list.Staff_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteStaff_List(Staff_Registration list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Insert into DeleteStaff_Info(Staff_ID,Name,Password,Phone_No,CNIC_No,Permanent_Address,Temporary_Address,Email_Address,Branch,Shift_Timing) Values ('" + list.Staff_ID + "','" + list.Name + "','" + list.Password + "','" + list.Phone_No + "','" + list.CNIC_No + "','" + list.Permanent_Address + "','" + list.Temporary_Address + "','" + list.Email_Address + "','" + list.Branch + "','" + list.Shift_Timing + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            string query1 = "Delete Staff_Info Where Staff_ID = '" + Staff_ID + "'";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}