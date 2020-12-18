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
    public class Guest_Menu_List
    {
        public int Food_Number { get; set; }

       
        public string Food_Name { get; set; }

  
        public string Food_Category { get; set; }

        public int Food_Price { get; set; }

        public List<Guest_Menu_List> GetGuestMenu_ModuleList()
        {
            List<Guest_Menu_List> GuestMenu_ModuleList = new List<Guest_Menu_List>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Menu_Module_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GuestMenu_ModuleList.Add(new Guest_Menu_List
                {
                    Food_Number = Convert.ToInt32(reader[0]),
                    Food_Name = reader[1].ToString(),
                    Food_Category = reader[2].ToString(),
                    Food_Price = Convert.ToInt32(reader[3])
                });
            }
            reader.Close();
            return GuestMenu_ModuleList;
        }
    }
}