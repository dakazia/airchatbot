using System;
using System.Collections.Generic;
using System.Text;
using CheckIn.AirportDepartment;
using CheckIn.Services;

namespace CheckIn
{
    internal class BaggageRegistrationDesk
    {
        private readonly IInputOutput _inputOutput;
        private readonly IAirFlightRepository _airFlightRepository;

        public BaggageRegistrationDesk(IInputOutput inputOutput, IAirFlightRepository airFlightRepository)
        {
            _inputOutput = inputOutput;
            _airFlightRepository = airFlightRepository;
        }

        public int WeightBaggage()
        {
            _inputOutput.WriteLine("Let's weight your baggage.");
            Random rnd = new Random();
            int weightBaggage = rnd.Next(1, 32);
            _inputOutput.WriteLine($"Weight of your baggage is {weightBaggage}");
            return weightBaggage;
        }

        public BaggageLabel DropBaggage()

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
    }
}
