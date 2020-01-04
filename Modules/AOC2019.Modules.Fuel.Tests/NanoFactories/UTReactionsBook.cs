using AOC2019.Modules.Fuel.NanoFactories;
using AOC2019.Modules.Utilities;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.NanoFactories
{
    public class UTReactionsBook
    {
        [Fact(DisplayName = "Reading data from text.")]
        public void ReadingDataFromText()
        {
            var sut = new ReactionsBook(EmbeddedResources.ReadLines<string>(GetType(), "Examples.example1.txt"));
            Assert.Equal(6, sut.Count);
        }

        [Theory(DisplayName = "Calculate required ore.")]
        [InlineData("Examples.example1.txt", 31)]
        [InlineData("Examples.example2.txt", 165)]
        [InlineData("Examples.example3.txt", 13312)]
        [InlineData("Examples.example4.txt", 180697)]
        [InlineData("Examples.example5.txt", 2210736)]
        [InlineData("Examples.own1.txt", 30)]
        public void CalculateRequiredOre(string file, int oreQuantity)
        {
            var sut = new ReactionsBook(EmbeddedResources.ReadLines<string>(GetType(), file));
            var requiredIngredients = sut.RequiredIngredients(new Ingredient { Quantity = 1, Type = "FUEL" });

            var noOfOres = 0;
            foreach (var ingredient in requiredIngredients)
            {
                noOfOres += sut.RequiredOres(ingredient);
            }

            Assert.Equal(oreQuantity, noOfOres);
        }
    }
}
