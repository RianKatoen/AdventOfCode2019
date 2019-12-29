using AOC2019.Modules.Intcode;
using System.Linq;

namespace AOC2019.Modules.PaintingRobot
{
    public class ControlUnit
    {
        private readonly IIntcodeProgram _program;
        private readonly IHullPaintingRobot _robot;

        public ControlUnit(IIntcodeProgram program, IHullPaintingRobot robot)
        {
            _program = program;
            _robot = robot;
        }

        public void Execute(int? noCycles = null)
        {
            var cycle = 0;
            while (_program.Status != IntcodeStatus.Ended && (!noCycles.HasValue || cycle < noCycles.Value))
            {
                var noOutputs = _program.Output.Count();

                _program.Input.Add((long)_robot.Camera());
                _program.Execute();

                if (_program.Status == IntcodeStatus.Ended)
                {
                    break;
                }

                var outputs = _program.Output.Skip(noOutputs).ToList();
                _robot.Paint((HullColor)outputs[0]);
                _robot.Turn((TurningDirection)outputs[1]);
                _robot.Move();

                cycle++;
            }
        }
    }
}
