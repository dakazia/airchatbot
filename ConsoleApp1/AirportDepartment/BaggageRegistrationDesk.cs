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

            string baggageType = weightBaggage switch
            {
                _ when weightBaggage <= 10 => "It is carry-on bag, you can take it in the cabin.",
                _ when weightBaggage <= 23 => "It will be prepared for loading into the hold of the aircraft.",
                _ when weightBaggage <= 32 => "It is large type. You need to make a surcharge for extra kilos.",
                _ => "We cannot process it. It is too heavy for general air travel.",
            };

            _inputOutput.WriteLine(baggageType);

            return weightBaggage;
        }

        public BaggageLabel DropBaggage(int weightBaggage)
        {

            if (weightBaggage >= 32)
            {
                return null;
            }
            return new BaggageLabel(weightBaggage);
        }
    }
}
