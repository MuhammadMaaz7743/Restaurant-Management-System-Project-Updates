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
    public class Guest_Table_Reservation_List
    {
        public int Reservation_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Table_Number { get; set; }
        public int Number_Of_People { get; set; }
        public string Timing_Checkin { get; set; }
        public string Branch { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Date { set; get; }

        public List<Table_Reservation> GetAllTable_ReservationList()
        {
            List<Table_Reservation> Table_ReservationList = new List<Table_Reservation>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Table_Reservation_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Table_ReservationList.Add(new Table_Reservation
                {
                    Reservation_ID = Convert.ToInt32(reader[0]),
                    Customer_ID = Convert.ToInt32(reader[1]),
                    Table_Number = Convert.ToInt32(reader[2]),
                    Number_Of_People = Convert.ToInt32(reader[3]),
                    Timing_Checkin = reader[4].ToString(),
                    Branch = reader[5].ToString(),
                    Email = reader[6].ToString(),
                    Phone_Number = reader[7].ToString(),
                    Name = reader[8].ToString(),
                    CNIC = reader[9].ToString(),
                    Date = reader[10].ToString()
                });
            }
            reader.Close();
            return Table_ReservationList;
        }
    }
}