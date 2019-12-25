﻿namespace AOC2019.Modules.Intcode.Instructions
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
                case OpCodes.CopyTo:
                    mem[mem[ix + 1]] = instruction.Input;
                    return new OpInstructionResult
                    {
                        Index = ix + 2,
                        Status = -1
                    };
                case OpCodes.Output:
                    return new OpInstructionResult
                    {
                        Index = ix + 2,
                        Output = GetParameter(instruction, 1),
                        Status = -1
                    };
                case OpCodes.JumpIfTrue:
                    return new OpInstructionResult
                    {
                        Index = GetParameter(instruction, 1) != 0 ? GetParameter(instruction, 2) : ix + 3,
                        Status = -1
                    };
                case OpCodes.JumpIfFalse:
                    return new OpInstructionResult
                    {
                        Index = GetParameter(instruction, 1) == 0 ? GetParameter(instruction, 2) : ix + 3,
                        Status = -1
                    };
                case OpCodes.LessThan:
                    mem[mem[ix + 3]] = GetParameter(instruction, 1) < GetParameter(instruction, 2) ? 1 : 0;
                    return new OpInstructionResult
                    {
                        Index = ix + 4,
                        Status = -1
                    };
                case OpCodes.Equals:
                    mem[mem[ix + 3]] = GetParameter(instruction, 1) == GetParameter(instruction, 2) ? 1 : 0;
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
