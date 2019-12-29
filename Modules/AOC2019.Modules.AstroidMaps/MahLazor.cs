using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.AstroidMaps
{
    public class MahLazor
    {
        public List<(int x, int y)> PewPew(AstroidMap map, (int x, int y) pos)
        {
            var angles = map
                .AstroidsLineOfSight(pos)
                .OrderBy(a => a.Key.angle)
                .OrderByDescending(a => a.Key.direction)
                .Select(d => new
                {
                    d.Key,
                    Asteroids = d
                    .OrderBy(a => (a.x - pos.x) * (a.x - pos.x) + (a.y - pos.y) * (a.y - pos.y))
                    .ToList()
                })
                .ToList();

            var zapped = new List<(int x, int y)>();
            while (angles.Count > 0)
            {
                foreach (var angle in angles)
                {
                    var android = angle.Asteroids.First();
                    zapped.Add(android);
                    angle.Asteroids.Remove(android);

                    if (angle.Asteroids.Count == 0)
                    {

                    }
                }

                angles = angles.Where(a => a.Asteroids.Count > 0).ToList();
            }

            return zapped;
        }
    }
}
