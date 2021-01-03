using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIn.AirportDepartment
{
    class SecurityCheckDesk
    {
        private readonly IInputOutput _inputOutput;

        public SecurityCheckDesk(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }

        public SecurityCheckResult CheckPassenger(Passenger passenger)
        {
            foreach (var item in passenger.PesonalBelongings)
            {
                if (_restrictedItems.Contains(item))
                {

                }
            }
        }
    }

    internal class SecurityCheckResult
    {
        public bool IsOkay { get; set; }

        public List<string> ForbiddenItems { get; set; }
    }
}
