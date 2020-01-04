using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.Fuel.NanoFactories
{
    public class ReactionsBook : IEnumerable<Reaction>
    {
        public ReactionsBook(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var reaction = new Reaction(line);
                _reactions[reaction.Result.Type] = reaction;
            }
        }

        private readonly Dictionary<string, Reaction> _reactions = new Dictionary<string, Reaction>();

        public int Count => _reactions.Count;

        public IEnumerator<Reaction> GetEnumerator() => ((IEnumerable<Reaction>)_reactions.Values).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Reaction>)_reactions.Values).GetEnumerator();

        public IEnumerable<Ingredient> RequiredIngredients(Ingredient result)
        {
            var reaction = _reactions[result.Type].FromRequiredQuantity(result.Quantity);
            var requiredIngredients = new Dictionary<string, Ingredient>();

            var ingredients = reaction.Ingredients;
            foreach (var ingredient in ingredients)
            {
                if (_reactions.TryGetValue(ingredient.Type, out var ingredientReaction))
                {
                    var scaledReaction = ingredientReaction.FromRequiredQuantity(ingredient.Quantity);
                    var wut = RequiredIngredients(scaledReaction.Result).ToList();
                    wut.Add(ingredient);
                    foreach (var wut2 in wut)
                    {
                        if (requiredIngredients.ContainsKey(wut2.Type))
                        {
                            requiredIngredients[wut2.Type] += wut2.Quantity;
                        }
                        else
                        {
                            requiredIngredients[wut2.Type] = wut2;
                        }
                    }
                }
            }

            return requiredIngredients.Values;
        }

        public int RequiredOres(Ingredient result)
        {
            var reaction = _reactions[result.Type].FromRequiredQuantity(result.Quantity);
            if(reaction.Ingredients.Count == 1)
            {
                var ingredient = reaction.Ingredients.First();
                if(ingredient.Type == "ORE")
                {
                    return ingredient.Quantity;
                }
            }

            return 0;
        }
    }
}
