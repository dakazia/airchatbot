using CheckIn.AirportDepartment;
using CheckIn.Services;

namespace CheckIn
{
    class Program
    {
        private static void Main(string[] args)
        {
            GreetingDesk greeting = new GreetingDesk(new ConsoleInputOutput());
            greeting.Greet();
            string fullName = greeting.GetFullName();
            string passportId = greeting.GetPassportId();
            Passenger passenger = new Passenger(fullName, passportId);

            if (!greeting.CheckERegistration())
            {
                CheckInDesk checkInDesk = new CheckInDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
                if (checkInDesk.CheckIn(passenger))
                {
                    BoardingPass boardingPass = checkInDesk.ChooseSeat();
                }
                else
                {
                    greeting.StopRegistration();
                    return;
                }
            }

            if (greeting.CheckBaggage())
            {
                BaggageRegistrationDesk baggageRegistrationDesk = new BaggageRegistrationDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
                BaggageLabel baggageLabel = new BaggageLabel(baggageRegistrationDesk.WeightBaggage());
            }

            SecurityCheckDesk securityCheckDesk = new SecurityCheckDesk(new ConsoleInputOutput());

            if (!securityCheckDesk.CheckPassenger(passenger).IsOkay)
            {
                greeting.StopRegistration();
                return;

            }

            PassportControlDesk passportControlDesk = new PassportControlDesk(new ConsoleInputOutput());
            if (!passportControlDesk.CheckPassport(passenger).IsOkay)
            {
                greeting.StopRegistration();
                return;
            }

        }
    }
}
