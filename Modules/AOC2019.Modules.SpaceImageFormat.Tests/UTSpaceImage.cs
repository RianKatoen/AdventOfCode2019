using AOC2019.Modules.SpaceImageFormate;
using System;
using Xunit;

namespace AOC2019.Modules.SpaceImageFormat.Tests
{
    public class UTSpaceImage
    {
        [Fact]
        public void ConstructorWorksAsExpected()
        {
            var sut = new SpaceImage((3, 2), "123456789012");
            Assert.Equal(1, sut[0]);
            Assert.Equal(5, sut[4]);
            Assert.Equal(2, sut[11]);
        }

        [Fact]
        public void ConstructorThrowsExceptionIfIncorrectSize()
        {
            Assert.Throws<ArgumentException>(() => new SpaceImage((3, 2), "1234567890123"));
        }

        [Fact]
        public void RetrieveLayers()
        {
            var sut = new SpaceImage((3, 2), "123456789987");

            Assert.Throws<ArgumentException>(() => sut.Layer(-1));
            Assert.Throws<ArgumentException>(() => sut.Layer(4));

            var layer0 = sut.Layer(0);
            Assert.Equal(6, layer0.Length);
            Assert.Equal(1, layer0[0]);
            Assert.Equal(2, layer0[1]);
            Assert.Equal(3, layer0[2]);
            Assert.Equal(4, layer0[3]);
            Assert.Equal(5, layer0[4]);
            Assert.Equal(6, layer0[5]);

            var layer1 = sut.Layer(1);
            Assert.Equal(6, layer1.Length);
            Assert.Equal(7, layer1[0]);
            Assert.Equal(8, layer1[1]);
            Assert.Equal(9, layer1[2]);
            Assert.Equal(9, layer1[3]);
            Assert.Equal(8, layer1[4]);
            Assert.Equal(7, layer1[5]);
        }


        [Fact]
        public void Render()
        {
            var sut = new SpaceImage((2, 2), "0222112222120000");
            var renderedImage = sut.Render();

            Assert.Equal(SpacePixel.Black, renderedImage[0, 0]);
            Assert.Equal(SpacePixel.White, renderedImage[0, 1]);
            Assert.Equal(SpacePixel.White, renderedImage[1, 0]);
            Assert.Equal(SpacePixel.Black, renderedImage[0, 0]);
        }

        [Fact]
        public void RenderToText()
        {
            var sut = new SpaceImage((2, 2), "0222112222120000");
            var renderedImage = sut.RenderToText();

            Assert.Equal("-", renderedImage[0, 0]);
            Assert.Equal("*", renderedImage[0, 1]);
            Assert.Equal("*", renderedImage[1, 0]);
            Assert.Equal("-", renderedImage[0, 0]);
        }
    }
}
