using AOC2019.Modules.Arcade;
using AOC2019.Modules.Intcode;
using AOC2019.Modules.Utilities;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._13
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
            var program = new IntcodeProgram(EmbeddedResources.Read(GetType(), "input.txt"));
            var cabinet = new ArcadeCabinet(program);

            cabinet.Execute();

            var (x, y) = cabinet.Size;
            var blockTile = TilePainter.ToChar(Tile.Block);
            var screen = cabinet.ToString();
            _output.WriteLine($"Screen size: ({x}, {y})");
            _output.WriteLine($"Number of block tiles: {screen.Count(c => c == blockTile)}");
            _output.WriteLine(screen);
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var program = new IntcodeProgram(EmbeddedResources.Read(GetType(), "input.txt"));
            var player = new Player();
            var cabinet = new ArcadeCabinet(program);

            program[0] = 2;
            var t = 0;
            while (program.Status != IntcodeStatus.Ended)
            {
                cabinet.Execute();
                player.Move(cabinet);

                //if (t % 100 == 0)
                //{
                //    System.IO.File.WriteAllText($@"C:\Users\rkatoen\Desktop\Arcade\output{t.ToString("D5")}.txt", cabinet.ToString());
                //}

                t++;
            }

            var (x, y) = cabinet.Size;
            var blockTile = TilePainter.ToChar(Tile.Block);
            var screen = cabinet.ToString();
            //System.IO.File.WriteAllText($@"C:\Users\rkatoen\Desktop\Arcade\output{(99999).ToString("D5")}.txt", screen);
            _output.WriteLine($"Screen size: ({x}, {y})");
            _output.WriteLine($"Number of block tiles: {screen.Count(c => c == blockTile)}");
            _output.WriteLine($"Score: {cabinet.Score}");
            _output.WriteLine(screen);

            Assert.Equal(20940, cabinet.Score);
        }
    }
}
