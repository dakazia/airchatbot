using CheckIn.AirportDepartment;
using CheckIn.AirportDepartment.Table;
using CheckIn.Services;

namespace CheckIn
{
    class Program
    {
        private static void Main(string[] args)
        {
            GreetingDesk greeting = new GreetingDesk(new ConsoleInputOutput());
            greeting.Greet();
            TableDeparture tableDeparture = new TableDeparture(new ConsoleInputOutput());
            tableDeparture.ShowTable(tableDeparture.WriteDataToTable());
            string fullName = greeting.GetFullName();
            string passportId = greeting.GetPassportId();
            bool eRegistration = greeting.CheckERegistration();
            Passenger passenger = new Passenger(fullName, passportId, eRegistration);

            if (!eRegistration)
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
            else
            {
                BoardingPass eBoardingPass = passenger.BoardingPass;
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

            BoardingCheckDesk boardingCheckDesk = new BoardingCheckDesk(new ConsoleInputOutput(), new InMemoryAirFlightRepository());
            if (!boardingCheckDesk.CheckBoardingPass(passenger).IsOkay)
            {
                greeting.StopRegistration();
                return;
            }
        }
    }
}
