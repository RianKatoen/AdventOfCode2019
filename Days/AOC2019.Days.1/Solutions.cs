using AOC2019.Modules.Fuel.FuelCounters;
using AOC2019.Modules.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._1
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        private int[] Masses() => EmbeddedResources.ReadLines<int>(GetType(), "input.txt");
        private void ShowSolution(int totalFuel) => _output.WriteLine($"Total fuel required: {totalFuel}");

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var masses = Masses();
            var requiredFuelCalculator = new RequiredFuelCalculator();
            var fuelCounterUpper = new FuelCounterUpper(requiredFuelCalculator);

            ShowSolution(fuelCounterUpper.RequiredFuel(masses));
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var masses = Masses();
            var requiredFuelCalculator = new RequiredFuelCalculator();
            var totalRequiredFuelCalculator = new TotalRequiredFuelCalculator(requiredFuelCalculator);
            var fuelCounterUpper = new FuelCounterUpper(totalRequiredFuelCalculator);

            ShowSolution(fuelCounterUpper.RequiredFuel(masses));
        }
    }
}
