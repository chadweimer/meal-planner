using System.Collections.Generic;

namespace Weimer.MealPlanner.Shared.Model
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Ingredient> Ingredients { get; private set; }
        public IList<string> Directions { get; private set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Directions = new List<string>();
        }
    }
}
