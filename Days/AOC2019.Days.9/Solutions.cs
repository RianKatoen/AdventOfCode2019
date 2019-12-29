using AOC2019.Modules.Intcode;
using AOC2019.Modules.Utilities;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._9
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private string Memory() => EmbeddedResources.Read(GetType(), "input.txt");

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var program = new IntcodeProgram(Memory());
            program.Input.Add(1);
            program.Execute();

            var output = Assert.Single(program.Output);
            _output.WriteLine($"BOOST Output: {output}");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var program = new IntcodeProgram(Memory());
            program.Input.Add(2);
            program.Execute();

            var output = Assert.Single(program.Output);
            _output.WriteLine($"BOOST Output: {output}");
        }
    }
}
