using CheckIn.Services;
using System.Linq;

namespace CheckIn.AirportDepartment
{
    internal class CheckInDesk
    {
        private readonly IInputOutput _inputOutput;
        private readonly IAirFlightRepository _airFlightRepository;

        public CheckInDesk(IInputOutput inputOutput, IAirFlightRepository airFlightRepository)
        {
            _inputOutput = inputOutput;
            _airFlightRepository = airFlightRepository;
        }

        public bool CheckIn(Passenger passenger)
        {
            _inputOutput.WriteLine($">> Dear {passenger.FullName}, please enter your passportID.");
            string passportId = _inputOutput.ReadLine();

            if (_airFlightRepository.CheckBooking(passportId))
            {
                _inputOutput.WriteLine(">> Thank you, all is ok.");
                return true;
            }
            else
            {
                _inputOutput.WriteLine($">> Sorry, {passenger.FullName}, I cannot find your on this flight");
                return false;
            }
        }

        public BoardingPass ChooseSeat()
        {
            _inputOutput.WriteLine(">> Now let choice seat on board from these seats:");

            foreach (var item in _airFlightRepository.GetAvailableSeats())
            {
                _inputOutput.WriteLine(item);
            }

            string bookingSeat;

            do
            {
                _inputOutput.WriteLine(">> Please, enter your choice");
                bookingSeat = _inputOutput.ReadLine();
            } while (!_airFlightRepository.GetAvailableSeats().Contains(bookingSeat));

            _airFlightRepository.ReserveSeats(bookingSeat);

            return new BoardingPass(bookingSeat);
        }
    }
}

