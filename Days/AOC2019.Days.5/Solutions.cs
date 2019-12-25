using AOC2019.Modules.Intcode;
using AOC2019.Modules.Utilities;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._5
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private IntcodeProgram Program() => new IntcodeProgram(EmbeddedResources.Read(GetType(), "input.txt"));


        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var program = Program();
            program.Input = 1;
            program.Execute();

            var ix = 0;
            foreach (var output in program.Output)
            {
                _output.WriteLine($"{ix}: {output}");
                ix++;
            }

            Assert.Equal(16489636, program.Output.Last());
        }
    }
}
