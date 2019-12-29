using AOC2019.Modules.Intcode.Instructions;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeProgram : List<MemoryCell>
    {
        private readonly OpInstructionHandler _handler = new OpInstructionHandler();
        public IntcodeProgram(string memory)
        {
            AddRange(memory
                .Split(',')
                .Select(s => new MemoryCell(int.Parse(s))));
        }

        public IntcodeProgram(IEnumerable<int> memory)
        {
            AddRange(memory.Select(i => new MemoryCell(i)));
        }

        public IntcodeProgram(int memSize)
        {
            this.Capacity = memSize;
        }

        public int MemSize => Count;

        public int Index { get; set; } = 0;
        public IntcodeInput Input { get; set; } = new IntcodeInput(new int[] { });
        public IntcodeOutput Output { get; set; } = new IntcodeOutput(new int[] { });

        public IntcodeStatus Status { get; set; } = IntcodeStatus.Initialising;

        public void Execute(int? noCycles = null)
        {
            Status = IntcodeStatus.Running;
            var cycle = 0;
            while (Status == IntcodeStatus.Running && (!noCycles.HasValue || cycle < noCycles))
            {
                // Create instruction.
                var instruction = this[Index].ToInstruction();

                instruction.Index = Index;
                instruction.Input = Input;
                instruction.Memory = this;

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

        public override string ToString() => string.Join(",", this.Select(m => m.Value));
    }
}
