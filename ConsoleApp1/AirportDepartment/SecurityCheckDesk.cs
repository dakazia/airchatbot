using System;
using System.Collections.Generic;
using System.Linq;
using CheckIn.Services;

namespace CheckIn.AirportDepartment
{
    internal class SecurityCheckDesk
    {
        private readonly IInputOutput _inputOutput;

        private static readonly string[] ForbiddenItems = new string[]
            {"sword", "dagger", "saber", "knife", "scissors", "weapon"};

        public SecurityCheckDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public SecurityCheckResult CheckPassenger(Passenger passenger)
        {
            List<string> itemsToBeExcluded = new List<string>();

            foreach (var item in passenger.PersonalBelongings.Where(item => ForbiddenItems.Contains(item)))
            {
                itemsToBeExcluded.Add(item);
            }

            if (itemsToBeExcluded.Count == 0)
            {
                _inputOutput.WriteLine(">> It's okay, now you've gone through Passport control");
                return new SecurityCheckResult(true);
            }
            else
            {
                _inputOutput.WriteLine(
                    ">> This items is not allowed on board the aircraft. You need to leave it for control. Here is:");

                foreach (var item in itemsToBeExcluded)
                {
                    _inputOutput.WriteLine(item);
                }

                _inputOutput.WriteLine(">> Are you agree to exclude it?");

                string answer;
                do
                {
                    _inputOutput.WriteLine(">> Please, enter Y or N.");
                    answer = _inputOutput.ReadLine();

                } while (!(answer.Equals("Y") || answer.Equals("N")));

                if (answer.Equals("Y"))
                {
                    foreach (var item in itemsToBeExcluded)
                    {
                        passenger.PersonalBelongings.Remove(item);
                    }

                    _inputOutput.WriteLine(">> It's okay, now you've gone through Passport control");
                    return new SecurityCheckResult(true);
                }
                else
                {
                    _inputOutput.WriteLine(
                        ">> Unfortunately, you cannot bring these items on board. You need to leave the departure area.");
                    return new SecurityCheckResult(false);
                }
            }
        }

        internal class SecurityCheckResult
        {
            public bool IsOkay { get; set; }

            public SecurityCheckResult(bool result)
            {
                IsOkay = result;
            }
        }
    }
}

