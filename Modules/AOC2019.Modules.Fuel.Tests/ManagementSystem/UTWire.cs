using AOC2019.Modules.Fuel.ManagementSystem;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.ManagementSystem
{
    public class UTWire
    {
        [Fact(DisplayName = "Verify functionality")]
        public void VerifyFunctionality()
        {
            var path = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            var sut = new Wire(path);

            Assert.Equal(WireDirection.Right, sut[0].Direction);
            Assert.Equal(75, sut[0].Length);

            Assert.Equal(WireDirection.Up, sut[3].Direction);
            Assert.Equal(83, sut[3].Length);

            Assert.Equal(path, sut.ToString());
        }
    }
}
