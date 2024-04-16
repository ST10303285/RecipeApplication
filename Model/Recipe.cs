using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    internal class Recipe // internal class Recipe
    { 
        public string Title { get; set; } 
        public Ingredient[]Ingredients { get; set; }
        public Step[]Steps { get;set; }

        private int ingredientCount; 
        private int stepCount;
         
        public Recipe(string title) // Constructor
        {
            Title = title;
            Ingredients = new Ingredient[  50]; // Array of Ingredients
            Steps = new Step[50]; //Array of Steps
            ingredientCount = 0;
            stepCount = 0;
        }

        public Recipe(Recipe otherRecipe)
        {
            if (otherRecipe==null)
                throw new ArgumentNullException(nameof(otherRecipe),"Other recipe cannot be null.");

            Title = otherRecipe.Title;

            Ingredients = new Ingredient[otherRecipe.Ingredients.Length];
            
            for (int i=1;i<otherRecipe.Ingredients.Length;i++)
            {
                if (otherRecipe.Ingredients[i] == null)
                {
                    Ingredients[i] = new Ingredient(otherRecipe.Ingredients[i].Name, otherRecipe.Ingredients[i].Quantity, otherRecipe.Ingredients[i].Unit);
                }
               
            }

            Steps = new Step[otherRecipe.Steps.Length];
            
            for (int i =0; i<otherRecipe.Steps.Length; i++)
            {
                if (otherRecipe.Steps[i] == null)
                {
                    Steps[i] = new Step(otherRecipe.Steps[i].Description);
                }
            }
        }

        public void AddIngredient(Ingredient ingredient)
        {
            if(ingredientCount< Ingredients.Length)
            {
                Ingredients[ingredientCount] = ingredient;
                ingredientCount++;
            }
            else
            {
                Console.WriteLine("Unable to add more ingredients. ");
            }
        }

        public void AddStep(Step step)
        {
            if(stepCount <Steps.Length)
            {
                Steps[stepCount] = step;    
                stepCount++;
            }
            else
            {
                Console.WriteLine("Unable to add more steps.");
            }
        }

        public void Display()
        {
            Console.WriteLine($"\nRecipe: {Title}");
            Console.WriteLine("\nIngredients:");

            for (int i = 0;i< ingredientCount; i++)
            {
                Console.WriteLine($"-{Ingredients[i].Quantity}{Ingredients[i].Unit} of {Ingredients[i].Name}");

            }
            Console.WriteLine("\nSteps:");
            for(int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"{i + 1}.{Steps[i].Description}");
            }
        }

        public void Scale(double factor)
        {
            for(int i=0; i<ingredientCount;i++)
            {
                Ingredients[i].Quantity *= factor;
            }
        }
        public void Reset(Ingredient[] originalIngredients)
        {
            Console.WriteLine("Original Ingredients:");
            for (int i = 0; i < originalIngredients.Length; i++)
            {
                Console.WriteLine($"{originalIngredients[i].Quantity} {originalIngredients[i].Unit} of {originalIngredients[i].Name}");
            }

            // Check that lengths match
            if (originalIngredients.Length != ingredientCount)
            {
                Console.WriteLine("The original ingredients list does not match the current recipe.");
                return;
            }

            // Reset each ingredient quantity
            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredients[i].Quantity = originalIngredients[i].Quantity;
            }

            // Debug print statement: Check current ingredients array after reset
            Console.WriteLine("Current Ingredients after Reset:");
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"{Ingredients[i].Quantity} {Ingredients[i].Unit} of {Ingredients[i].Name}");
            }

            Console.WriteLine("Recipe quantities have been reset to original.");
        }
    }

 }



