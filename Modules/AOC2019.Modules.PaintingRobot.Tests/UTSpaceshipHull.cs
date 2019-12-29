using Xunit;

namespace AOC2019.Modules.PaintingRobot.Tests
{
    public class UTSpaceshipHull
    {
        [Fact(DisplayName = "Test default color.")]
        public void TestDefaultColor()
        {
            var sut = new SpaceshipHull();

            Assert.Equal((HullColor.Black, 0), sut[(1000, 100000)]);
            Assert.Equal((HullColor.Black, 0), sut[(-1, 0)]);
        }

        [Fact(DisplayName = "Test if hull is painted.")]
        public void TestIfHullIsPainted()
        {
            var sut = new SpaceshipHull();

            sut.Paint((0, 0), HullColor.White);
            Assert.Equal((HullColor.White, 1), sut[(0, 0)]);


            sut.Paint((-1, 0), HullColor.Black);
            Assert.Equal((HullColor.Black, 1), sut[(-1, 0)]);

            sut.Paint((-1, 0), HullColor.White);
            Assert.Equal((HullColor.White, 2), sut[(-1, 0)]);
        }
    }
}
