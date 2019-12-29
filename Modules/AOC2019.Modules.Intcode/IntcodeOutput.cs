using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Intcode
{
    public class IntcodeOutput : IEnumerable<int>
    {
        private readonly List<int> _outputs;

        public IntcodeOutput(IEnumerable<int> outputs)
        {
            _outputs = outputs.ToList();
        }

        public int this[int index] => _outputs[index];
        public void Add(int val) => _outputs.Add(val);


        public override string ToString() => string.Join(",", _outputs);
        public IEnumerator<int> GetEnumerator() => ((IEnumerable<int>)_outputs).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<int>)_outputs).GetEnumerator();
    }
}
