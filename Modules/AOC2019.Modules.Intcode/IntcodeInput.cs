using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeInput
    {
        private int _index = 0;
        private readonly List<long> _inputs;

        public IntcodeInput(IEnumerable<long> inputs)
        {
            _inputs = inputs.ToList();
        }

        public void Add(long val) => _inputs.Add(val);
        public void AddRange(IEnumerable<long> vals) => _inputs.AddRange(vals);

        public long? Get()
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

        public static implicit operator IntcodeInput(long value) => new IntcodeInput(new long[] { value });
        public override string ToString() => string.Join(",", _inputs);
    }
}
