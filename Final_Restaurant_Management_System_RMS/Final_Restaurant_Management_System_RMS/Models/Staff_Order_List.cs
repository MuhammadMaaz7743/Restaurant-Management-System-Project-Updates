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
    public class Staff_Order_List
    {
        public int Order_Number { get; set; }
        public int Customer_ID { get; set; }

        [Required(ErrorMessage = "Table_Number Is Required.")]
        [Display(Name = "Table_Number")]
        public int Table_Number { get; set; }

        [Required(ErrorMessage = "Date Is Required.")]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Branch Is Required.")]
        [Display(Name = "Branch")]
        public string Branch { get; set; }

        [Display(Name = "Food_Category")]
        public string Food_Category { get; set; }

        [Display(Name = "Deal_Name")]
        public string Deal_Name { get; set; }

        [Required(ErrorMessage = "Food_Name Is Required.")]
        [Display(Name = "Food_Name")]
        public string Food_Name { get; set; }

        public void AddOrder_List(Staff_Order_List orderlist)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertOrder_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Table_Number", orderlist.Table_Number);
            cmd.Parameters.AddWithValue("@Date", orderlist.Date);
            cmd.Parameters.AddWithValue("@Branch", orderlist.Branch);
            cmd.Parameters.AddWithValue("@Food_Category", orderlist.Food_Category);
            cmd.Parameters.AddWithValue("@Deal_Name", orderlist.Deal_Name);
            cmd.Parameters.AddWithValue("@Food_Name", orderlist.Food_Name);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Staff_Order_List> GetAllOrder_List()
        {
            List<Staff_Order_List> StaffList = new List<Staff_Order_List>();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Order_List_DB";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StaffList.Add(new Staff_Order_List
                {
                    Order_Number = Convert.ToInt32(reader[0]),
                    Customer_ID = Convert.ToInt32(reader[1]),
                    Table_Number = Convert.ToInt32(reader[2]),
                    Date = reader[3].ToString(),
                    Branch = reader[4].ToString(),
                    Food_Category = reader[5].ToString(),
                    Deal_Name = reader[6].ToString(),
                    Food_Name = reader[7].ToString()
                });
            }
            reader.Close();
            return StaffList;
        }
        public Staff_Order_List GetOrder_ListByID(int ID)
        {
            Staff_Order_List DL = new Staff_Order_List();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Order_List_DB where Order_Number='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DL.Order_Number = Convert.ToInt32(reader[0]);
                DL.Customer_ID = Convert.ToInt32(reader[1]);
                DL.Table_Number = Convert.ToInt32(reader[2]);
                DL.Date = reader[3].ToString();
                DL.Branch = reader[4].ToString();
                DL.Food_Category = reader[5].ToString();
                DL.Deal_Name = reader[6].ToString();
                DL.Food_Name = reader[7].ToString();
            }
            reader.Close();
            return DL;
        }
        public void UpdateOrder_List(Staff_Order_List list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Order_List_DB set Customer_ID='" + list.Customer_ID + "',Table_Number='" + list.Table_Number + "',Date='" + list.Date + "',Branch='" + list.Branch + "',Food_Category='" + list.Food_Category + "',Deal_Name='" + list.Deal_Name + "',Food_Name='" + list.Food_Name + "' Where Order_Number='" + list.Order_Number + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}