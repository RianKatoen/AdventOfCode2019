using System.Collections.Generic;

namespace AOC2019.Modules.Fuel
{
    public interface IFuelCounterUpper
    {
        int RequiredFuel(IEnumerable<int> masses);
    }
}
