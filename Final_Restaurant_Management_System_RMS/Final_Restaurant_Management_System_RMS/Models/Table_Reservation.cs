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
    public class Table_Reservation
    {
        public int Reservation_ID { get; set; }
        public int Customer_ID { get; set; }
        public int Table_Number { get; set; }

        [Required(ErrorMessage = "Number_Of_People Is Required.")]
        [Display(Name = "Num_Of_People")]
        public int Number_Of_People { get; set; }

        [Required(ErrorMessage = "[Timing/Checkin] Is Required.")]
        [Display(Name = "[Timing/Checkin]")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh/mm/ss}")]
        public string Timing_Checkin { get; set; }

        [Required(ErrorMessage = "Branch Is Required.")]
        [Display(Name = "Branch")]
        [DataType(DataType.Text, ErrorMessage = "Only Alphabate can Accepted! ")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Email Is Required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone_Number Is Required.")]
        [Display(Name = "Phone_Number")]
        //[DataType(DataType.PhoneNumber)]
        ////[RegularExpression(@"^\+1 \(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number.")]
        ////[RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "You must provide a proper phone number.")]
        //[Range(10,10,ErrorMessage ="Min Max length is 11")]
        //[DisplayFormat(DataFormatString = "{0:####-#######}")]
        [StringLength(11, ErrorMessage = "Phone_Number cannot be longer than 11 characters.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided Phone_Number not valid")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Name Is Required.")]
        [Display(Name = "Name")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 25 characters.")]
        [DataType(DataType.Text, ErrorMessage = "Only Alphabate can Accepted! ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CNIC Is Required.")]
        [Display(Name = "CNIC")]
        [StringLength(14, ErrorMessage = "CNIC cannot be longer than 14 characters.")]
        [DataType(DataType.CreditCard, ErrorMessage = "Provided CNIC not valid")]
        public string CNIC { get; set; }

        [Required(ErrorMessage = "Date Is Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Date { set; get; }

        public void AddTable_Reservation(Table_Reservation Reservation)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertTableReservation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Reservation_ID", Reservation.Reservation_ID);
            cmd.Parameters.AddWithValue("@Customer_ID", Reservation.Customer_ID);
            cmd.Parameters.AddWithValue("@Table_Number", Reservation.Table_Number);
            cmd.Parameters.AddWithValue("@Number_Of_People", Reservation.Number_Of_People);
            cmd.Parameters.AddWithValue("@[Timing/Checkin]", Reservation.Timing_Checkin);
            cmd.Parameters.AddWithValue("@Branch", Reservation.Branch);
            cmd.Parameters.AddWithValue("@Email", Reservation.Email);
            cmd.Parameters.AddWithValue("@Name", Reservation.Name);
            cmd.Parameters.AddWithValue("@CNIC", Reservation.CNIC);
            cmd.Parameters.AddWithValue("@Date", Reservation.Date);
            cmd.ExecuteNonQuery();
            con.Close();
        }
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
        public Table_Reservation GetTable_Reservation_ListByID(int ID)
        {
            Table_Reservation DL = new Table_Reservation();
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Select * from Table_Reservation_DB where Reservation_ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                    DL.Reservation_ID = Convert.ToInt32(reader[0]);
                    DL.Customer_ID = Convert.ToInt32(reader[1]);
                    DL.Table_Number = Convert.ToInt32(reader[2]);
                    DL.Number_Of_People = Convert.ToInt32(reader[3]);
                    DL.Timing_Checkin = reader[4].ToString();
                    DL.Branch = reader[5].ToString();
                    DL.Email = reader[6].ToString();
                    DL.Phone_Number = reader[7].ToString();
                    DL.Name = reader[8].ToString();
                    DL.CNIC = reader[9].ToString();
                    DL.Date = reader[10].ToString();
            }
            reader.Close();
            return DL;
        }
        public void UpdateTable_Reservation_List(Table_Reservation list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Update Table_Reservation_DB set Customer_ID='" + list.Customer_ID + "',Table_Number='" + list.Table_Number + "',Number_Of_People='" + list.Number_Of_People + "',Timing_Checkin='" + list.Timing_Checkin + "',Branch='" + list.Branch + "',Email='" + list.Email + "',Phone_Number='" + list.Phone_Number + "',Branch='" + list.Branch + "',Name='" + list.Name + "',CNIC='" + list.CNIC + "',Date='" + list.Date + "' Where Reservation_ID='" + list.Reservation_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteTable_Reservation_List(Table_Reservation list)
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string query = "Delete From Table_Reservation_DB Where Reservation_ID = '" + Reservation_ID + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}