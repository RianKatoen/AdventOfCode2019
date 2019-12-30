namespace AOC2019.Modules.Arcade
{
    public class Player
    {
        public void Move(IArcadeCabinet cabinet)
        {
            if(cabinet.BallPosition.x > cabinet.PaddlePosition.x)
            {
                cabinet.JoystickPosition = JoystickPosition.Right;
            }
            else if(cabinet.BallPosition.x < cabinet.PaddlePosition.x)
            {
                cabinet.JoystickPosition = JoystickPosition.Left;
            }
        }
    }
}
