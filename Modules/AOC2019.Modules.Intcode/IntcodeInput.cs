using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeInput
    {
        private int _index = 0;
        private readonly List<int> _inputs;

        public IntcodeInput(IEnumerable<int> inputs)
        {
            _inputs = inputs.ToList();
        }

        public void Add(int val) => _inputs.Add(val);
        public void AddRange(IEnumerable<int> vals) => _inputs.AddRange(vals);

        public int? Get()
        {
            if (_index >= _inputs.Count)
            {
                return null;
            }
            else
            {
                var result = _inputs[_index];
                _index++;

                return result;
            }
        }

        public static implicit operator IntcodeInput(int value) => new IntcodeInput(new int[] { value });
        public override string ToString() => string.Join(",", _inputs);
    }
}
