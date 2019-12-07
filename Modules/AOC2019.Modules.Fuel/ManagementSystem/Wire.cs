using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Fuel.ManagementSystem
{
    public class Wire : IEnumerable<WireMovement>, IWire
    {
        private readonly WireMovement[] _path;

        public Wire(string path)
        {
            _path = path
                .Split(',')
                .Select(s => new WireMovement
                {
                    Direction = WireDirections.FromChar(s[0]),
                    Length = int.Parse(s.Substring(1))
                })
                .ToArray();
        }

        public WireMovement this[int index]
        {
            get => _path[index];
            set => _path[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator() => _path.GetEnumerator();
        public IEnumerator<WireMovement> GetEnumerator() => ((IEnumerable<WireMovement>)_path).GetEnumerator();

        public override string ToString()
        {
            var paths = _path.Select(wm => $"{WireDirections.ToChar(wm.Direction)}{wm.Length}");
            return string.Join(",", paths);
        }
    }
}
