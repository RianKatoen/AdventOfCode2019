using AOC2019.Modules.Fuel.Counters;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.Counters
{
    public class UTRequiredFuelCalculator
    {
        [Theory(DisplayName = "Verify outcomes")]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        [InlineData(0, 0)]
        public void VerifyOutcomes(int mass, int expectedFuel)
        {
            var sut = new RequiredFuelCalculator();
            var requiredFuel = sut.RequiredFuel(mass);
            Assert.Equal(expectedFuel, requiredFuel);
        }
    }
}
