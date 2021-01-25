using CheckIn.Services;
using System.Linq;

namespace CheckIn.AirportDepartment
{
    class BoardingCheckDesk
    {
        private readonly IInputOutput _inputOutput;
        private readonly IAirFlightRepository _airFlightRepository;

        public BoardingCheckDesk(IInputOutput inputOutput, IAirFlightRepository airFlightRepository)
        {
            _inputOutput = inputOutput;
            _airFlightRepository = airFlightRepository;
        }

        public BoardingCheckResult CheckBoardingPass(Passenger passenger)
        {
            if (_airFlightRepository.GetBookingSeats().Contains(passenger.BoardingPass.PassengerSeat))
            {
                _inputOutput.WriteLine(">> Everything is ok. You can board the plane. Have a good trip.");
                return new BoardingCheckResult(true);
            }
            else
            {
                _inputOutput.WriteLine(
                    ">>Unfortunately, your boarding document was not issued correctly.You cannot board the plane.");
                return new BoardingCheckResult(false);
            }
        }
    }

    internal class BoardingCheckResult
    {
        public bool IsOkay { get; private set; }

        public BoardingCheckResult(bool result)
        {
            IsOkay = result;
        }
    }
}
