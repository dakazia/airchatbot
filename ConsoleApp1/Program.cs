using CheckIn.AirportDepartment;
using CheckIn.Services;

namespace CheckIn
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingDesk greeting = new GreetingDesk(new ConsoleInputOutput());
            string fullName = greeting.Greet();
            Passenger passenger = new Passenger(fullName);

            if (!greeting.CheckERegistration())
            {
                CheckinDesk checkinDesk = new CheckinDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
                if (checkinDesk.Checkin(passenger))
                {
                    BoardingPass boardingPass = checkinDesk.ChoiseSeat();
                }
                else
                {
                    return;
                }
            }

            if (greeting.CheckBaggage())
            {
                BaggageRegistrationDesk baggageRegistrationDesk = new BaggageRegistrationDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
                BaggageLabel baggageLabel = new BaggageLabel(baggageRegistrationDesk.WeightBaggage());
            }
        }
    }
}
