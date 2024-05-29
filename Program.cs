// See https://aka.ms/new-console-template for more information

//Wadiha Boat
//ST10303285
//GROUP 2 
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0163?f1url=%3FappId%3Droslyn%26k%3Dk(CS0163)
//https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
//https://docs.github.com/en/get-started/using-git/pushing-commits-to-a-remote-repository
//https://www.w3schools.com/git/git_commit.asp?remote=github
using System;
using RecipeApplication.Model;
using System.Collections.Generic;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        // Create a new recipe object
        Recipe currentRecipe = null;
        Ingredient[] originalIngredients = null;

        while (true)
        {
            // Display the menu
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nRecipe App Menu:");
            Console.ResetColor();
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display the current recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Reset Recipe quantities");
            Console.WriteLine("5. Clear data and enter a new recipe");
            Console.WriteLine("6. Exit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Choose an option:");
            Console.ResetColor();
            string option = Console.ReadLine();

            switch (option)
            {    //If user chooses option 1 
                // Enter a new recipe
                case "1":
                    currentRecipe = EnterRecipe();
                    if (currentRecipe != null)
                    {
                        originalIngredients = new Ingredient[currentRecipe.Ingredients.Length];

                        for (int i = 0; i < currentRecipe.Ingredients.Length; i++)
                        {
                            // Copy the ingredients to the originalIngredients array
                            // Check that the current ingredient is not null before copying
                            if (currentRecipe.Ingredients[i] != null)
                            {
                                originalIngredients[i] = new Ingredient(
                                    currentRecipe.Ingredients[i].Name,
                                    currentRecipe.Ingredients[i].Quantity,
                                    currentRecipe.Ingredients[i].Unit
                                );
                            }

                        }
                    }

                    break;

                case "2": // Display the current recipe
                    if (currentRecipe != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nCurrent Recipe:");
                        Console.ResetColor();
                        currentRecipe.Display();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No recipe available");
                        Console.ResetColor();
                    }
                    break;

                case "3": // Scale the recipe
                    if (currentRecipe != null)
                    {
                        ScaleRecipe(currentRecipe);
                    }
                    else // If there is no recipe available
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No recipe available.");
                        Console.ResetColor();
                    }
                    break;

                case "4": // Reset Recipe quantities
                    if (currentRecipe != null) // Check if there is a recipe available
                    {
                        currentRecipe.Reset(originalIngredients); // Reset the recipe quantities
                        Console.WriteLine("Recipe quantities have been reset to original ");
                        Console.WriteLine("\nCurrent recipe with original quantities");
                        currentRecipe.Display();
                    }
                    else // If there is no recipe available
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No recipe found!");
                        Console.ResetColor();
                    }
                    break;

                case "5": // Clear data and enter a new recipe
                    currentRecipe = null;
                    originalIngredients = null;
                    Console.WriteLine("Data cleared, you can enter a new recipe!");
                    break;

                case "6": // Exit the application
                    Console.WriteLine("Exiting the application");
                    return;

                default: // If the user enters an invalid option
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option, please try again.");
                    Console.ResetColor();
                    break;




            }
        }
    }
    static Recipe EnterRecipe() // Method to enter a new recipe
    {
        try
        {
            Console.Write("\nEnter the recipe title: ");
            string title = Console.ReadLine();
            Recipe recipe = new Recipe(title);

            Console.Write("Enter the number of ingredients: ");
            if (!int.TryParse(Console.ReadLine(), out int numIngredients) || numIngredients <= 0)
            {
                throw new ArgumentException("Number of ingredients must be a positive integer.");
            }

            recipe.Ingredients = new Ingredient[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("\nEnter Ingredient name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Enter the quantity of the ingredient: ");
                if (!double.TryParse(Console.ReadLine(), out double ingredientQuantity) || ingredientQuantity <= 0)
                {
                    throw new ArgumentException("Quantity must be a positive number.");
                }
                Console.Write("Enter unit of measurement: ");
                string ingredientUnit = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, ingredientUnit);
                recipe.AddIngredient(ingredient);
            }

            Console.Write("\nEnter the number of steps: ");
            if (!int.TryParse(Console.ReadLine(), out int numSteps) || numSteps <= 0)
            {
                throw new ArgumentException("Number of steps must be a positive integer.");
            }

            recipe.Steps = new Step[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nEnter description for step {i + 1}: ");
                string stepDescription = Console.ReadLine();
                Step step = new Step(stepDescription);
                recipe.AddStep(step);
            }

            Console.WriteLine("\nRecipe entered successfully!");
            return recipe;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
            return null;
        }
    }

    static void ScaleRecipe(Recipe currentRecipe)
    {
        try
        {
            Console.WriteLine("Enter the scaling factor (e.g., 0.5, 2, or 3): ");
            if (!double.TryParse(Console.ReadLine(), out double factor) || factor <= 0)
            {
                throw new ArgumentException("Scaling factor must be a positive number.");
            }
           currentRecipe.Scale(factor);
            Console.WriteLine("Recipe scaled successfully.");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
        }
    }

}
