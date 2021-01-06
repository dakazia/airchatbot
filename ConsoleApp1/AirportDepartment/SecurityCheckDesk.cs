using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CheckIn.Services;

namespace CheckIn.AirportDepartment
{
    internal class SecurityCheckDesk
    {
        private readonly IInputOutput _inputOutput;

        public string[] ForbiddenItems { get; } = new string[]
            {"sword", "dagger", "saber", "knife", "scissors", "weapon"};

        public List<string> ItemsToBeExcluded { get; set; } = new List<string>();

        public SecurityCheckDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public List<string> CheckPassenger(Passenger passenger)
        {
            foreach (var item in passenger.PersonalBelongings)
            {
                if (ForbiddenItems.Contains(item))
                {
                    ItemsToBeExcluded.Add(item);
                }
            }

            return ItemsToBeExcluded;
        }

        public SecurityCheckResult ExcludedForbiddenItems(Passenger passenger)
        {
            bool result;

            if (ItemsToBeExcluded is null)
            {
                throw new ArgumentNullException(nameof(ItemsToBeExcluded));
            }

            if (ItemsToBeExcluded.Count == 0)
            {
                _inputOutput.WriteLine(">> It's okay, now you've gone through Passport control");
                result = true;
            }
            else
            {
                _inputOutput.WriteLine(
                    ">> This items is not allowed on board the aircraft. You need to leave it for control. Here is:");

                foreach (var item in ItemsToBeExcluded)
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
                    foreach (var item in ItemsToBeExcluded)
                    {
                        passenger.PersonalBelongings.Remove(item);
                    }

                    _inputOutput.WriteLine(">> It's okay, now you've gone through Passport control");
                    result = true;
                }
                else
                {
                    _inputOutput.WriteLine(
                        ">> Unfortunately, you cannot bring these items on board. You need to leave the departure area.");
                    result = false;
                }
            }

            return new SecurityCheckResult(result);
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

