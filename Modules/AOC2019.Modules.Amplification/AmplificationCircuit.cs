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
        public long Signal { get; private set; } = 0;
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

        public void Execute(int inputSignal = 0)
        {
            // Initialize amplifier programs.
            var programs = new List<IntcodeProgram>(NoAmplifiers);
            for (var i = 0; i < NoAmplifiers; i++)
            {
                var program = new IntcodeProgram(_memory)
                {
                    Input = new IntcodeInput(new long[] { PhaseSettings[i] })
                };

                // Only first amplifier should retrieve direct input signal.
                if (i == 0)
                {
                    program.Input.Add(inputSignal);
                }

                programs.Add(program);
            }

            // Inputs
            var inputs = new IntcodeInput(new long[] { inputSignal });
            var cycleNo = 1;
            while (programs.Any(p => p.Status != IntcodeStatus.Ended))
            {
                // Handle amplifier code.
                for (var i = 0; i < programs.Count; i++)
                {
                    var program = programs[i];
                    var previousNoOutput = program.Output.Count();

                    program.Execute();
                    if (previousNoOutput != program.Output.Count())
                    {
                        var nextProgram = programs[(i + 1) % programs.Count];
                        nextProgram.Input.Add(program.Output.Last());
                    }
                }

                cycleNo++;
            }

            Signal = programs.Last().Output.LastOrDefault();
        }
    }
}
