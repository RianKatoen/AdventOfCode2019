namespace AOC2019.Modules.Fuel.ManagementSystem
{
    public enum WireDirection
    {
        Up,
        Right,
        Down,
        Left
    }

    public static class WireDirections
    {
        public static WireDirection FromChar(char d)
        {
            switch (d)
            {
                case 'U': return WireDirection.Up;
                case 'R': return WireDirection.Right;
                case 'D': return WireDirection.Down;
                case 'L': return WireDirection.Left;
                default: throw new UnknownWireDirectionException();
            }
        }

        public static char ToChar(WireDirection wd)
        {
            switch (wd)
            {
                case WireDirection.Up: return 'U';
                case WireDirection.Right: return 'R';
                case WireDirection.Down: return 'D';
                case WireDirection.Left: return 'L';
                default: throw new UnknownWireDirectionException();
            }
        }
    }
}
