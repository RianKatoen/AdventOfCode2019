using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerator<(HullColor color, int noVisits)> GetEnumerator() => _hull.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _hull.Values.GetEnumerator();

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

        public override string ToString()
        {
            var result = "";
            if (_hull.Count == 0)
            {
                return result;
            }

            var x0 = _hull.Keys.Select(k => k.x).Min();
            var y0 = _hull.Keys.Select(k => k.y).Min();

            var x1 = _hull.Keys.Select(k => k.x).Max();
            var y1 = _hull.Keys.Select(k => k.y).Max();

            for (var y = y0; y <= y1; y++)
            {
                for (var x = x0; x <= x1; x++)
                {

                    if (_hull.TryGetValue((x, y), out var info))
                    {
                        result += info.color == HullColor.White ? "#" : ".";
                    }
                    else
                    {
                        result += ".";
                    }
                }

                result += Environment.NewLine;
            }

            return result;
        }
    }
}
