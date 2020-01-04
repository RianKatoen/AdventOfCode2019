using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Fuel.NanoFactories
{
    public class Reaction
    {
        private Ingredient ToIngredient(string ingredient)
        {
            var split = ingredient.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            return new Ingredient
            {
                Quantity = int.Parse(split[0]),
                Type = split[1].Trim()
            };
        }

        public Reaction(IEnumerable<Ingredient> ingredients, Ingredient result)
        {
            Ingredients = ingredients.ToList();
            Result = result;
        }

        public Reaction(string reaction)
        {
            var split = reaction.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
            var ingredients = new List<Ingredient>();
            foreach (var ingredient in split[0].Split(','))
            {
                ingredients.Add(ToIngredient(ingredient));
            }

            Ingredients = ingredients;
            Result = ToIngredient(split[1]);
        }

        public IReadOnlyList<Ingredient> Ingredients { get; }
        public Ingredient Result { get; }

        public Reaction FromRequiredQuantity(int quantity)
        {
            var requiredNoReactions =
                quantity <= Result.Quantity
                ? (quantity == 0 ? 0 : 1)
                : (quantity / Result.Quantity) + (quantity % Result.Quantity > 0 ? 1 : 0);

            return new Reaction(Ingredients.Select(i => requiredNoReactions * i), requiredNoReactions * Result);
        }
    }
}
