using AOC2019.Modules.Intcode;
using AOC2019.Modules.PaintingRobot;
using AOC2019.Modules.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._11
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private string Memory() => EmbeddedResources.Read(GetType(), "input.txt");

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var program = new IntcodeProgram(Memory());
            var hull = new SpaceshipHull();
            var robot = new HullPaintingRobot(hull);
            var controlUnit = new ControlUnit(program, robot);

            controlUnit.Execute();

            var noVisits = 0;
            foreach (var tile in hull)
            {
                noVisits += (tile.noVisits >= 1 ? 1 : 0);
            }

            _output.WriteLine($"No. of tile visits: {noVisits}.");
            _output.WriteLine(hull.ToString());

            Assert.Equal(2392, noVisits);
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var program = new IntcodeProgram(Memory());
            var hull = new SpaceshipHull();
            hull.Paint((0, 0), HullColor.White);
            var robot = new HullPaintingRobot(hull);
            var controlUnit = new ControlUnit(program, robot);

            controlUnit.Execute();

            var noVisits = 0;
            foreach (var tile in hull)
            {
                noVisits += (tile.noVisits >= 1 ? 1 : 0);
            }

            _output.WriteLine($"No. of tile visits: {noVisits}.");
            _output.WriteLine(hull.ToString());
        }
    }
}
