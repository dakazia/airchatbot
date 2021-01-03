using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn.AirportDepartment
{
    public interface IAirFlightRepository
    {
        IReadOnlyList<string> GetAvaleableSeats();
        void ReserveSeats(string bookingSeat);
        bool CheckBooking(string passportID);
    }
}
