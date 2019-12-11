using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.OrbitalMap
{
    public class UniversalOrbitalMap : List<Orbit>
    {
        public const string CenterOfMass = "COM";
        public const string You = "YOU";
        public const string Santa = "SAN";

        public UniversalOrbitalMap(IEnumerable<string> planets)
        {
            var orbits = planets
                .Select(p =>
                {
                    var info = p.Split(')');
                    return new Orbit
                    {
                        Center = info[0],
                        Planet = info[1]
                    };
                });

            AddRange(orbits);
        }

        public string GetParent(string planet)
        {
            return this
                .Where(o => o.Planet == planet)
                .Select(o => o.Center)
                .FirstOrDefault();
        }

        public List<string> GetParents(string planet)
        {
            var parent = GetParent(planet);
            var parents = new List<string>();
            while (parent != null)
            {
                parents.Add(parent);
                parent = GetParent(parent);
            }

            return parents;
        }

        public List<string> GetChildren(string planet)
        {
            return this
                   .Where(o => o.Center == planet)
                   .Select(o => o.Planet)
                   .ToList(); // Not using ToLists greatly reduces speed.
        }

        public int NumberOfOrbits()
        {
            var noOfOrbits = 0;
            var levelOfOrbit = 1;

            var planets = GetChildren(CenterOfMass);
            while (planets.Any())
            {
                noOfOrbits += planets.Count() * levelOfOrbit;
                levelOfOrbit++;

                planets = planets
                    .SelectMany(p => GetChildren(p))
                    .ToList(); // Not using ToLists greatly reduces speed.
            }

            return noOfOrbits;
        }

        public int OrbitalTransfers(string from, string to)
        {
            var noTransfers = 0;

            var parent = GetParent(to);
            if (parent == null)
                return -1;

            var parentsFrom = GetParents(from);
            if (parentsFrom.Count == 0)
                return -1;

            while (!parentsFrom.Contains(parent))
            {
                parent = GetParent(parent);
                noTransfers++;
            }

            return noTransfers + parentsFrom.IndexOf(parent);
        }
    }
}
