using AOC2019.Modules.Intcode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Arcade
{
    public class ArcadeCabinet : IArcadeCabinet
    {
        private readonly IIntcodeProgram _program;
        private readonly Dictionary<(long x, long y), char> _grid;

        public ArcadeCabinet(IIntcodeProgram program)
        {
            _program = program;
            _grid = new Dictionary<(long x, long y), char>();
        }

        public JoystickPosition JoystickPosition { get; set; }
        public long Score { get; private set; } = 0;

        public (long x, long y) BallPosition { get; private set; }
        public (long x, long y) PaddlePosition { get; private set; }

        public (long x, long y) Size
        {
            get
            {
                var x0 = _grid.Keys.Select(k => k.x).Min();
                var y0 = _grid.Keys.Select(k => k.y).Min();

                var x1 = _grid.Keys.Select(k => k.x).Max();
                var y1 = _grid.Keys.Select(k => k.y).Max();

                return (x1 - x0, y1 - y0);
            }
        }

        public void Execute()
        {
            _program.Input.Add((long)JoystickPosition);
            _program.Execute();

            var outputs = _program.Output;
            var ix = 0;
            while (ix < outputs.Count)
            {
                var x = outputs[ix];
                var y = outputs[ix + 1];
                var result = outputs[ix + 2];

                if (x == -1 && y == 0)
                {
                    Score = result;
                }
                else
                {
                    var tile = (Tile)result;
                    switch (tile)
                    {
                        case Tile.Ball: BallPosition = (x, y); break;
                        case Tile.HorizontalPaddle: PaddlePosition = (x, y); break;
                    }

                    _grid[(x, y)] = TilePainter.ToChar(tile);
                }

                ix += 3;
            }
        }

        public override string ToString()
        {
            var result = "";
            if (_grid.Count == 0)
            {
                return result;
            }

            var x0 = _grid.Keys.Select(k => k.x).Min();
            var y0 = _grid.Keys.Select(k => k.y).Min();

            var x1 = _grid.Keys.Select(k => k.x).Max();
            var y1 = _grid.Keys.Select(k => k.y).Max();

            for (var y = y0; y <= y1; y++)
            {
                for (var x = x0; x <= x1; x++)
                {

                    if (_grid.TryGetValue((x, y), out var info))
                    {
                        result += info;
                    }
                    else
                    {
                        result += TilePainter.ToChar(Tile.Empty);
                    }
                }

                result += Environment.NewLine;
            }

            return result;
        }
    }
}
