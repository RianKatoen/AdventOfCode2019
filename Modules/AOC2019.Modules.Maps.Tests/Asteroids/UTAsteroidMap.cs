using AOC2019.Modules.Maps.Asteroids;
using AOC2019.Modules.Utilities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2019.Modules.Maps.Tests.Asteroids
{
    public class UTAsteroidMap
    {
        [Fact(DisplayName = "Reader")]
        public void ExampleOneRead()
        {
            var lines = EmbeddedResources.ReadLines<string>(GetType(), "Examples.example1.txt");
            var sut = new AsteroidMap(lines);

            Assert.False(sut.Astroid((0, 0)));
            Assert.True(sut.Astroid((1, 0)));
            Assert.True(sut.Astroid((3, 4)));
            Assert.False(sut.Astroid((0, 4)));

            Assert.Equal((5, 5), sut.Size);
        }

        [Theory(DisplayName = "Examples")]
        [InlineData("Examples.example1.txt", 3, 4, 8)]
        [InlineData("Examples.example2.txt", 5, 8, 33)]
        [InlineData("Examples.example3.txt", 1, 2, 35)]
        [InlineData("Examples.example4.txt", 6, 3, 41)]
        [InlineData("Examples.example5.txt", 11, 13, 210)]
        public void Examples(string file, int x, int y, int noAsteroids)
        {
            var lines = EmbeddedResources.ReadLines<string>(GetType(), file);
            var sut = new AsteroidMap(lines);

            Assert.Equal(noAsteroids, sut.VisibleAsteroids((x, y)));

            var visibleAsteroids = new Dictionary<(int x, int y), int>();
            foreach (var asteroid in sut)
            {
                visibleAsteroids[asteroid] = sut.VisibleAsteroids(asteroid);
            }

            var maxVisibleAsteroids = visibleAsteroids.Values.Max();
            var bestAsteroid = Assert.Single(visibleAsteroids
                .Where(va => va.Value == maxVisibleAsteroids)
                .Select(va => va.Key));

            Assert.Equal((x, y), bestAsteroid);
        }
    }
}
