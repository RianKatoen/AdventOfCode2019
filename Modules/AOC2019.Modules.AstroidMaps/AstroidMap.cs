using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.AstroidMaps
{
    public class AstroidMap : IAstroidMap
    {
        private readonly List<(int x, int y)> _astroids = new List<(int x, int y)>();

        public AstroidMap(IEnumerable<string> lines)
        {
            var y = 0;
            foreach (var line in lines)
            {
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        _astroids.Add((x, y));
                    }
                }
                y++;

                Size = (line.Length, y);
            }
        }

        public (int x, int y) Size { get; }
        public bool Astroid((int x, int y) pos) => _astroids.Any(a => a == pos);
    }
}
