using CheckIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckIn.AirportDepartment
{
    internal class CheckinDesk
    {
        private readonly IInputOutput _inputOutput;
        private readonly IAirFlightRepository _airFlightRepository;

        public CheckinDesk(IInputOutput inputOutput, IAirFlightRepository airFlightRepository)
        {
            _inputOutput = inputOutput;
            _airFlightRepository = airFlightRepository;
        }

        public bool Checkin(Passenger passenger)
        {
            _inputOutput.WriteLine($"Dear {passenger.FullName}, please enter your passportID.");
            string passportID = _inputOutput.ReadLine();

            if (_airFlightRepository.CheckBooking(passportID))
            {
                _inputOutput.WriteLine("Thank you, all ok.");
                return true;
            }
            else
            {
                _inputOutput.WriteLine($"Sorry, {passenger.FullName}, I cannot find your on this flight");
                return false;
            }
        }

        public BoardingPass ChoiseSeat()
        {
            _inputOutput.WriteLine("Now let choise seat on bord from these seats:");

            foreach (var item in _airFlightRepository.GetAvaleableSeats())
            {
                _inputOutput.WriteLine(item);
            }

            string bookingSeat;

            do
            {
                _inputOutput.WriteLine("Please, enter your choice");
                bookingSeat = _inputOutput.ReadLine();
                _airFlightRepository.ReserveSeats(bookingSeat);
            } while (!(_airFlightRepository.GetAvaleableSeats().Contains(bookingSeat)));

            return new BoardingPass(bookingSeat);
        }
    }
}
