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


public class Program
{
    static List<Recipe> recipes = new List<Recipe>();
    static Dictionary<string, List<Ingredient>> originalIngredientsMap = new Dictionary<string, List<Ingredient>>();

    static void Main(string[] args)
    {
        while (true)
        {
            DisplayMenu();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Recipe newRecipe = EnterRecipe();
                    if (newRecipe != null)
                    {
                        recipes.Add(newRecipe);
                        originalIngredientsMap[newRecipe.Title] = new List<Ingredient>(newRecipe.Ingredients);
                    }
                    break;

                case "2":
                    DisplayAllRecipes();
                    break;

                case "3":
                    DisplayRecipeByName();
                    break;

                case "4":
                    ScaleRecipe();
                    break;

                case "5":
                    ResetRecipeQuantities();
                    break;

                case "6":
                    ClearData();
                    break;

                case "7":
                    Console.WriteLine("Exiting the application");
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option, please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nRecipe App Menu:");
        Console.ResetColor();
        Console.WriteLine("1. Enter a new recipe");
        Console.WriteLine("2. Display all recipes");
        Console.WriteLine("3. Display a specific recipe");
        Console.WriteLine("4. Scale a recipe");
        Console.WriteLine("5. Reset recipe quantities");
        Console.WriteLine("6. Clear data and enter a new recipe");
        Console.WriteLine("7. Exit");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Choose an option: ");
        Console.ResetColor();
    }

    static Recipe EnterRecipe()
    {
        
            Console.Write("\nEnter the recipe title: ");
            string title = Console.ReadLine();
            Recipe recipe = new Recipe(title);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid positive number.");
                Console.ResetColor();
                Console.Write("Enter the number of ingredients: ");
            }

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write("\nEnter Ingredient name: ");
                string ingredientName = Console.ReadLine();

                Console.Write("Enter the quantity of the ingredient: ");
                double ingredientQuantity;
                while (!double.TryParse(Console.ReadLine(), out ingredientQuantity) || ingredientQuantity <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid quantity greater than zero.");
                    Console.ResetColor();
                    Console.Write("Enter the quantity of the ingredient: ");
                }

                Console.Write("Enter unit of measurement: ");
                string ingredientUnit = Console.ReadLine();

                Console.Write("Enter calories: ");
                int calories;
                while (!int.TryParse(Console.ReadLine(), out calories) || calories < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid non-negative number of calories.");
                    Console.ResetColor();
                    Console.Write("Enter calories: ");
                }

                Console.Write("Enter food group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, ingredientUnit, calories, foodGroup);
                recipe.AddIngredient(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid positive number.");
                Console.ResetColor();
                Console.Write("Enter the number of steps: ");
            }

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"\nEnter description for step {i + 1}: ");
                string stepDescription = Console.ReadLine();
                Step step = new Step(stepDescription);
                recipe.AddStep(step);
            }

            recipe.onCalorieAlert += (message) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            };

            Console.WriteLine("\nRecipe entered successfully!");
            return recipe;
        }

    

    static void DisplayAllRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No recipes available");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nAll Recipes:");
        Console.ResetColor();

        foreach (var recipe in recipes.OrderBy(r => r.Title))
        {
            Console.WriteLine(recipe.Title);
        }
    }

    static void DisplayRecipeByName()
    {
        Console.Write("Enter the name of the recipe to display: ");
        string name = Console.ReadLine();

        Recipe recipe = recipes.FirstOrDefault(r => r.Title.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (recipe != null)
        {
            recipe.Display();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Recipe not found.");
            Console.ResetColor();
        }
    }

    static void ScaleRecipe()
    {
        Console.Write("Enter the name of the recipe to scale: ");
        string name = Console.ReadLine();

        Recipe recipe = recipes.FirstOrDefault(r => r.Title.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (recipe != null)
        {
            Console.Write("Enter the scaling factor (e.g., 0.5, 2, 3): ");
            double factor = double.Parse(Console.ReadLine());
            recipe.Scale(factor);
            Console.WriteLine("Recipe scaled successfully.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Recipe not found.");
            Console.ResetColor();
        }
    }

    static void ResetRecipeQuantities() // Reset the quantities of the recipe
    {
        Console.Write("Enter the name of the recipe to reset: ");
        string name = Console.ReadLine();

        Recipe recipe = recipes.FirstOrDefault(r => r.Title.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (recipe != null && originalIngredientsMap.ContainsKey(name)) // Check if the recipe exists and the original ingredients are available
        {
            recipe.Reset(originalIngredientsMap[name]);
            Console.WriteLine("Recipe quantities have been reset to original.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Recipe not found.");
            Console.ResetColor();
        }
    }

    static void ClearData()
    {
        recipes.Clear();
        originalIngredientsMap.Clear();
        Console.WriteLine("Data cleared, you can enter a new recipe!");
    }
}
 