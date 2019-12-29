using AOC2019.Modules.Intcode.Instructions;

namespace AOC2019.Modules.Intcode
{
    public class MemoryCell
    {
        public MemoryCell(long value)
        {
            Value = value;
        }

        public long Value { get; set; }

        public OpInstructionCommand ToInstruction()
        {
            return new OpInstructionCommand
            {
                ParameterMode3 = (ParameterMode)(Value / 10000),
                ParameterMode2 = (ParameterMode)((Value % 10000) / 1000),
                ParameterMode1 = (ParameterMode)((Value % 1000) / 100),

                OpCode = (OpCodes)(Value % 100)
            };
        }

        public static implicit operator MemoryCell(long value) => new MemoryCell(value);
        public static implicit operator long(MemoryCell cell) => cell.Value;
        public static implicit operator MemoryCell(int value) => new MemoryCell(value);
        public static implicit operator int(MemoryCell cell) => (int)cell.Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
