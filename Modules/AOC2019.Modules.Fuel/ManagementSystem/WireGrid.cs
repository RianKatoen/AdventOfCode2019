using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Fuel.ManagementSystem
{
    public class WireGrid
    {
        private int _numberOfWires;
        private readonly Dictionary<(int x, int y), (WireId id, int steps)> _coords = new Dictionary<(int x, int y), (WireId id, int steps)>();

        public void IncreaseCount((int x, int y) pos, WireId id, int steps)
        {
            if (_coords.TryGetValue(pos, out var point))
            {
                if (point.id != WireId.Both && point.id != id)
                {
                    _coords[pos] = (point.id | id, point.steps + steps);
                }
            }
            else
            {
                _coords[pos] = (id, steps);
            }
        }

        public void Draw(IWire wire)
        {
            if (_numberOfWires == 2)
            {
                throw new OverflowException();
            }

            _numberOfWires++;
            var id = _numberOfWires == 1 ? WireId.First : WireId.Second;

            var pos = (x: 0, y: 0);
            var nSteps = 0;
            IncreaseCount(pos, id, nSteps);

            foreach (var movement in wire)
            {
                for (var step = 1; step <= movement.Length; step++)
                {
                    switch (movement.Direction)
                    {
                        case WireDirection.Up: pos = (pos.x, pos.y + 1); break;
                        case WireDirection.Down: pos = (pos.x, pos.y - 1); break;
                        case WireDirection.Right: pos = (pos.x + 1, pos.y); break;
                        case WireDirection.Left: pos = (pos.x - 1, pos.y); break;
                        default: throw new UnknownWireDirectionException();
                    }

                    nSteps++;
                    IncreaseCount(pos, id, nSteps);
                }
            }
        }

        public (WireId id, int steps) CountWires(int x, int y)
        {
            if (_coords.TryGetValue((x, y), out var info))
            {
                return info;
            }
            else
            {
                return (WireId.None, 0);
            }
        }

        public IEnumerable<(int x, int y)> Intersections()
        {
            return _coords
                .Where(c => c.Value.id == WireId.Both)
                .Select(c => c.Key);
        }

        public IEnumerable<(int x, int y, int steps)> Steps()
        {
            return _coords
                .Where(c => c.Value.id == WireId.Both)
                .Select(c => (c.Key.x, c.Key.y, c.Value.steps));
        }
    }
}
