using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantityTypes;

namespace Weimer.MealPlanner.Shared.Model
{
    public class Ingredient
    {
        public string Name { get; set; }

        public IQuantity Quantity { get; set; }
    }
}
