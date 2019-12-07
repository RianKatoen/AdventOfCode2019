using AOC2019.Modules.Fuel.ManagementSystem;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.ManagementSystem
{
    public class UTWireGrid
    {
        [Fact(DisplayName = "Verify functionality CountWires")]
        public void VerifyFunctionalityCountWires()
        {
            var wireMovementsA = new List<WireMovement>
            {
                new WireMovement { Direction = WireDirection.Up, Length = 3 },
                new WireMovement { Direction = WireDirection.Right, Length = 2 },
                new WireMovement { Direction = WireDirection.Down, Length = 10 },
                new WireMovement { Direction = WireDirection.Left, Length = 5 }
            };
            var wireA = new Mock<IWire>();
            wireA.Setup(w => w.GetEnumerator()).Returns(wireMovementsA.GetEnumerator());

            var wireMovementsB = new List<WireMovement>
            {
                new WireMovement { Direction = WireDirection.Up, Length = 1 },
                new WireMovement { Direction = WireDirection.Right, Length = 1 },
                new WireMovement { Direction = WireDirection.Down, Length = 1 },
                new WireMovement { Direction = WireDirection.Left, Length = 1 }
            };

            var wireB = new Mock<IWire>();
            wireB.Setup(w => w.GetEnumerator()).Returns(wireMovementsB.GetEnumerator());

            var sut = new WireGrid();

            sut.Draw(wireA.Object);
            sut.Draw(wireB.Object);

            Assert.Equal((WireId.Both, 0), sut.CountWires(0, 0));
            Assert.Equal((WireId.Second, 2), sut.CountWires(1, 1));
            Assert.Equal((WireId.None, 0), sut.CountWires(-1, -1));

            Assert.Equal(WireId.Both, sut.CountWires(0, 1).id);
            Assert.Equal(WireId.First, sut.CountWires(0, 2).id);
            Assert.Equal(WireId.First, sut.CountWires(0, 3).id);
            Assert.Equal(WireId.None, sut.CountWires(0, 4).id);

            Assert.Equal(WireId.First, sut.CountWires(1, 3).id);
            Assert.Equal(WireId.First, sut.CountWires(2, 3).id);
            Assert.Equal(WireId.None, sut.CountWires(3, 3).id);

            Assert.Equal(WireId.First, sut.CountWires(2, -7).id);
            Assert.Equal(WireId.None, sut.CountWires(2, -8).id);

            Assert.Equal(WireId.First, sut.CountWires(-3, -7).id);
            Assert.Equal(WireId.None, sut.CountWires(-4, -7).id);
        }

        [Fact(DisplayName = "Verify functionality Intersect")]
        public void VerifyFunctionalityIntersect()
        {
            var wireMovementsA = new List<WireMovement>
            {
                new WireMovement { Direction = WireDirection.Up, Length = 1 },
                new WireMovement { Direction = WireDirection.Right, Length = 2 },
                new WireMovement { Direction = WireDirection.Down, Length = 10 },
                new WireMovement { Direction = WireDirection.Right, Length = 2 },
                new WireMovement { Direction = WireDirection.Up, Length = 10 }
            };
            var wireA = new Mock<IWire>();
            wireA.Setup(w => w.GetEnumerator()).Returns(wireMovementsA.GetEnumerator());

            var wireMovementsB = new List<WireMovement>
            {
                new WireMovement { Direction = WireDirection.Right, Length = 10 }
            };

            var wireB = new Mock<IWire>();
            wireB.Setup(w => w.GetEnumerator()).Returns(wireMovementsB.GetEnumerator());

            var sut = new WireGrid();

            sut.Draw(wireA.Object);
            sut.Draw(wireB.Object);

            var intersections = sut.Intersections();
            Assert.Equal(3, intersections.Count());

            Assert.Contains((0, 0), intersections);
            Assert.Contains((2, 0), intersections);
            Assert.Contains((4, 0), intersections);
        }
    }
}
