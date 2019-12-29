using AOC2019.Modules.Maps.Moons;
using AOC2019.Modules.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._12
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var map = new MoonMap(EmbeddedResources.ReadLines<string>(GetType(), "input.txt"));
            map.Develop(1000);

            _output.WriteLine($"Total energy in system: {map.TotalEnergy}");

            Assert.Equal(9441, map.TotalEnergy);
        }
    }
}
