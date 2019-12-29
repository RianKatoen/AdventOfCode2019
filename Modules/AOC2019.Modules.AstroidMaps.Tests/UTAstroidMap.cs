using AOC2019.Modules.Utilities;
using Xunit;

namespace AOC2019.Modules.AstroidMaps.Tests
{
    public class UTAstroidMap
    {
        [Fact(DisplayName = "Example 1 read")]
        public void ExampleOneRead()
        {
            var lines = EmbeddedResources.ReadLines<string>(GetType(), "Examples.example1.txt");
            var sut = new AstroidMap(lines);

            Assert.False(sut.Astroid((0, 0)));
            Assert.True(sut.Astroid((1, 0)));
            Assert.True(sut.Astroid((3, 4)));
            Assert.False(sut.Astroid((0, 4)));

            Assert.Equal((5, 5), sut.Size);
        }
    }
}
