namespace AOC2019.Modules.Arcade
{
    public interface IArcadeCabinet
    {
        (long x, long y) Size { get; }
        (long x, long y) BallPosition { get; }
        (long x, long y) PaddlePosition { get; }

        JoystickPosition JoystickPosition { get; set; }
        long Score { get; }

        void Execute();
    }
}