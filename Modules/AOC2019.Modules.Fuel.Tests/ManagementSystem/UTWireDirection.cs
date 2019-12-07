using AOC2019.Modules.Fuel.ManagementSystem;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.ManagementSystem
{
    public class UTWireDirection
    {
        [Theory(DisplayName = "Verify FromChar()")]
        [InlineData('U', WireDirection.Up)]
        [InlineData('R', WireDirection.Right)]
        [InlineData('D', WireDirection.Down)]
        [InlineData('L', WireDirection.Left)]
        public void VerifyFromChar(char d, WireDirection expectedDirection)
        {
            Assert.Equal(expectedDirection, WireDirections.FromChar(d));
        }

        [Theory(DisplayName = "Verify FromChar() throws exception")]
        [InlineData('3')]
        [InlineData('u')]
        [InlineData('r')]
        [InlineData('d')]
        [InlineData('l')]
        [InlineData('\n')]
        public void VerifyFromCharThrowsException(char d)
        {
            Assert.Throws<UnknownWireDirectionException>(() => WireDirections.FromChar(d));
        }

        [Theory(DisplayName = "Verify ToChar()")]
        [InlineData(WireDirection.Up, 'U')]
        [InlineData(WireDirection.Right, 'R')]
        [InlineData(WireDirection.Down, 'D')]
        [InlineData(WireDirection.Left, 'L')]
        public void VerifyToChar(WireDirection wd , char expectedChar)
        {
            Assert.Equal(expectedChar, WireDirections.ToChar(wd));
        }
    }
}
