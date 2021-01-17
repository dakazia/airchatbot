using CheckIn.Services;

namespace CheckIn.AirportDepartment
{
    internal class PassportControlDesk
    {
        private readonly IInputOutput _inputOutput;

        public PassportControlDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public PassportCheckResult CheckPassport(Passenger passenger)
        {
            _inputOutput.WriteLine($"Dear {passenger.FullName}, please choose the flow to go through passport control." +
                                   $" Are you a citizen of the Republic of Belarus?");

            string answer;
            do
            {
                _inputOutput.WriteLine(">> Please, enter Y or N.");
                answer = _inputOutput.ReadLine();

            } while (!(answer.Equals("Y") || answer.Equals("N")));

            if (answer.Equals("Y"))
            {
                return new PassportCheckResult(CheckForDepartureBan(passenger.PassportNumber));
            }

            return new PassportCheckResult(true);
        }

        private bool CheckForDepartureBan(string passportID)
        {
            if (!int.TryParse(passportID[2..], out int numberPassportId))
            {
                _inputOutput.WriteLine("You are not a citizen of the Republic of Belarus," +
                                       " you have made a wrong choice of the way to pass the passport control.");
                return true;
            }

            if (numberPassportId % 2 == 0)
            {
                _inputOutput.WriteLine("Unfortunately, your passport is in the database of travel restrictions.");
                return false;
            }

            return true;
        }

    }

    internal class PassportCheckResult
    {
        public bool IsOkay { get; set; }

        public PassportCheckResult(bool result)
        {
            IsOkay = result;
        }
    }
}
