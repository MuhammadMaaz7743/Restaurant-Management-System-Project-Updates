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
    public class Guest_Deal_List
    {
        public int Deal_ID { get; set; }

        public string Deal_Name { get; set; }

        public string Food_Name { get; set; }

        public string Food_Category { get; set; }

        public int Deal_Price { get; set; }

        public List<Guest_Deal_List> Deal_ModuleList()
        {
            List<Guest_Deal_List> Deal_ModuleList = new List<Guest_Deal_List>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Deal_Module_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Deal_ModuleList.Add(new Guest_Deal_List
                {
                    Deal_ID = Convert.ToInt32(reader[0]),
                    Deal_Name = reader[1].ToString(),
                    Food_Name = reader[2].ToString(),
                    Food_Category = reader[3].ToString(),
                    Deal_Price = Convert.ToInt32(reader[4])

                });
            }
            reader.Close();
            return Deal_ModuleList;
        }
    }
}