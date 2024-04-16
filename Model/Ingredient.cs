using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    internal class Ingredient // internal class Ingredient
    {

        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit) //Constructor
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public void Scale(double factor) // Method to scale the quantity of the ingredient
        { 
            Quantity *= factor;
        }
    }
}
