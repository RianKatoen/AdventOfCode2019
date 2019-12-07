using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests
{
    public class UTFuelCounterUpper
    {
        [Fact(DisplayName = "Verify outcome for empty")]
        public void VerifyOutcomeForEmpty()
        {
            var mockCalculator = new Mock<IRequiredFuelCalculator>();

            var masses = new List<int>();
            var sut = new FuelCounterUpper(mockCalculator.Object);
            var requiredFuel = sut.RequiredFuel(masses);

            Assert.Equal(0, requiredFuel);

            mockCalculator.Verify(c => c.RequiredFuel(It.IsAny<int>()), Times.Never);
        }

        [Fact(DisplayName = "Verify outcome for list")]
        public void VerifyOutcome()
        {
            var mockCalculator = new Mock<IRequiredFuelCalculator>();
            mockCalculator.Setup(c => c.RequiredFuel(It.Is<int>(i => i > 0))).Returns((int i) => 2 * i);

            var masses = Enumerable.Range(1, 100);
            var sut = new FuelCounterUpper(mockCalculator.Object);
            var requiredFuel = sut.RequiredFuel(masses);

            Assert.Equal(2 * masses.Sum(), requiredFuel);

            mockCalculator.Verify(c => c.RequiredFuel(It.Is<int>(i => i > 0)), Times.Exactly(masses.Count()));
            mockCalculator.Verify(c => c.RequiredFuel(It.Is<int>(i => i <= 0)), Times.Never);
        }
    }
}
