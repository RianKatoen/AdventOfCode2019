using AOC2019.Modules.OrbitalMap;
using System.Collections.Generic;
using Xunit;

namespace AOC2019.Modules.SpaceImageFormat.Tests
{
    public class UTUniversalOrbitalMap
    {
        private List<string> Data => new List<string>
        {
            "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G",
            "G)H", "D)I", "E)J", "J)K", "K)L"
        };

        private List<string> DataPath => new List<string>
        {
            "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G",
            "G)H", "D)I", "E)J", "J)K", "K)L", "K)YOU", "I)SAN"
        };

        [Fact]
        public void ConstructorWorksAsExpected()
        {
            var sut = new UniversalOrbitalMap(Data);

            Assert.Equal(11, sut.Count);
            Assert.Contains(new Orbit { Center = "COM", Planet = "B" }, sut);
            Assert.Contains(new Orbit { Center = "B", Planet = "G" }, sut);
            Assert.Contains(new Orbit { Center = "K", Planet = "L" }, sut);
        }

        [Fact]
        public void GetParent()
        {
            var sut = new UniversalOrbitalMap(Data);

            Assert.Null(sut.GetParent("COM"));
            Assert.Equal("COM", sut.GetParent("B"));
            Assert.Equal("D", sut.GetParent("I"));
        }

        [Fact]
        public void GetChildren()
        {
            var sut = new UniversalOrbitalMap(Data);

            Assert.Equal(new string[] { "B" }, sut.GetChildren("COM"));
            Assert.Equal(new string[] { "C", "G" }, sut.GetChildren("B"));
            Assert.Equal(new string[] { "F", "J" }, sut.GetChildren("E"));
            Assert.Equal(new string[] { }, sut.GetChildren("L"));
        }

        [Fact]
        public void GetParents()
        {
            var sut = new UniversalOrbitalMap(Data);

            Assert.Equal(new string[] { }, sut.GetParents("COM"));
            Assert.Equal(new string[] { "COM" }, sut.GetParents("B"));
            Assert.Equal(new string[] { "K", "J", "E", "D", "C", "B", "COM" }, sut.GetParents("L"));
        }

        [Fact]
        public void NumberOfOrbits()
        {
            var sut = new UniversalOrbitalMap(Data);

            Assert.Equal(42, sut.NumberOfOrbits());
        }

        [Fact]
        public void OrbitalTransfers()
        {
            var correctMap = new UniversalOrbitalMap(DataPath);

            Assert.Equal(4, correctMap.OrbitalTransfers("YOU", "SAN"));
            Assert.Equal(4, correctMap.OrbitalTransfers("SAN", "YOU"));

            var wrongMap = new UniversalOrbitalMap(Data);

            Assert.Equal(-1, wrongMap.OrbitalTransfers("YOU", "B"));
            Assert.Equal(-1, wrongMap.OrbitalTransfers("B", "SAN"));
        }
    }
}
