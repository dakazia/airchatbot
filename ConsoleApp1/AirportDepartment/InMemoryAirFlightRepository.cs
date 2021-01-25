using System.Collections.Generic;
using System.Linq;

namespace CheckIn.AirportDepartment
{
    class InMemoryAirFlightRepository : IAirFlightRepository
    {
        private readonly string[] _passportIdList = { "MB1234562", "KB563242", "PK8523695", "123456789"};
        private readonly List<string> _availableSeats = new List<string> { "23", "23B", "20", "10" };
        private readonly List<string> _bookingSeats = new List<string> { "1", "3", "8", "10" };
        public bool CheckBooking(string passportId)
        {
           return _passportIdList.Contains(passportId);
        }

        public IReadOnlyList<string> GetAvailableSeats()
        {
            return _availableSeats;
        }

        public IReadOnlyList<string> GetBookingSeats()
        {
            return _bookingSeats;
        }

        public void ReserveSeats(string bookingSeat)
        {
            _availableSeats.Remove(bookingSeat);
            _bookingSeats.Add(bookingSeat);
        }
    }
}
