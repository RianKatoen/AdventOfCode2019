using AOC2019.Modules.Maps.Moons;
using Xunit;

namespace AOC2019.Modules.Maps.Tests.Moons
{
    public class UTCoord
    {
        [Theory(DisplayName = "Test constructor from text.")]
        [InlineData("<x=-1, y=0, z=2>", -1, 0, 2)]
        [InlineData("<x=2, y=-10, z=-7>", 2, -10, -7)]
        [InlineData("<x=4, y=-8, z=8>", 4, -8, 8)]
        [InlineData("<x=3, y=5, z=-1>", 3, 5, -1)]
        public void TestConstructorFromText(string input, int x, int y, int z)
        {
            var coord = new Coord(input);
            Assert.Equal(x, coord.X);
            Assert.Equal(y, coord.Y);
            Assert.Equal(z, coord.Z);
        }
    }
}

