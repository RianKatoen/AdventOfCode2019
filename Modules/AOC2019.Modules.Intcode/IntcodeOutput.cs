using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeOutput : IReadOnlyList<long>
    {
        private readonly List<long> _outputs;
        public int Count => _outputs.Count;

        public IntcodeOutput(IEnumerable<long> outputs)
        {
            _outputs = outputs.ToList();
        }

        public long this[int index] => _outputs[index];
        public void Add(long val) => _outputs.Add(val);


        public override string ToString() => string.Join(",", _outputs);
        public IEnumerator<long> GetEnumerator() => ((IEnumerable<long>)_outputs).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<long>)_outputs).GetEnumerator();
    }
}
