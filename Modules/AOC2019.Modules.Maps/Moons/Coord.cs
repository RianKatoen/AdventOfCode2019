using System.Text.RegularExpressions;

namespace AOC2019.Modules.Maps.Moons
{
    public struct Coord
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coord(string input)
        {
            var match = Regex.Match(input, "<x=(.*), y=(.*), z=(.*)>");
            X = int.Parse(match.Groups[1].Value);
            Y = int.Parse(match.Groups[2].Value);
            Z = int.Parse(match.Groups[3].Value);
        }

        public static implicit operator Coord((int x, int y, int z) pos) => new Coord
        {
            X = pos.x,
            Y = pos.y,
            Z = pos.z
        };

        public static implicit operator (int x, int y, int z)(Coord coord) =>
        (
            x: coord.X,
            y: coord.Y,
            z: coord.Z
        );


        public static Coord operator +(Coord a, Coord b) => new Coord
        {
            X = a.X + b.X,
            Y = a.Y + b.Y,
            Z = a.Z + b.Z
        };

        public static Coord operator -(Coord a, Coord b) => new Coord
        {
            X = a.X - b.X,
            Y = a.Y - b.Y,
            Z = a.Z - b.Z
        };

        public static Coord operator <(Coord a, Coord b) => new Coord
        {
            X = a.X < b.X ? 1 : (a.X > b.X ? -1 : 0),
            Y = a.Y < b.Y ? 1 : (a.Y > b.Y ? -1 : 0),
            Z = a.Z < b.Z ? 1 : (a.Z > b.Z ? -1 : 0)
        };

        public static Coord operator >(Coord a, Coord b) => new Coord
        {
            X = a.X > b.X ? 1 : (a.X < b.X ? -1 : 0),
            Y = a.Y > b.Y ? 1 : (a.Y < b.Y ? -1 : 0),
            Z = a.Z > b.Z ? 1 : (a.Z < b.Z ? -1 : 0)
        };

        public override string ToString() => $"<x={X}, y={Y}, z={Z}>";
    }
}
