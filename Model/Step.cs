using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    internal class Step //internal class Step
    {

        public string Description { get; set; } // Property Description

        public Step(string description) // Constructor
        {
            Description = description; // Initialize the Description property
        }
    }
}
