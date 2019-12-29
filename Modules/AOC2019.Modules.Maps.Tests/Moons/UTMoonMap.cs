using AOC2019.Modules.Maps.Moons;
using AOC2019.Modules.Utilities;
using Xunit;

namespace AOC2019.Modules.Maps.Tests.Moons
{
    public class UTMoonMap
    {
        [Fact(DisplayName = "Test constructor from text (example 1).")]
        public void TestConstructorFromText()
        {
            var map = new MoonMap(EmbeddedResources.ReadLines<string>(GetType(), "example1.txt"));

            Assert.Equal(4, map.Count);
            Assert.Equal((Coord)(2, -10, -7), map[1].Position);
            Assert.Equal((Coord)(0, 0, 0), map[2].Velocity);

            Assert.Equal(EmbeddedResources.Read(GetType(), "Outputs.output0.txt"), map.ToString());
        }

        [Fact(DisplayName = "Test first three steps and energy after ten steps (example 1).")]
        public void TestFirstThreeStepsEnergyAfterTen()
        {
            var map = new MoonMap(EmbeddedResources.ReadLines<string>(GetType(), "example1.txt"));
            Assert.Equal(EmbeddedResources.Read(GetType(), "Outputs.output0.txt"), map.ToString());

            map.Develop();
            Assert.Equal(EmbeddedResources.Read(GetType(), "Outputs.output1.txt"), map.ToString());
            Assert.Equal(1, map.Time);

            map.Develop();
            Assert.Equal(2, map.Time);
            Assert.Equal(EmbeddedResources.Read(GetType(), "Outputs.output2.txt"), map.ToString());

            map.Develop();
            Assert.Equal(3, map.Time);
            Assert.Equal(EmbeddedResources.Read(GetType(), "Outputs.output3.txt"), map.ToString());


            map.Develop(7);
            Assert.Equal(179, map.TotalEnergy);
        }

        [Fact(DisplayName = "Test after 100 steps (example 2).")]
        public void TestAfter100Steps()
        {
            var map = new MoonMap(EmbeddedResources.ReadLines<string>(GetType(), "example2.txt"));
            map.Develop(100);

            Assert.Equal(1940, map.TotalEnergy);
        }
    }
}

