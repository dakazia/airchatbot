using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CheckIn.AirportDepartment
{
    class InMemoryAirFlightRepository : IAirFlightRepository
    {
        private readonly string[] passportIDList = { "MB1234562", "KB563242", "PK8523695"};
        private readonly List<string> avaliableSeats = new List<string> { "23", "23B", "20", "10" };

        public bool CheckBooking(string passportID)
        {
           return passportIDList.Contains(passportID);
        }

        public IReadOnlyList<string> GetAvaleableSeats()
        {
            return avaliableSeats;
        }

        public void ReserveSeats(string bookingSeat)
        {
            avaliableSeats.Remove(bookingSeat);
        }
    }
}
