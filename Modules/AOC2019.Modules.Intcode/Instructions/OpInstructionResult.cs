namespace AOC2019.Modules.Intcode.Instructions
{
    public class OpInstructionResult
    {
        public IntcodeStatus Status { get; set; }

        public int Index { get; set; }
        public long? Output { get; set; }
    }
}
