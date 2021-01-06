using System.Collections.Generic;

namespace CheckIn.AirportDepartment
{
    public interface IAirFlightRepository
    {
        IReadOnlyList<string> GetAvailableSeats();
        void ReserveSeats(string bookingSeat);
        bool CheckBooking(string passportId);
    }
}
