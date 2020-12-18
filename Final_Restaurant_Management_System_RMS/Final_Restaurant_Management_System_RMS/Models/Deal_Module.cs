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
    public class Deal_Module
    {
        public int Deal_ID { get; set; }

        [Required(ErrorMessage = "Deal_Name Is Required.")]
        [Display(Name = "Deal_Name")]
        public string Deal_Name { get; set; }

        [Required(ErrorMessage = "Food_Name Is Required.")]
        [Display(Name = "Food_Name")]
        public string Food_Name { get; set; }

        [Required(ErrorMessage = "Food_Category Is Required.")]
        [Display(Name = "Food_Category")]
        public string Food_Category { get; set; }

        [Required(ErrorMessage = "Deal_Price Is Required.")]
        [Display(Name = "Deal_Price")]
        public int Deal_Price { get; set; }


        public void AddDeal_Module(Deal_Module Staff)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertDeal_Modele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Deal_Name", Staff.Deal_Name);
            cmd.Parameters.AddWithValue("@Food_Name", Staff.Food_Name);
            cmd.Parameters.AddWithValue("@Food_Category", Staff.Food_Category);
            cmd.Parameters.AddWithValue("@Deal_Price", Staff.Deal_Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Deal_Module> GetAllDeal_ModuleList()
        {
            List<Deal_Module> Deal_ModuleList = new List<Deal_Module>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Deal_Module_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Deal_ModuleList.Add(new Deal_Module
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
        public Deal_Module GetDeal_Module_ListByID(int ID)
        {
            Deal_Module DL = new Deal_Module();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Deal_Module_DB where Deal_ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DL.Deal_ID = Convert.ToInt32(reader[0]);
                DL.Deal_Name = reader[1].ToString();
                DL.Food_Name = reader[2].ToString();
                DL.Food_Category = reader[3].ToString();
                DL.Deal_Price = Convert.ToInt32(reader[4]);
            }
            reader.Close();
            return DL;
        }
        public void UpdateDeal_Module_List(Deal_Module list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Deal_Module_DB set Deal_Name='" + list.Deal_Name + "',Food_Name='" + list.Food_Name + "',Food_Category='" + list.Food_Category + "',Deal_Price='" + list.Deal_Price +"' Where Deal_ID='" + list.Deal_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteDeal_Module_List(Deal_Module list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Delete From Deal_Module_DB Where Deal_ID = '" + Deal_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}