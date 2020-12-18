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
    public class Menu_Module
    {
        public int Food_Number { get; set; }

        [Required(ErrorMessage = "Food_Name Is Required.")]
        [Display(Name = "Food_Name")]
        public string Food_Name { get; set; }

        [Required(ErrorMessage = "Food_Category Is Required.")]
        [Display(Name = "Food_Category")]
        public string Food_Category { get; set; }

        [Required(ErrorMessage = "Food_Price Is Required.")]
        [Display(Name = "Food_Price")]
        public int Food_Price { get; set; }

        public void AddMenu_Module(Menu_Module Staff)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertMenu_Module", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Food_Number", Staff.Food_Number);
            cmd.Parameters.AddWithValue("@Food_Category", Staff.Food_Category);
            cmd.Parameters.AddWithValue("@Food_Price", Staff.Food_Price);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Menu_Module> GetAllMenu_ModuleList()
        {
            List<Menu_Module> Menu_ModuleList = new List<Menu_Module>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Menu_Module_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Menu_ModuleList.Add(new Menu_Module
                {
                    Food_Number = Convert.ToInt32(reader[0]),
                    Food_Name = reader[1].ToString(),
                    Food_Category = reader[2].ToString(),
                    Food_Price = Convert.ToInt32(reader[3])
                });
            }
            reader.Close();
            return Menu_ModuleList;
        }
        public Menu_Module GetMenu_Module_ListByID(int ID)
        {
            Menu_Module DL = new Menu_Module();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Menu_Module_DB where Food_Number='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    DL.Food_Number = Convert.ToInt32(reader[0]);
                    DL.Food_Name = reader[1].ToString();
                    DL.Food_Category = reader[2].ToString();
                    DL.Food_Price = Convert.ToInt32(reader[3]);
            }
            reader.Close();
            return DL;
        }
        public void UpdateMenu_Module_List(Menu_Module list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Menu_Module_DB set Food_Name='" + list.Food_Name + "',Food_Category='" + list.Food_Category + "',Food_Price='" + list.Food_Price + "' Where Food_Number='" + list.Food_Number + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteMenu_Module_List(Menu_Module list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Delete From Menu_Module_DB Where Food_Number = '" + Food_Number + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}