using System.Collections.Generic;

namespace AOC2019.Modules.Fuel.FuelCounters
{
    public interface IFuelCounterUpper
    {
        int RequiredFuel(IEnumerable<int> masses);
    }
}
