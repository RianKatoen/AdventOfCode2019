using AOC2019.Modules.SpaceImageFormate;
using AOC2019.Modules.Utilities;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._8
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }



        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var data = EmbeddedResources.Read(GetType(), "input.txt");
            var image = new SpaceImage((25, 6), data);

            var nZeros = 25 * 6 + 1;
            var answer = 0;

            foreach (var layer in image)
            {
                var nZerosOnLayer = layer.Where(pixel => pixel == 0).Count();
                if (nZerosOnLayer < nZeros)
                {
                    nZeros = nZerosOnLayer;
                    var nOnes = layer.Where(pixel => pixel == 1).Count();
                    var nTwos = layer.Where(pixel => pixel == 2).Count();

                    if(nZeros + nOnes + nTwos != 150)
                    {
                        throw new System.Exception("WUT?");
                    }

                    answer = nOnes * nTwos;
                }
            }

            _output.WriteLine($"The number of 1's multiplied by number of 2's");
            _output.WriteLine($"for the layer with the most number of 0's equals:");
            _output.WriteLine($"{answer}");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var data = EmbeddedResources.Read(GetType(), "input.txt");
            var image = new SpaceImage((25, 6), data);
            var renderedImage = image.RenderToText();

            for(var row = 0; row < renderedImage.GetLength(0); row++)
            {
                var line = "";
                for (var column = 0; column < renderedImage.GetLength(1); column++)
                {
                    line += renderedImage[row, column];
                }
                _output.WriteLine(line);
            }
        }
    }
}
