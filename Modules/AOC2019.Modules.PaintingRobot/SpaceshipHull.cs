using System.Collections.Generic;

namespace AOC2019.Modules.PaintingRobot
{
    public class SpaceshipHull : ISpaceshipHull
    {
        private readonly Dictionary<(int x, int y), (HullColor color, int noVisits)> _hull = new Dictionary<(int x, int y), (HullColor color, int noVisits)>();

        public (HullColor color, int noVisits) this[(int x, int y) pos]
        {
            get
            {
                if (_hull.TryGetValue(pos, out var info))
                {
                    return info;
                }
                else
                {
                    return (HullColor.Black, 0);
                }
            }
        }

        public void Paint((int x, int y) pos, HullColor color)
        {
            if (_hull.TryGetValue(pos, out var info))
            {
                _hull[pos] = (color, info.noVisits + 1);
            }
            else
            {
                _hull[pos] = (color, 1);
            }
        }
    }
}
