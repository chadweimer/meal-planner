using System.Collections.Generic;

namespace Weimer.MealPlanner.Core.Model
{
    /// <summary>
    /// Represents a recipe.
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> class.
        /// </summary>
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Directions = new List<string>();
        }

        /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the recipe.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets a collection of <see cref="Ingredient"/> instances in this recipe.
        /// </summary>
        /// <value>
        /// The ingredients.
        /// </value>
        public IList<Ingredient> Ingredients { get; private set; }

        /// <summary>
        /// Gets a collection of directions or steps to perform the recipe.
        /// </summary>
        /// <value>
        /// The directions.
        /// </value>
        public IList<string> Directions { get; private set; }
    }
}
