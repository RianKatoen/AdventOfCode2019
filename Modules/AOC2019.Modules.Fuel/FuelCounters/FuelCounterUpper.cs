using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Fuel.FuelCounters
{
    public class FuelCounterUpper : IFuelCounterUpper
    {
        private readonly IRequiredFuelCalculator _requiredFuelCalculator;
        public FuelCounterUpper(IRequiredFuelCalculator requiredFuelCalculator)
        {
            _requiredFuelCalculator = requiredFuelCalculator;
        }

        public int RequiredFuel(IEnumerable<int> masses)
        {
            return masses
                .Select(m => _requiredFuelCalculator.RequiredFuel(m))
                .Sum();
        }
    }
}
