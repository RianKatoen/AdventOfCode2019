using AOC2019.Modules.Maps.Asteroids;
using AOC2019.Modules.Utilities;
using Xunit;

namespace AOC2019.Modules.Maps.Tests.Asteroids
{
    public class UTMahLazor
    {
        [Fact(DisplayName = "ImmaFirinMahLazor")]
        public void ImmaFirinMahLazor()
        {
            var lines = EmbeddedResources.ReadLines<string>(GetType(), "Examples.mahlazor.txt");
            var map = new AsteroidMap(lines);
            var sut = new MahLazor();

            var zapped = sut.PewPew(map, (8, 3));
            Assert.Equal(36, zapped.Count);

            Assert.Equal((8, 1), zapped[0]);
            Assert.Equal((9, 0), zapped[1]);
            Assert.Equal((9, 1), zapped[2]);
            Assert.Equal((10, 0), zapped[3]);
            Assert.Equal((9, 2), zapped[4]);
        }


        [Fact(DisplayName = "ShoopDaWhoop")]
        public void ShoopDaWhoop()
        {
            var lines = EmbeddedResources.ReadLines<string>(GetType(), "Examples.example5.txt");
            var map = new AsteroidMap(lines);
            var sut = new MahLazor();

            var zapped = sut.PewPew(map, (11, 13));

            Assert.Equal(299, zapped.Count);

            Assert.Equal((11, 12), zapped[0]);
            Assert.Equal((12, 1), zapped[1]);
            Assert.Equal((12, 2), zapped[2]);
            Assert.Equal((12, 8), zapped[9]);
            Assert.Equal((16, 0), zapped[19]);
            Assert.Equal((16, 9), zapped[49]);
            Assert.Equal((10, 16), zapped[99]);
            Assert.Equal((9, 6), zapped[198]);
            Assert.Equal((8, 2), zapped[199]);
            Assert.Equal((10, 9), zapped[200]);
            Assert.Equal((11, 1), zapped[298]);
        }
    }
}
