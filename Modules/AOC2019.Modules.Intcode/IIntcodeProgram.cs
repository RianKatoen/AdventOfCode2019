namespace AOC2019.Modules.Intcode
{
    public interface IIntcodeProgram
    {
        IntcodeInput Input { get; set; }
        IntcodeOutput Output { get; set; }
        IntcodeStatus Status { get; set; }

        void Execute(int? noCycles = null);
    }
}