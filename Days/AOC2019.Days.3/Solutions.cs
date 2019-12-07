using AOC2019.Modules.Fuel.ManagementSystem;
using AOC2019.Modules.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._3
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private IEnumerable<Wire> Wires(string file) => EmbeddedResources.ReadLines<string>(GetType(), file).Select(l => new Wire(l));
        private WireGrid WireGrid(string file)
        {
            var wires = Wires(file);
            var grid = new WireGrid();

            foreach (var wire in wires)
            {
                grid.Draw(wire);
            }

            return grid;
        }


        [Theory(DisplayName = "Part One")]
        [InlineData("example1.txt")]
        [InlineData("example2.txt")]
        [InlineData("input.txt")]
        public void PartOne(string file)
        {
            var grid = WireGrid(file);

            var intersections = grid.Intersections();
            var smallestDistance = intersections
                .Where(i => i != (0, 0))
                .Select(i => Math.Abs(i.x) + Math.Abs(i.y))
                .Min();

            _output.WriteLine($"Smallest Manhattan distance: {smallestDistance}");
        }

        [Theory(DisplayName = "Part One")]
        [InlineData("example1.txt")]
        [InlineData("example2.txt")]
        [InlineData("input.txt")]
        public void PartTwo(string file)
        {
            var grid = WireGrid(file);
            var minSteps = grid
                .Steps()
                .Where(s => s.x != 0 && s.y != 0)
                .Select(s => s.steps)
                .Min();

            _output.WriteLine($"Smallest number of combined steps: {minSteps}");
        }
    }
}
