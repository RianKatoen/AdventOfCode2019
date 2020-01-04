using AOC2019.Modules.Fuel.NanoFactories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AOC2019.Modules.Fuel.Tests.NanoFactories
{
    public class UTReaction
    {
        public class ReactionsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    "9 ORE => 2 A",
                    new List<Ingredient> {
                        new Ingredient { Quantity = 9, Type = "ORE" }
                    },
                    new Ingredient { Quantity = 2, Type = "A" }
                };

                yield return new object[] {
                    "5 B, 7 C => 1 BC",
                    new List<Ingredient> {
                        new Ingredient { Quantity = 5, Type = "B" },
                        new Ingredient { Quantity = 7, Type = "C" }
                    },
                    new Ingredient { Quantity = 1, Type = "BC" }
                };

                yield return new object[] {
                    "2 AB, 3 BC, 4 CA => 1 FUEL",
                    new List<Ingredient> {
                        new Ingredient { Quantity = 2, Type = "AB" },
                        new Ingredient { Quantity = 3, Type = "BC" },
                        new Ingredient { Quantity = 4, Type = "CA" }
                    },
                    new Ingredient { Quantity = 1, Type = "FUEL" }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory(DisplayName = "Testing new reaction from required quantity.")]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(9, 1)]
        [InlineData(10, 1)]
        [InlineData(11, 2)]
        [InlineData(28, 3)]
        public void TestingNewReactionFromRequiredQuantity(int requiredQuantity, int resultingQuantity)
        {
            var result = new Ingredient { Quantity = 10, Type = "D" };
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Quantity = 0 , Type = "A" },
                new Ingredient { Quantity = 2 , Type = "B" },
                new Ingredient { Quantity = 3 , Type = "C" }
            };

            var sut = new Reaction(ingredients, result);

            var reaction = sut.FromRequiredQuantity(requiredQuantity);
            Assert.NotSame(sut, reaction);
            Assert.Equal(resultingQuantity * result, reaction.Result);
            Assert.Equal(ingredients.Select(i => resultingQuantity * i).ToList(), reaction.Ingredients);
        }
    }
}
