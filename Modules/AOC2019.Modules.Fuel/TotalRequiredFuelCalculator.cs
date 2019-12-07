using System;

namespace AOC2019.Modules.Fuel
{
    /// <summary>
    /// This calculator calculates the amount of fuel necessary for a given amount of mass <b>INCLUDING</b> the fuel needed for carrying the fuel.
    /// </summary>
    public class TotalRequiredFuelCalculator : IRequiredFuelCalculator
    {
        private readonly IRequiredFuelCalculator _requiredFuelCalculator;
        public TotalRequiredFuelCalculator(IRequiredFuelCalculator requiredFuelCalculator)
        {
            _requiredFuelCalculator = requiredFuelCalculator;
        }

        public int RequiredFuel(int mass)
        {
            var requiredFuel = _requiredFuelCalculator.RequiredFuel(mass);
            var deltaRequiredFuel = _requiredFuelCalculator.RequiredFuel(requiredFuel);
            
            while(deltaRequiredFuel > 0)
            {
                requiredFuel += deltaRequiredFuel;
                deltaRequiredFuel = _requiredFuelCalculator.RequiredFuel(deltaRequiredFuel);
            }

            return requiredFuel;
        }
    }
}
