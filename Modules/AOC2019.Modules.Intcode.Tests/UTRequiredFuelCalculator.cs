using Xunit;

namespace AOC2019.Modules.Intcode.Tests
{
    public class UTRequiredFuelCalculator
    {
        [Theory(DisplayName = "Verify outcomes")]
        [InlineData(12, "1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
        [InlineData(5, "1,0,0,0,99", "2,0,0,0,99")]
        [InlineData(5, "2,3,0,3,99", "2,3,0,6,99")]
        [InlineData(6, "2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData(9, "1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]

        public void VerifyOutcomes(int memSize, string inputMemory, string expectedMemory)
        {
            var sut = new IntcodeProgram(inputMemory);
            
            Assert.Equal(IntcodeStatus.Initialising, sut.Status);
            Assert.Equal(memSize, sut.MemSize);
            sut.Execute();
            Assert.Equal(IntcodeStatus.Ended, sut.Status);

            Assert.Equal(expectedMemory, sut.ToString());
        }
    }
}
