using AOC2019.Modules.Fuel.Counters;
using Moq;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.Counters
{
    public class UTTotalRequiredFuelCalculator
    {
        [Theory(DisplayName = "Verify outcomes")]
        [InlineData(0, 0, 0, 2)]
        [InlineData(1, 0, 1, 1)]
        [InlineData(10, 1, 2, 0)]
        [InlineData(11, 1, 2, 0)]
        [InlineData(100, 11, 3, 0)]
        public void VerifyOutcomes(int mass, int expectedFuel, int expectedGreaterThan0, int expectedEqual0)
        {
            var mockCalculator = new Mock<IRequiredFuelCalculator>();
            mockCalculator.Setup(c => c.RequiredFuel(It.Is<int>(i => i > 0))).Returns((int i) => i / 10);
            mockCalculator.Setup(c => c.RequiredFuel(It.Is<int>(i => i <= 0))).Returns(0);

            var sut = new TotalRequiredFuelCalculator(mockCalculator.Object);
            var requiredFuel = sut.RequiredFuel(mass);


            Assert.Equal(expectedFuel, requiredFuel);

            mockCalculator.Verify(c => c.RequiredFuel(It.Is<int>(i => i > 0)), Times.Exactly(expectedGreaterThan0));
            mockCalculator.Verify(c => c.RequiredFuel(It.Is<int>(i => i == 0)), Times.Exactly(expectedEqual0));
            mockCalculator.Verify(c => c.RequiredFuel(It.Is<int>(i => i < 0)), Times.Never);
        }
    }
}
