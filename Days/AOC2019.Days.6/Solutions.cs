using AOC2019.Modules.OrbitalMap;
using AOC2019.Modules.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._6
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
            var data = EmbeddedResources.ReadLines<string>(GetType(), "input1.txt");
            var map = new UniversalOrbitalMap(data);

            var noOfOrbits = map.NumberOfOrbits();
            _output.WriteLine($"The number of direct and indirect orbits equals: {noOfOrbits}");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var data = EmbeddedResources.ReadLines<string>(GetType(), "input2.txt");
            var map = new UniversalOrbitalMap(data);

            var noOfOrbitalTransfers = map.OrbitalTransfers("YOU", "SAN");
            _output.WriteLine($"The number of transfers to Santa equals: {noOfOrbitalTransfers}");
        }
    }
}
