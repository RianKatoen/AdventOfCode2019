namespace AOC2019.Modules.Intcode
{
    public interface IIntcodeProgram
    {
        int this[int index] { get; }
        int MemSize { get; }
        IntcodeStatus Status { get; }

        void Execute();
    }
}