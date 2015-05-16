using QuantityTypes;

namespace Weimer.MealPlanner.Shared.Model
{
    public class Ingredient
    {
        public string Name { get; set; }

        public IQuantity Quantity { get; set; }
    }
}
