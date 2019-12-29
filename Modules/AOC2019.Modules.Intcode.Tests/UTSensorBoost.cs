using Xunit;

namespace AOC2019.Modules.Intcode.Tests
{
    public class UTSensorBoost
    {
        [Theory(DisplayName = "Examples (part 1)")]
        [InlineData("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99")]
        [InlineData("1102,34915192,34915192,7,4,7,99,0", "1219070632396864")]
        [InlineData("104,1125899906842624,99", "1125899906842624")]
        public void ExamplesPartOne(string inputMemory, string output)
        {
            var sut = new IntcodeProgram(inputMemory);
            sut.Execute();

            Assert.Equal(output, sut.Output.ToString());
        }

        [Theory(DisplayName = "Own tests (part 1)")]
        [InlineData(new long[] { 99 }, 1, "203,1,0", "203,1,99")]
        [InlineData(new long[] { }, 2, "21102,2,3,1,99", "21102,2,3,6,99")]
        public void OwnTestsPartOne(long[] input, int relativeBase, string inputMemory, string output)
        {
            var sut = new IntcodeProgram(inputMemory);
            sut.RelativeBase = relativeBase;
            sut.Input.AddRange(input);
            sut.Execute();

            Assert.Equal(output, sut.ToString());
        }
    }
}
