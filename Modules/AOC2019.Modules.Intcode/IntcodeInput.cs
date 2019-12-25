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

        public int Get()
        {
            var result = _inputs[_index];

            _index++;
            if (_index >= _inputs.Count)
            {
                _index = 0;
            }

            return result;
        }

        public static implicit operator IntcodeInput(int value) => new IntcodeInput(new int[] { value });
        public override string ToString() => string.Join(",", _inputs);
    }
}
