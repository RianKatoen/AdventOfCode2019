using AOC2019.Modules.Intcode.Instructions;
using Xunit;

namespace AOC2019.Modules.Intcode.Tests
{
    public class UTMemoryCell
    {
        [Theory(DisplayName = "VerifyToInstruction")]
        [InlineData(2, 0, 0, 0, 2)]
        [InlineData(99, 0, 0, 0, 99)]
        [InlineData(101, 0, 0, 1, 1)]
        [InlineData(1002, 0, 1, 0, 2)]
        [InlineData(10103, 1, 0, 1, 3)]
        [InlineData(11104, 1, 1, 1, 4)]

        public void VerifyToInstruction(int data, int thirdPar, int secondPar, int firstPar, int opCode)
        {
            var sut = new MemoryCell(data);
            var instruction = sut.ToInstruction();

            Assert.Equal(data, sut.Value);
            
            Assert.Equal((ParameterMode)thirdPar, instruction.ParameterMode3);
            Assert.Equal((ParameterMode)secondPar, instruction.ParameterMode2);
            Assert.Equal((ParameterMode)firstPar, instruction.ParameterMode1);

            Assert.Equal((OpCodes)opCode, instruction.OpCode);
        }
    }
}
