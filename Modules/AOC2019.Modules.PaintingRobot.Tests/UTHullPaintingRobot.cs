using Moq;
using Xunit;

namespace AOC2019.Modules.PaintingRobot.Tests
{
    public class UTHullPaintingRobot
    {
        [Fact(DisplayName = "Check if turning left works as expected.")]
        public void CheckIfTurningLeftWorksAsExpected()
        {
            var hull = new Mock<ISpaceshipHull>();
            var sut = new HullPaintingRobot(hull.Object);

            Assert.Equal((0, -1), sut.Direction);
            sut.Turn(TurningDirection.Left);
            Assert.Equal((-1, 0), sut.Direction);
            sut.Turn(TurningDirection.Left);
            Assert.Equal((0, 1), sut.Direction);
            sut.Turn(TurningDirection.Left);
            Assert.Equal((1, 0), sut.Direction);
            sut.Turn(TurningDirection.Left);
            Assert.Equal((0, -1), sut.Direction);
        }

        [Fact(DisplayName = "Check if turning right works as expected.")]
        public void CheckIfTurningRightWorksAsExpected()
        {
            var hull = new Mock<ISpaceshipHull>();
            var sut = new HullPaintingRobot(hull.Object);

            Assert.Equal((0, -1), sut.Direction);
            sut.Turn(TurningDirection.Right);
            Assert.Equal((1, 0), sut.Direction);
            sut.Turn(TurningDirection.Right);
            Assert.Equal((0, 1), sut.Direction);
            sut.Turn(TurningDirection.Right);
            Assert.Equal((-1, 0), sut.Direction);
        }

        [Fact(DisplayName = "Hull painting routine.")]
        public void HullPaintingRoutine()
        {
            var hull = new Mock<ISpaceshipHull>();
            SetupTestPaint((0, 0), HullColor.White);
            SetupTestPaint((0, -1), HullColor.Black);
            SetupTestPaint((1, -1), HullColor.White);

            var sut = new HullPaintingRobot(hull.Object);

            sut.Paint(HullColor.White);
            sut.Move();

            sut.Paint(HullColor.Black);
            sut.Turn(TurningDirection.Right);
            sut.Move();

            sut.Paint(HullColor.White);

            hull.Verify();

            void SetupTestPaint((int x, int y) pos, HullColor color)
            {
                hull.Setup(h => h.Paint(pos, color)).Verifiable();
            }
        }
    }
}
