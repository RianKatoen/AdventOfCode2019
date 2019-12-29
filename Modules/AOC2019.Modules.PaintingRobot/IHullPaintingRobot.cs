namespace AOC2019.Modules.PaintingRobot
{
    public interface IHullPaintingRobot
    {
        HullColor Camera();
        void Move();
        void Paint(HullColor color);
        void Turn(TurningDirection direction);
    }
}