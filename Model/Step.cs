using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    internal class Step
    {

        public string Description { get; set; }

        public Step(string description)
        {
            Description = description;
        }
    }
}
