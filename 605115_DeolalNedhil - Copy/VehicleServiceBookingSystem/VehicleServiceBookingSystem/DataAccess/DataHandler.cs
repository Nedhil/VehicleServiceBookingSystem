using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace VehicleServiceBookingSystem.DataAccess
{
    public class DataHandler
    {
        private string connectionString = @"Data Source=WIN-D9ID2HMIDFR\SQLEXPRESS01;Initial Catalog=WorkshopDB;Integrated Security=True";

        public DataTable GetAllBookings()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT BookingID, CustomerName, VehicleRegistration, ServiceType, BookingDate, Cost FROM ServiceBookings";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void InsertBooking(string name, string reg, string type, DateTime date, decimal cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ServiceBookings (CustomerName, VehicleRegistration, ServiceType, BookingDate, Cost) VALUES (@Name, @Reg, @Type, @Date, @Cost)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Reg", reg);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Cost", cost);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBooking(int id, string name, string reg, string type, DateTime date, decimal cost)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ServiceBookings SET CustomerName = @Name, VehicleRegistration = @Reg, ServiceType = @Type, BookingDate = @Date, Cost = @Cost WHERE BookingID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Reg", reg);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Cost", cost);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBooking(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ServiceBookings WHERE BookingID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}