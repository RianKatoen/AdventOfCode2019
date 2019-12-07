using System;

namespace AOC2019.Modules.Fuel.FuelCounters
{
    /// <summary>
    /// This calculator calculates the amount of fuel necessary for a given amount of mass.
    /// It <b>DOES NOT</b> include the amount of fuel to carry the fuel itself.
    /// </summary>
    public class RequiredFuelCalculator : IRequiredFuelCalculator
    {
        public int RequiredFuel(int mass) => Math.Max(0, mass / 3 - 2);
    }
}
