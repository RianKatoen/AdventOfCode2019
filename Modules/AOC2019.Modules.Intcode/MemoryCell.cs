using AOC2019.Modules.Intcode.Instructions;

namespace AOC2019.Modules.Intcode
{
    public class MemoryCell
    {
        public MemoryCell(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public OpInstructionCommand ToInstruction()
        {
            return new OpInstructionCommand
            {
                ParameterMode3 = (ParameterMode)((Value / 10000) >= 1 ? 1 : 0),
                ParameterMode2 = (ParameterMode)((Value % 10000) / 1000 >= 1 ? 1 : 0),
                ParameterMode1 = (ParameterMode)((Value % 1000) / 100 >= 1 ? 1 : 0),

                OpCode = (OpCodes)(Value % 100)
            };
        }

        public static implicit operator MemoryCell(int value) => new MemoryCell(value);
        public static implicit operator int(MemoryCell cell) => cell.Value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
