using System;

namespace AOC2019.Modules.Arcade
{
    public enum Tile
    {
        Empty = 0,
        Wall = 1,
        Block = 2,
        HorizontalPaddle = 3,
        Ball = 4
    }

    public static class TilePainter
    {
        public static char ToChar(Tile tile)
        {
            switch (tile)
            {
                case Tile.Empty: return ' ';
                case Tile.Wall: return '+';
                case Tile.Block: return '#';
                case Tile.HorizontalPaddle: return '-';
                case Tile.Ball: return 'o';
                default: throw new ArgumentException();
            }
        }
    }
}
