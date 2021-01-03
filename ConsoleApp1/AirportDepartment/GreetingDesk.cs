using CheckIn.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn.AirportDepartment
{
    class GreetingDesk
    {
        private readonly IInputOutput _inputOutput;

        public GreetingDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public string Greet()
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

            _inputOutput.WriteLine($"{timeOfDay} Welcome to Minsk Airport. Please introduce yourself.");

            return _inputOutput.ReadLine();
        }

        public bool CheckERegistration()
        {
            _inputOutput.WriteLine("Do you have E-Registraition?");
            string answer;
            do
            {
                _inputOutput.WriteLine("Please, enter Y or N.");
                answer = _inputOutput.ReadLine();

            } while (!(answer.Equals("Y") || answer.Equals("N")));

            return answer.Equals("Y");
        }
    }
}


