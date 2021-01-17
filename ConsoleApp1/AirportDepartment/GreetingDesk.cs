using CheckIn.Services;
using System;

namespace CheckIn.AirportDepartment
{
    internal class GreetingDesk
    {
        private readonly IInputOutput _inputOutput;

        public GreetingDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public void Greet()
        {
            int timeNow = DateTime.Now.TimeOfDay.Hours;

            string timeOfDay;

            if (timeNow > 5 && timeNow < 12)
            {
                timeOfDay = "Good morning!";
            }
            else if (timeNow > 12 && timeNow < 15)
            {
                timeOfDay = "Good day!";
            }
            else if (timeNow > 15 && timeNow < 22)
            {
                timeOfDay = "Good evening!";
            }
            else
            {
                timeOfDay = "Good night!";
            }

            _inputOutput.WriteLine($">> {timeOfDay} Welcome to Minsk Airport.");
        }

        public string GetFullName()
        {
            _inputOutput.WriteLine(">> Please introduce yourself.");
            return _inputOutput.ReadLine();
        }

        public string GetPassportId()
        {
            _inputOutput.WriteLine(">> Please enter your passportId.");
            return _inputOutput.ReadLine();
        }

        public bool CheckERegistration()
        {
            _inputOutput.WriteLine(">> Do you have E-Registration?");

            return AskYesOrNo();
        }

        public bool CheckBaggage()
        {
            _inputOutput.WriteLine(">> Do you have any baggage for registration?");

            return AskYesOrNo();
        }

        public bool AskYesOrNo()
        {
            string answer;
            do
            {
                _inputOutput.WriteLine(">> Please, enter Y or N.");
                answer = _inputOutput.ReadLine();

            } while (!(answer.Equals("Y") || answer.Equals("N")));

            return answer.Equals("Y");
        }

        public void StopRegistration()
        {
            _inputOutput.WriteLine(">> To our regret, you cannot proceed with the check-in for the flight.");
        }
    }
}


