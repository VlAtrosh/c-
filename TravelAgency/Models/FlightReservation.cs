namespace TravelAgency.Models.Reservations
{
    public class FlightReservation : Reservation
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        private const decimal BaseFlightPrice = 200m;

        public FlightReservation(string reservationId, string customerName, DateTime startDate,
                               string departureAirport, string arrivalAirport)
            : base(reservationId, customerName, startDate, startDate) // Для перелета EndDate = StartDate
        {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
        }

        public override decimal CalculatePrice()
        {
            decimal price = BaseFlightPrice;

            int distance = Math.Abs(DepartureAirport.Length - ArrivalAirport.Length) * 100;
            price += distance * 0.5m;

            return price;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Type: Flight Reservation");
            Console.WriteLine($"Route: {DepartureAirport} → {ArrivalAirport}");
        }
    }
}