using CheckIn.AirportDepartment;
using CheckIn.Services;

namespace CheckIn
{
    class Program
    {
        private static void Main(string[] args)
        {
            GreetingDesk greeting = new GreetingDesk(new ConsoleInputOutput());
            string fullName = greeting.Greet();
            Passenger passenger = new Passenger(fullName);

            if (!greeting.CheckERegistration())
            {
                CheckInDesk checkInDesk = new CheckInDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
                if (checkInDesk.CheckIn(passenger))
                {
                    BoardingPass boardingPass = checkInDesk.ChooseSeat();
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

            SecurityCheckDesk securityCheckDesk = new SecurityCheckDesk(new ConsoleInputOutput());

            securityCheckDesk.CheckPassenger(passenger);
            securityCheckDesk.ExcludedForbiddenItems(passenger);
            
        }
    }
}
