using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Maps.Moons
{
    public class MoonMap : List<Moon>
    {
        public long Time { get; private set; } = 0;

        public MoonMap()
        {
        }

        public MoonMap(IEnumerable<string> lines)
        {
            AddFromText(lines);
        }

        public void AddFromText(IEnumerable<string> lines)
        {
            AddRange(lines.Select(l => new Moon(new Coord(l))));
        }

        public int TotalEnergy => this.Select(m => m.TotalEnergy).Sum();

        public void Develop(int noOfSteps = 1)
        {
            for (var t = 0; t < noOfSteps; t++)
            {
                CalculateVelocities();
                DetermineNewPositions();
                Time++;
            }
        }

        private void CalculateVelocities()
        {
            for (var i = 0; i < Count; i++)
            {
                var firstMoon = this[i];
                for (var j = i + 1; j < Count; j++)
                {
                    var secondMoon = this[j];
                    var delta = firstMoon.Position < secondMoon.Position;

                    firstMoon.Velocity += delta;
                    secondMoon.Velocity -= delta;
                }
            }
        }

        private void DetermineNewPositions()
        {
            for (var i = 0; i < Count; i++)
            {
                var moon = this[i];
                moon.Position += moon.Velocity;
            }
        }

        public override string ToString()
        {
            var result = "";
            foreach (var moon in this)
            {
                if (result != "")
                {
                    result += Environment.NewLine;
                }

                var pos = moon.Position;
                var vel = moon.Velocity;

                result += $"pos={moon.Position.ToString()}, vel={moon.Velocity.ToString()}";
            }

            return result;
        }
    }
}
