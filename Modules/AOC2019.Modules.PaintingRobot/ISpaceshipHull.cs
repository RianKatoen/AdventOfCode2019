namespace AOC2019.Modules.PaintingRobot
{
    public interface ISpaceshipHull
    {
        (HullColor color, int noVisits) this[(int x, int y) pos] { get; }
        void Paint((int x, int y) pos, HullColor color);
    }
}