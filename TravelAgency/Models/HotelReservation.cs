namespace TravelAgency.Models.Reservations
{
    public class HotelReservation : Reservation
    {
        public string RoomType { get; set; }
        public string MealPlan { get; set; }
        private const decimal DailyRate = 100m;

        public HotelReservation(string reservationId, string customerName, DateTime startDate, DateTime endDate,
                              string roomType, string mealPlan)
            : base(reservationId, customerName, startDate, endDate)
        {
            RoomType = roomType;
            MealPlan = mealPlan;
        }

        public override decimal CalculatePrice()
        {
            int days = (EndDate - StartDate).Days;
            decimal price = days * DailyRate;

            price *= RoomType switch
            {
                "Suite" => 1.5m,
                "Deluxe" => 1.2m,
                _ => 1m
            };

            price += MealPlan switch
            {
                "All Inclusive" => days * 50,
                "Half Board" => days * 30,
                _ => 0
            };

            return price;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Type: Hotel Reservation");
            Console.WriteLine($"Room Type: {RoomType}");
            Console.WriteLine($"Meal Plan: {MealPlan}");
        }
    }
}