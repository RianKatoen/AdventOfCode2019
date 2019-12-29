using AOC2019.Modules.Amplification;
using AOC2019.Modules.Utilities;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._7
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        private string Memory() => EmbeddedResources.Read(GetType(), "input.txt");

        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var amplificationCircuit = new AmplificationCircuit(Memory());
            var result = new Dictionary<string, int>();
            var numbers = new int[] { 0, 1, 2, 3, 4 };
            foreach (var i in numbers)
            {
                var jNumbers = numbers.Where(no => no != i).ToArray();
                foreach (var j in jNumbers)
                {
                    var kNumbers = jNumbers.Where(no => no != j).ToArray();
                    foreach (var k in kNumbers)
                    {
                        var nNumbers = kNumbers.Where(no => no != k).ToArray();
                        foreach (var n in nNumbers)
                        {
                            var mNumbers = nNumbers.Where(no => no != n).ToArray();
                            foreach (var m in mNumbers)
                            {
                                var settings = $"{i},{j},{k},{n},{m}";
                                amplificationCircuit.SetPhaseSettings(settings);
                                amplificationCircuit.Execute();

                                result.Add(settings, amplificationCircuit.Signal);
                            }
                        }
                    }
                }
            }

            Assert.Equal(120, result.Count);

            var maxSignal = result.Max(kv => kv.Value);
            var maxResults = result.Where(kv => kv.Value == maxSignal);

            _output.WriteLine($"No. of max results: {maxResults.Count()}");
            foreach (var maxResult in maxResults)
            {
                _output.WriteLine($"{maxResult.Key}: {maxResult.Value}");
            }

            Assert.Equal(11828, maxResults.Single().Value);
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var amplificationCircuit = new AmplificationCircuit(Memory());
            var result = new Dictionary<string, int>();
            var numbers = new int[] { 5, 6, 7, 8, 9 };
            foreach (var i in numbers)
            {
                var jNumbers = numbers.Where(no => no != i).ToArray();
                foreach (var j in jNumbers)
                {
                    var kNumbers = jNumbers.Where(no => no != j).ToArray();
                    foreach (var k in kNumbers)
                    {
                        var nNumbers = kNumbers.Where(no => no != k).ToArray();
                        foreach (var n in nNumbers)
                        {
                            var mNumbers = nNumbers.Where(no => no != n).ToArray();
                            foreach (var m in mNumbers)
                            {
                                var settings = $"{i},{j},{k},{n},{m}";
                                amplificationCircuit.SetPhaseSettings(settings);
                                amplificationCircuit.Execute();

                                result.Add(settings, amplificationCircuit.Signal);
                            }
                        }
                    }
                }
            }

            Assert.Equal(120, result.Count);

            var maxSignal = result.Max(kv => kv.Value);
            var maxResults = result.Where(kv => kv.Value == maxSignal);

            _output.WriteLine($"No. of max results: {maxResults.Count()}");
            foreach (var maxResult in maxResults)
            {
                _output.WriteLine($"{maxResult.Key}: {maxResult.Value}");
            }

            Assert.Equal(1714298, maxResults.Single().Value);
        }
    }
}
