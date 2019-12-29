using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Maps.Asteroids
{
    public class AsteroidMap : IEnumerable<(int x, int y)>
    {
        private readonly List<(int x, int y)> _astroids = new List<(int x, int y)>();

        public AsteroidMap((int x, int y) size, IEnumerable<(int x, int y)> astroids)
        {
            Size = size;
            _astroids.AddRange(astroids);

            if (astroids.Select(a => a.x).Max() >= size.x)
            {
                throw new System.IndexOutOfRangeException();
            }

            if (astroids.Select(a => a.y).Max() >= size.y)
            {
                throw new System.IndexOutOfRangeException();
            }

            if (astroids.Any(a => a.x < 0))
            {
                throw new System.ArgumentException();
            }

            if (astroids.Any(a => a.y < 0))
            {
                throw new System.ArgumentException();
            }
        }

        public AsteroidMap(IEnumerable<string> lines)
        {
            var y = 0;
            foreach (var line in lines)
            {
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        _astroids.Add((x, y));
                    }
                }
                y++;

                Size = (line.Length, y);
            }
        }

        public void Add((int x, int y) pos) => _astroids.Add(pos);

        public (int x, int y) Size { get; }
        public bool Astroid((int x, int y) pos) => _astroids.Any(a => a == pos);

        public List<IGrouping<(double angle, bool direction), (int x, int y)>>
            AstroidsLineOfSight((int x, int y) pos)
        {
            return _astroids
                .Where(a => a != pos)
                .GroupBy(a => (angle: (double)(a.y - pos.y) / (a.x - pos.x), direction: a.x >= pos.x))
                .ToList();
        }

        public int VisibleAsteroids((int x, int y) pos)
        {
            return AstroidsLineOfSight(pos).Count;
        }

        public IEnumerator<(int x, int y)> GetEnumerator() => ((IEnumerable<(int x, int y)>)_astroids).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<(int x, int y)>)_astroids).GetEnumerator();
    }
}
