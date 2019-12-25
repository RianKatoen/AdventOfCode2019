﻿using System.Linq;
using Xunit;

namespace AOC2019.Modules.Intcode.Tests
{
    public class UTThermalEnvironmentSupervisionTerminal
    {
        [Theory(DisplayName = "Verify outcomes (part 1)")]
        [InlineData("3,0,4,0,99", 1, 1)]
        [InlineData("3,0,4,0,99", 2, 2)]

        public void VerifyOutcomesPartOne(string inputMemory, int input, int output)
        {
            var sut = new IntcodeProgram(inputMemory);
            sut.Input = input;

            Assert.Equal(IntcodeStatus.Initialising, sut.Status);
            sut.Execute();
            Assert.Equal(IntcodeStatus.Ended, sut.Status);

            Assert.Equal(output, sut.Output.First());
        }

        [Theory(DisplayName = "Verify outcomes (part 2)")]
        // Check if input equals 8.
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 4, 0)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 8, 1)]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 9, 0)]
        // Check if input less than 8.
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 7, 1)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 8, 0)]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 9, 0)]
        // Check if input equals 8.
        [InlineData("3,3,1108,-1,8,3,4,3,99", 4, 0)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 8, 1)]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 9, 0)]
        // Check if input less than 8.
        [InlineData("3,3,1107,-1,8,3,4,3,99", 7, 1)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 8, 0)]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 9, 0)]
        // Check if equal to 0
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", -1, 1)]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, 0)]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 1, 1)]
        // Check if equal to 0
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", -1, 1)]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, 0)]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 1, 1)]
        // Check if 8
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 0, 999)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 8, 1000)]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 31, 1001)]
        public void VerifyOutcomesPartTwo(string inputMemory, int input, int output)
        {
            var sut = new IntcodeProgram(inputMemory);
            sut.Input = input;

            Assert.Equal(IntcodeStatus.Initialising, sut.Status);
            sut.Execute();
            Assert.Equal(IntcodeStatus.Ended, sut.Status);

            Assert.Equal(output, sut.Output.First());
        }
    }
}