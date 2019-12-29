namespace AOC2019.Modules.PaintingRobot
{
    public class HullPaintingRobot : IHullPaintingRobot
    {
        private readonly ISpaceshipHull _hull;

        public (int x, int y) Position { get; private set; } = (0, 0);
        public (int x, int y) Direction { get; private set; } = (0, -1);

        public HullPaintingRobot(ISpaceshipHull hull)
        {
            _hull = hull;
        }

        public HullColor Camera() => _hull[Position].color;
        public void Paint(HullColor color) => _hull.Paint(Position, color);
        public void Move() => Position = (Position.x + Direction.x, Position.y + Direction.y);
        public void Turn(TurningDirection direction)
        {
            if (direction == TurningDirection.Left)
            {
                if (Direction.x == 0)
                {
                    Direction = (Direction.y, 0);
                }
                else
                {
                    Direction = (0, -Direction.x);
                }
            }
            else
            {
                if (Direction.x == 0)
                {
                    Direction = (-Direction.y, 0);
                }
                else
                {
                    Direction = (0, Direction.x);
                }
            }
        }
    }
}
