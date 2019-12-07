using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeProgram : IIntcodeProgram
    {
        private readonly int[] _memory;
        public IntcodeProgram(string memory)
        {
            _memory = memory
                .Split(',')
                .Select(s => int.Parse(s))
                .ToArray();
        }

        public IntcodeProgram(IEnumerable<int> memory)
        {
            _memory = memory.ToArray();
        }

        public IntcodeProgram(int memSize)
        {
            _memory = new int[memSize];
        }

        public int this[int index]
        {
            get => _memory[index];
            set => _memory[index] = value;
        }

        public int MemSize => _memory.Length;

        public int Index { get; set; } = 0;
        public IntcodeStatus Status { get; set; } = IntcodeStatus.Initialising;



        public void Execute()
        {
            Status = IntcodeStatus.Running;

            while (Status != IntcodeStatus.Ended)
            {
                switch (_memory[Index])
                {
                    case (int)OpCodes.Add:
                        _memory[_memory[Index + 3]] = _memory[_memory[Index + 1]] + _memory[_memory[Index + 2]];
                        Index += 4;
                        break;
                    case (int)OpCodes.Multiply:
                        _memory[_memory[Index + 3]] = _memory[_memory[Index + 1]] * _memory[_memory[Index + 2]];
                        Index += 4;
                        break;
                    case (int)OpCodes.End:
                        Status = IntcodeStatus.Ended;
                        break;
                    default:
                        Status = IntcodeStatus.Ended;
                        throw new UnknownOpCodeException();
                }
            }
        }

        public override string ToString() => string.Join(",", _memory);
    }
}
