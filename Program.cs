// See https://aka.ms/new-console-template for more information
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
            Console.WriteLine("\nRecipe App Menu:");
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
                            else
                            {
                                // Handle the case when an ingredient is null (optional, depends on use case)

                            }
                        }
                    }

                    break;

                case "2": // Display the current recipe
                    if (currentRecipe != null)
                    {
                        Console.WriteLine("\nCurrent Recipe:");
                        currentRecipe.Display();
                    }
                    else
                    {
                        Console.WriteLine("No recipe available");
                    }
                    break;

                case "3": // Scale the recipe
                    if (currentRecipe != null)
                    {
                        ScaleRecipe(currentRecipe);
                    }
                    else // If there is no recipe available
                    {
                        Console.WriteLine("No recipe available.");
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

                case "6":
                    Console.WriteLine("Exiting the application");
                    return;

                default:
                    Console.WriteLine("Invalid Option, please try again.");
                    break;




            }
        }
    }
    static Recipe EnterRecipe()
    {
        Console.Write("\nEnter the recipe title:");
        string title = Console.ReadLine();
        Recipe recipe = new Recipe(title);

        Console.Write("Enter the number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());
        if (recipe.Ingredients != null)
        {
            recipe.Ingredients = new Ingredient[numIngredients];
        }

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write("\nEnter Ingredient name: ");
            string ingredientName = Console.ReadLine();

            Console.Write("Enter the quantity of the ingredient: ");
            double ingredientQuantity = double.Parse(Console.ReadLine());

            Console.Write("Enter unit of measurement: ");
            string ingredientUnit = Console.ReadLine();

            Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, ingredientUnit);
            recipe.AddIngredient(ingredient);
        }

        Console.Write("\nEnter the number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());
        if (numSteps != 0)
        {
            recipe.Steps = new Step[numSteps];
        }
        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"\nEnter description for step{i + 1}: ");
            string stepDescription = Console.ReadLine();
            Step step = new Step(stepDescription);
            recipe.AddStep(step);
        }


        Console.WriteLine("\nRecipe entered sucessfully!");
        return recipe;
    }

    static void ScaleRecipe(Recipe recipe)
    {
        Console.WriteLine("Enter the scaling factor (0.5 , 2, or 3):");
        double factor = double.Parse(Console.ReadLine());
        recipe.Scale(factor);
        Console.WriteLine("Recipe scaled successfully.");
    }
}
