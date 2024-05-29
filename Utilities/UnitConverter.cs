using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApplication.Model;

namespace RecipeApplication.Utilities
{
    internal class UnitConverter
    {
        private static readonly Dictionary<string, double> ConversionFactors = new Dictionary<string, double>
    {
        { "tablespoon to cup", 1.0 / 16 }, // 16 tablespoons = 1 cup
        { "teaspoon to tablespoon", 1.0 / 3 }, // 3 teaspoons = 1 tablespoon
        // Add more conversions as needed
    };

        public static (double quantity, string unit) Convert(double quantity, string unit)
        {
            foreach (var conversion in ConversionFactors)
            {
                var parts = conversion.Key.Split(" to ");
                var fromUnit = parts[0];
                var toUnit = parts[1];
                var factor = conversion.Value;

                if (unit == fromUnit)
                {
                    quantity *= factor;
                    unit = toUnit;
                    break; 
                }
            }
            return (quantity, unit);
        }
    }
}
