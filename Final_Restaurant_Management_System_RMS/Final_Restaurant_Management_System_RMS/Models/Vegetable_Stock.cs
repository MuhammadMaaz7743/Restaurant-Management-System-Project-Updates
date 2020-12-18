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
    public class Vegetable_Stock
    {
         public int Vegetable_ID { get; set; }

        [Required(ErrorMessage = "Vegetable_Name Is Required.")]
        [Display(Name = "Vegetable_Name")]
        public string Vegetable_Name { get; set; }

        [Required(ErrorMessage = "Stock Is Required.")]
        [Display(Name = "Stock")]
        public string Stock { get; set; }

        public void AddVegetable(Vegetable_Stock Vegetable)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertVegetable_Stock", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Vegetable_Name", Vegetable.Vegetable_Name);
            cmd.Parameters.AddWithValue("@Stock", Vegetable.Stock);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Vegetable_Stock> GetAllVegetable_StockList()
        {
            List<Vegetable_Stock> Vegetable_StockList = new List<Vegetable_Stock>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Vegetable_Stock";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Vegetable_StockList.Add(new Vegetable_Stock
                {
                    Vegetable_ID = Convert.ToInt32(reader[0]),
                    Vegetable_Name = reader[1].ToString(),
                    Stock = reader[2].ToString() 
                });
            }
            reader.Close();
            return Vegetable_StockList;
        }
        public Vegetable_Stock GetVegetable_Stock_ListByID(int ID)
        {
            Vegetable_Stock DL = new Vegetable_Stock();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Vegetable_Stock where Vegetable_ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    DL.Vegetable_ID = Convert.ToInt32(reader[0]);
                    DL.Vegetable_Name = reader[1].ToString();
                    DL.Stock = reader[2].ToString();
            }
            reader.Close();
            return DL;
        }
        public void UpdateVegetable_Stock_List(Vegetable_Stock list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Vegetable_Stock set Vegetable_Name='" + list.Vegetable_Name + "',Stock='" + list.Stock + "' Where Vegetable_ID='" + list.Vegetable_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteVegetable_Stock_List(Vegetable_Stock list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Delete From Vegetable_Stock Where Vegetable_ID = '" + Vegetable_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}