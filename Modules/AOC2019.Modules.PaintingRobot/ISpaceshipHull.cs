using System.Collections.Generic;

namespace AOC2019.Modules.PaintingRobot
{
    public interface ISpaceshipHull : IEnumerable<(HullColor color, int noVisits)>
    {
        (HullColor color, int noVisits) this[(int x, int y) pos] { get; }
        void Paint((int x, int y) pos, HullColor color);
    }
}