namespace AOC2019.Modules.Intcode.Instructions
{
    public class OpInstructionHandler
    {
        public long GetParameter(OpInstructionCommand instruction, int parNo)
        {
            IntcodeProgram program = instruction.Program;
            ParameterMode? parMode = null;
            switch (parNo)
            {
                case 1: parMode = instruction.ParameterMode1; break;
                case 2: parMode = instruction.ParameterMode2; break;
                case 3: parMode = instruction.ParameterMode3; break;
            }

            var value = program[program.Index + parNo];
            switch (parMode)
            {
                case ParameterMode.Position: return program[value];
                case ParameterMode.Immediate: return value;
                case ParameterMode.Relative: return program[program.RelativeBase + value];
            }

            throw new UnknownOpCodeException();
        }

        public OpInstructionResult Handle(OpInstructionCommand instruction)
        {
            var program = instruction.Program;
            var ix = instruction.Program.Index;


            switch (instruction.OpCode)
            {
                case OpCodes.Add:
                    program[program[ix + 3]] = GetParameter(instruction, 1) + GetParameter(instruction, 2);
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.Multiply:
                    program[program[ix + 3]] = GetParameter(instruction, 1) * GetParameter(instruction, 2);
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.CopyTo:
                    var input = program.Input.Get();
                    if (input.HasValue)
                    {
                        program[program[ix + 1]] = input.Value;
                        return new OpInstructionResult
                        {
                            Index = ix + 2,
                            Status = IntcodeStatus.Running
                        };
                    }
                    else
                    {
                        return new OpInstructionResult
                        {
                            Index = ix,
                            Status = IntcodeStatus.Waiting
                        };
                    }
                case OpCodes.Output:
                    return new OpInstructionResult
                    {
                        Index = ix + 2,
                        Output = GetParameter(instruction, 1),
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.JumpIfTrue:
                    return new OpInstructionResult
                    {
                        Index = (int)(GetParameter(instruction, 1) != 0 ? GetParameter(instruction, 2) : ix + 3),
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.JumpIfFalse:
                    return new OpInstructionResult
                    {
                        Index = (int)(GetParameter(instruction, 1) == 0 ? GetParameter(instruction, 2) : ix + 3),
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.LessThan:
                    program[program[ix + 3]] = GetParameter(instruction, 1) < GetParameter(instruction, 2) ? 1 : 0;
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.Equals:
                    program[program[ix + 3]] = GetParameter(instruction, 1) == GetParameter(instruction, 2) ? 1 : 0;
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.AdjustRelativeBase:
                    program.RelativeBase += (int)GetParameter(instruction, 1);
                    return new OpInstructionResult
                    {
                        Index = ix + 2,
                        Status = IntcodeStatus.Running
                    };
                case OpCodes.End:
                    return new OpInstructionResult
                    {
                        Status = IntcodeStatus.Ended
                    };
                default:
                    throw new UnknownOpCodeException();
            }
        }
    }
}
