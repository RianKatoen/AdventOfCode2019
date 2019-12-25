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
        public IntcodeStatus Status { get; set; } = IntcodeStatus.Initialising;


        public void Execute()
        {
            Status = IntcodeStatus.Running;
            while (Status != IntcodeStatus.Ended)
            {
                var instruction = this[Index].ToInstruction();
                instruction.Index = Index;
                instruction.Memory = this;

                var result = _handler.Handle(instruction);

                Index = result.Index;
                Status = (result.Status < 0 && Index < Count)
                    ? IntcodeStatus.Running
                    : IntcodeStatus.Ended;
            }
        }

        public override string ToString() => string.Join(",", this.Select(m => m.Value));
    }
}
