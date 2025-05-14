using System;

namespace TravelAgency.Models.Reservations
{
    public abstract class Reservation
    {
        public string ReservationID { get; protected set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        protected Reservation(string reservationId, string customerName, DateTime startDate, DateTime endDate)
        {
            ReservationID = reservationId;
            CustomerName = customerName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public abstract decimal CalculatePrice();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Reservation ID: {ReservationID}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Period: {StartDate:d} - {EndDate:d}");
            Console.WriteLine($"Total Price: {CalculatePrice():C}");
        }
    }
}