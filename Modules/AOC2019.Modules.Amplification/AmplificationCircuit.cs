using AOC2019.Modules.Intcode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Amplification
{
    public class AmplificationCircuit
    {
        private readonly List<int> _memory;

        public int NoAmplifiers { get; private set; } = 5;
        public int Signal { get; private set; } = 0;
        public IReadOnlyList<int> PhaseSettings { get; private set; }

        public AmplificationCircuit(string memory, int noAmplifiers = 5)
            : this(memory.Split(',').Select(i => int.Parse(i)), noAmplifiers)
        {
        }

        public AmplificationCircuit(IEnumerable<int> memory, int noAmplifiers = 5)
        {
            _memory = memory.ToList();
            NoAmplifiers = noAmplifiers;
        }

        public void SetPhaseSettings(string settings)
        {
            SetPhaseSettings(settings.Split(',').Select(i => int.Parse(i)));
        }

        public void SetPhaseSettings(IEnumerable<int> settings)
        {
            if (settings.Count() == NoAmplifiers)
            {
                PhaseSettings = settings.ToList();
            }
            else
            {
                throw new ArgumentException($"Number of phase settings ({settings.Count()}) does not equal number of amplifiers ({NoAmplifiers}).");
            }
        }

        public void Execute(int inputSignal = 0, bool feedbackMode = false)
        {
            // Initialize amplifier programs.
            var programs = new List<IntcodeProgram>(NoAmplifiers);
            for (var i = 0; i < NoAmplifiers; i++)
            {
                programs.Add(new IntcodeProgram(_memory));
            }

            // Handle amplifier code.
            for (var i = 0; i < NoAmplifiers; i++)
            {
                var program = programs[i];
                // First cycle.
                program.Input = PhaseSettings[i];
                program.Execute(1);
                // Rest of code.
                program.Input = inputSignal;
                program.Execute();
                // Retrieve inputSignal.
                inputSignal = program.Output[0];
            }

            if (feedbackMode)
            {
                for (var k = 1; k <= 10; k++)
                {
                    // Handle amplifier code.
                    for (var i = 0; i < NoAmplifiers; i++)
                    {
                        var program = programs[i];
                        // First cycle.
                        program.Input = PhaseSettings[i];
                        program.Execute(1);
                        // Rest of code.
                        program.Input = inputSignal;
                        program.Execute();
                        // Retrieve inputSignal.
                        inputSignal = program.Output[0];
                    }
                }
            }

            Signal = inputSignal;
        }
    }
}
