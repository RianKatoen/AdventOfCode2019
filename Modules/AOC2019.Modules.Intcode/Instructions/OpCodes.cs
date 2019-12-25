namespace AOC2019.Modules.Intcode.Instructions
{
    public enum OpCodes
    {
        // Day 2
        Add = 1,
        Multiply = 2,
        // Day 5 (part 1)
        CopyTo = 3,
        Output = 4,
        // Day 5 (part 2)
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        // ZEH ENT
        End = 99
    }
}
