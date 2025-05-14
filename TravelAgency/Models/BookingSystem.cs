using System;
using System.Collections.Generic;
using TravelAgency.Models.Reservations;

namespace TravelAgency.Models
{
    public class BookingSystem
    {
        private readonly Dictionary<string, Reservation> _reservations = new Dictionary<string, Reservation>();
        private int _reservationCounter = 1;

        public Reservation CreateReservation(string reservationType, string customerName,
                                           DateTime startDate, DateTime endDate,
                                           params object[] additionalParams)
        {
            string reservationId = $"RES-{_reservationCounter++:D6}";

            Reservation reservation = reservationType switch
            {
                "Hotel" => new HotelReservation(
                    reservationId, customerName, startDate, endDate,
                    (string)additionalParams[0], (string)additionalParams[1]),

                "Flight" => new FlightReservation(
                    reservationId, customerName, startDate,
                    (string)additionalParams[0], (string)additionalParams[1]),

                "CarRental" => new CarRentalReservation(
                    reservationId, customerName, startDate, endDate,
                    (string)additionalParams[0], (bool)additionalParams[1]),

                _ => throw new ArgumentException("Invalid reservation type")
            };

            _reservations.Add(reservationId, reservation);
            return reservation;
        }

        public bool CancelReservation(string reservationId)
        {
            return _reservations.Remove(reservationId);
        }

        public decimal GetTotalBookingValue()
        {
            decimal total = 0m;
            foreach (var reservation in _reservations.Values)
            {
                total += reservation.CalculatePrice();
            }
            return total;
        }

        public void DisplayAllReservations()
        {
            foreach (var reservation in _reservations.Values)
            {
                reservation.DisplayDetails();
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}