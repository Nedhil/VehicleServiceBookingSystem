using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceBookingSystem.BuisnessLogic
{
    public static class Validation
    {
        public static void ValidationBooking(ServiceBooking booking, bool isNewBooking) 
        {
            if (string.IsNullOrWhiteSpace(booking.CustomerName)) 
            {
                throw new Exception("Customer Name must not be empty.");
            }
            if (string.IsNullOrWhiteSpace(booking.VehicleRegistration))
            {
                throw new Exception("Vehicle registration must not be empty.");
            }
            if (string.IsNullOrWhiteSpace(booking.ServiceType))
            {
                throw new Exception("Service type must not be empty.");
            }
            if (isNewBooking && booking.BookingDate.Date<DateTime.Today)
            {
                throw new Exception("Booking Date must be earlier than todays date.");
            }
            if (booking.Cost<=0)
            {
                throw new Exception("Cost must be greater than 0.");
            }

        }
    }
}
