using AOC2019.Modules.Intcode;
using AOC2019.Modules.Utilities;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._2
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
            program[1] = 12;
            program[2] = 2;
            program.Execute();

            _output.WriteLine($"memory[0]: {program[0]}");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var outcomes = new Dictionary<(int a, int b), int>();
            for (var ia = 0; ia <= 1; ia++)
            {
                for (var ib = 0; ib <= 1; ib++)
                {
                    var program = Program();
                    program[1] = ia;
                    program[2] = ib;
                    program.Execute();

                    outcomes.Add((ia, ib), program[0]);
                }
            }

            // Get the "base" outcome of the program.
            var startOutcome = outcomes[(0, 0)];
            // Determine the changes due to a = 1 and b = 1 w.r.t "base".
            var deltaA = outcomes[(1, 0)] - outcomes[(0, 0)];
            var deltaB = outcomes[(0, 1)] - outcomes[(0, 0)];
            // Notice that increasing b only adds 1 to the outcome.
            Assert.Equal(1, deltaB);
            // Check if our idea is correct.
            Assert.Equal(outcomes[(1, 1)], deltaA + deltaB + startOutcome);

            // Solve for the number in the assignment
            var expectedOutcome = 19690720;

            // First remove the base.
            expectedOutcome -= startOutcome;
            // Then determine the corresponding parameters.
            var a = expectedOutcome / deltaA;
            var b = expectedOutcome - deltaA * a;

            // Determine the requested number.
            var result = 100 * a + b;
            _output.WriteLine($"100 * noun + verb = {result} (a: {a}, b: {b})");
        }
    }
}
