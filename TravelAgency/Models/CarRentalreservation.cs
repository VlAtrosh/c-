namespace TravelAgency.Models.Reservations
{
    public class CarRentalReservation : Reservation
    {
        public string CarType { get; set; }
        public bool InsuranceIncluded { get; set; }
        private const decimal DailyCarRate = 50m;

        public CarRentalReservation(string reservationId, string customerName, DateTime startDate,
                                  DateTime endDate, string carType, bool insuranceIncluded)
            : base(reservationId, customerName, startDate, endDate)
        {
            CarType = carType;
            InsuranceIncluded = insuranceIncluded;
        }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal price = days * DailyCarRate;

            price *= CarType switch
            {
                "SUV" => 1.3m,
                "Premium" => 1.5m,
                "Luxury" => 2m,
                _ => 1m
            };

            if (InsuranceIncluded)
                price += days * 15;

            return price;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Type: Car Rental");
            Console.WriteLine($"Car Type: {CarType}");
            Console.WriteLine($"Insurance: {(InsuranceIncluded ? "Yes" : "No")}");
        }
    }
}