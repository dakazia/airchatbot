using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn
{
    class Passenger
    {

        public string FullName { get; set; }

        public string PassportNumber { get; set; }

        public BoardingPass BoardingPasses { get; set; }

        public List<string> PesonalBelongings { get; set; }

        public Passenger(string fullName)
        {
            FullName = fullName;
        }
    }
    internal class BoardingPass
    {
        public string PassengerSeat { get; set; }

        public BoardingPass(string passengerSeat)
        {
            PassengerSeat = passengerSeat;
        }
    }

    internal class BaggageLabel
    {
        public int WeightBaggage { get; set; }

        public BaggageLabel(int weightBaggage)
        {
            WeightBaggage = weightBaggage;
        }
    }
}
