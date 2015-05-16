using QuantityTypes;

namespace Weimer.MealPlanner.Core.Model
{
    /// <summary>
    /// Represents an ingredient in a recipe.
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Gets or sets the name of the ingredient.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the ingredient.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public IQuantity Quantity { get; set; }
    }
}
