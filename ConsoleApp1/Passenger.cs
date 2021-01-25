using System;
using System.Collections.Generic;

namespace CheckIn
{
    internal class Passenger
    {
        private readonly string[] _allPossibleItems = new string[] { "sword", "dagger", "saber", "knife", "scissors", "weapon",
            "bottle", "clothes", "camera", "mobile phone", "apple",
            "handkerchief", "bag", "wallet", "pen", "notepad", "laptop"  };

        private readonly string[] _allPossibleSeats = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        private readonly List<string> _personalBelongings = new List<string>();
        public string[] AllPossibleItems { get; set; }
        public string[] AllPossibleSeats { get; set; }
        public string FullName { get; set; }

        public string PassportNumber { get; set; }

        public BoardingPass BoardingPass { get; set; }

        public List<string> PersonalBelongings { get => _personalBelongings; }

        public Passenger(string fullName, string passportId, bool eRegistration)
        {
            FullName = fullName;
            PassportNumber = passportId;

            AllPossibleItems = _allPossibleItems;

            int amount = new Random().Next(AllPossibleItems.Length);
            for (int i = 0; i < amount; i++)
            {
                int index = new Random().Next(AllPossibleItems.Length);
                _personalBelongings.Add(AllPossibleItems[index]);
            }

            if (eRegistration)
            {
                int index = new Random().Next(AllPossibleSeats.Length);

                BoardingPass = new BoardingPass(AllPossibleSeats[index]);
            }
            
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
