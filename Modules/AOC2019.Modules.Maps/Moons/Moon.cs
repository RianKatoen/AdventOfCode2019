using System;

namespace AOC2019.Modules.Maps.Moons
{
    public class Moon
    {
        public Moon(Coord pos, Coord? vel = null)
        {
            Position = pos;
            Velocity = vel.GetValueOrDefault();
        }

        public Coord Position { get; set; }
        public Coord Velocity { get; set; }

        public int PotentialEnergy => Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        public int KineticEnergy => Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z);
        public int TotalEnergy => PotentialEnergy * KineticEnergy;
    }
}
