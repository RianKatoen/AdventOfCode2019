namespace AOC2019.Modules.Intcode.Instructions
{
    public class OpInstructionHandler
    {
        public int GetParameter(OpInstructionCommand instruction, int parNo)
        {
            ParameterMode? parMode = null;
            switch (parNo)
            {
                case 1: parMode = instruction.ParameterMode1; break;
                case 2: parMode = instruction.ParameterMode2; break;
                case 3: parMode = instruction.ParameterMode3; break;
            }

            var value = instruction.Memory[instruction.Index + parNo];
            switch (parMode)
            {
                case ParameterMode.Immediate: return value;
                case ParameterMode.Position: return instruction.Memory[value];
            }

            throw new UnknownOpCodeException();
        }

        public OpInstructionResult Handle(OpInstructionCommand instruction)
        {
            var ix = instruction.Index;
            var mem = instruction.Memory;

            switch (instruction.OpCode)
            {
                case OpCodes.Add:
                    mem[mem[ix + 3]] = GetParameter(instruction, 1) + GetParameter(instruction, 2);
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = -1
                    };
                case OpCodes.Multiply:
                    mem[mem[ix + 3]] = GetParameter(instruction, 1) * GetParameter(instruction, 2);
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = -1
                    };
                case OpCodes.End:
                    return new OpInstructionResult
                    {
                        Status = 0
                    };
                default:
                    throw new UnknownOpCodeException();
            }
        }
    }
}
