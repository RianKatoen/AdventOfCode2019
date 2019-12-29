using AOC2019.Modules.AstroidMaps;
using AOC2019.Modules.Utilities;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._10
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private IEnumerable<string> Map() => EmbeddedResources.ReadLines<string>(GetType(), "input.txt");

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var map = new AstroidMap(Map());

            var visibleAsteroids = new Dictionary<(int x, int y), int>();
            foreach (var asteroid in map)
            {
                visibleAsteroids[asteroid] = map.VisibleAsteroids(asteroid);
            }

            var maxVisibleAsteroids = visibleAsteroids.Values.Max();
            var bestAsteroid = Assert.Single(visibleAsteroids
                .Where(va => va.Value == maxVisibleAsteroids)
                .Select(va => va.Key));

            _output.WriteLine($"Best asteroid: ({bestAsteroid.x}, {bestAsteroid.y}) with {maxVisibleAsteroids} visible asteroids.");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var map = new AstroidMap(Map());
            var lazor = new MahLazor();

            var zapped = lazor.PewPew(map, (27, 19));

            var asteroid = zapped[199];
            _output.WriteLine($"200th asteroid: ({asteroid.x}, {asteroid.y}).");
            _output.WriteLine($"Answer: {100 * asteroid.x + asteroid.y}.");
        }
    }
}
