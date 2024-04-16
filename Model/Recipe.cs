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
            ingredientCount = 0; // Initialize ingredient count to 0
            stepCount = 0; // Initialize step count to 0
        }

        public Recipe(Recipe otherRecipe) // Copy Constructor
        {
            if (otherRecipe==null) // Check if otherRecipe is null
                throw new ArgumentNullException(nameof(otherRecipe),"Other recipe cannot be null.");

            Title = otherRecipe.Title; // Copy the title

            Ingredients = new Ingredient[otherRecipe.Ingredients.Length]; // Copy the ingredients
            
            for (int i=1;i<otherRecipe.Ingredients.Length;i++) // Loop through the ingredients
            {
                if (otherRecipe.Ingredients[i] == null) // Check if the ingredient is null
                {
                    Ingredients[i] = new Ingredient(otherRecipe.Ingredients[i].Name, otherRecipe.Ingredients[i].Quantity, otherRecipe.Ingredients[i].Unit);
                }
               
            }

            Steps = new Step[otherRecipe.Steps.Length]; // Copy the steps
            
            for (int i =0; i<otherRecipe.Steps.Length; i++) // Loop through the steps
            {
                if (otherRecipe.Steps[i] == null) // Check if the step is null
                {
                    Steps[i] = new Step(otherRecipe.Steps[i].Description); // Copy the step
                }
            }
        }

        public void AddIngredient(Ingredient ingredient) // Method to add an ingredient
        {
            if(ingredientCount< Ingredients.Length) // Check if the ingredient count is less than the length of the Ingredients array
            {
                Ingredients[ingredientCount] = ingredient; // Add the ingredient to the Ingredients array
                ingredientCount++; // Increment the ingredient count
            }
            else // If the ingredient count is greater than the length of the Ingredients array
            {
                Console.WriteLine("Unable to add more ingredients. ");
            }
        }

        public void AddStep(Step step) // Method to add a step
        {
            if(stepCount <Steps.Length)     // Check if the step count is less than the length of the Steps array
            {
                Steps[stepCount] = step;     // Add the step to the Steps array
                stepCount++;                // Increment the step count
            }
            else // If the step count is greater than the length of the Steps array
            {
                Console.WriteLine("Unable to add more steps.");
            }
        }

        public void Display() // Method to display the recipe
        {
            Console.ForegroundColor = ConsoleColor.Yellow ;
            Console.WriteLine($"\nRecipe: {Title}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();

            for (int i = 0;i< ingredientCount; i++) 
            {
                Console.WriteLine($"-{Ingredients[i].Quantity}{Ingredients[i].Unit} of {Ingredients[i].Name}");

            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();
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



