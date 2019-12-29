using AOC2019.Modules.Intcode.Instructions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeProgram : IEnumerable<MemoryCell>, IIntcodeProgram
    {
        private readonly Dictionary<int, MemoryCell> _values = new Dictionary<int, MemoryCell>();
        private readonly OpInstructionHandler _handler = new OpInstructionHandler();

        public IntcodeProgram(string memory)
        {
            var vals = memory
                .Split(',')
                .Select(s => new MemoryCell(long.Parse(s)))
                .ToList();

            for (var i = 0; i < vals.Count; i++)
            {
                _values[i] = vals[i];
            }
        }

        public IntcodeProgram(IEnumerable<int> memory)
        {
            var vals = memory.ToList();
            for (var i = 0; i < vals.Count; i++)
            {
                _values[i] = vals[i];
            }
        }

        public IntcodeProgram(int memSize)
        {
            for (var i = 0; i < memSize; i++)
            {
                _values[i] = 0;
            }
        }

        public MemoryCell this[int index]
        {
            get
            {
                if (_values.TryGetValue(index, out var cell))
                {
                    return cell;
                }
                else
                {
                    return new MemoryCell(0);
                }
            }

            set
            {
                _values[index] = value;
            }
        }

        public int MemSize => _values.Keys.Max() + 1;

        public int Index { get; set; } = 0;
        public int RelativeBase { get; set; } = 0;
        public IntcodeInput Input { get; set; } = new IntcodeInput(new long[] { });
        public IntcodeOutput Output { get; set; } = new IntcodeOutput(new long[] { });

        public IntcodeStatus Status { get; set; } = IntcodeStatus.Initialising;

        public void Execute(int? noCycles = null)
        {
            Status = IntcodeStatus.Running;
            var cycle = 0;
            while (Status == IntcodeStatus.Running && (!noCycles.HasValue || cycle < noCycles))
            {
                // Create instruction.
                var instruction = this[Index].ToInstruction();
                instruction.Program = this;

                var result = _handler.Handle(instruction);

                Index = result.Index;
                if (result.Output != null)
                {
                    Output.Add(result.Output.Value);
                }

                Status = result.Status;

                cycle++;
            }
        }

        public IEnumerator<MemoryCell> GetEnumerator() => _values.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _values.Values.GetEnumerator();

        public override string ToString() => string.Join(",", _values.Values.Select(mc => mc.ToString()));
    }
}
