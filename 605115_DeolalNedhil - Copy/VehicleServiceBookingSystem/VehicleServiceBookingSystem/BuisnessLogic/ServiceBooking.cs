using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceBookingSystem.BuisnessLogic
{
    public class ServiceBooking
    {
        public int BookingID { get; set; }
        public string CustomerName { get; set; }
        public string VehicleRegistration { get; set; }
        public string ServiceType { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Cost { get; set; }
        public ServiceBooking(int bookingID, string customerName, string vehicleRegistration, string serviceType, DateTime bookingDate, decimal cost)
        {
            BookingID = bookingID;
            CustomerName = customerName;
            VehicleRegistration = vehicleRegistration;
            ServiceType = serviceType;
            BookingDate = bookingDate;
            Cost = cost;
        }
    }
}
