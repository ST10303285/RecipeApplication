Recipe Application

## Table of Contents
	- [Description](#description))
	- [Features](#features)
	- [Setup](#setup)
	- [Usage](#usage)
	- [Running Tests](#running-tests)
	- [License](#license))

## Description:
The recipe application allows users to enter, manage, and scale recipes. Users can innput ingredients, including their quantities, units, calories and food groups. The application also calculates the total calories of a recipe and alerts the user if the total exceeds 300 calories.

## Features:
- Add an unlimited number of recipes.
- Store additional information for each ingredient: calories and food group.
- Display a list of all recipes in alphabetical order by name.
- Choose and display a specific recipe from the list.
- Scale recipes by a given factor.
- Reset recipe quantities to original values.
- Calculate and display the total calories of all ingredients in a recipe.
- Notify the user when the total calories of a recipe exceed 300.
- Use generic collections for storing recipes, ingredients, and steps.
- Unit tests to verify the total calorie calculation functionality.

## Setup:
   a. Clone the Repository using the following command line:
	git clone<repository-https://github.com/ST10303285/RecipeApplication.git>
	cd recipe-application
   b. Open the project in Visual Studio
	Open Visual Studio
	Select 'Open a project or solution'
	Navigate to the 'recipe-application' directory and select 'RecipeApplication.s1n'.
   c. Go to 'Build' and select 'Restore NuGet Packages'.

## Usage:
To use the Recipe Application:
   1.Run the application:
	Press 'F5' or go to 'Debug' then 'Start Debugging'.
   2.Follow the menu options:
	-Enter a new recipe.
	-Display the current recipe.
	-Scale the recipe.
	-Reset recipe quantities.
	-Clear data and enter a new recipe.
	-Exit the application.

## Running Tests:
Unit tests are provided to verify the total calorie calculation functionality. To run the tests:
    1. Open Test Explorer:
	-Go to 'Test;+' and then 'Test Explorer'
    2. Run All Tests:
	-Click 'Run All' in the Test Explorer' window.
    3. Verify Results:
	-Ensure all tests pass and no errors are reported.

## License:
This project is licensed under the MIT License. 
___________________________________________________________________________________________

Based on my lecturer's feedback, I made several improvements to my recipe application:

Error Handling: I added error handling to manage null values and incorrect value types, ensuring the program provides meaningful error messages. For instance, I included checks and error messages for invalid inputs when entering ingredient quantities and scaling factors.

Code Organization: I improved the code structure by adding separator lines between methods, meaningful comments, and ensuring a blank line at the end of the file. Additionally, I split the classes into separate files to enhance readability and maintainability.

Functional Enhancements: I ensured that units of measurement remain consistent when scaling recipe quantities, and the scaling logic only affects numerical values.

These changes collectively improved the robustness, readability, and maintainability of the application, aligning it with best practices and making it more user-friendly.
___________________________________________________________________________________________

Link to Github Repository:
https://github.com/ST10303285/RecipeApplication.git
___________________________________________________________________________________________
References:
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/cs0163?f1url=%3FappId%3Droslyn%26k%3Dk(CS0163)
https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs1503?f1url=%3FappId%3Droslyn%26k%3Dk(CS1503)
https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays
https://docs.github.com/en/get-started/using-git/pushing-commits-to-a-remote-repository
https://www.w3schools.com/git/git_commit.asp?remote=github
https://www.tutorialsteacher.com/csharp/csharp-delegates
https://www.geeksforgeeks.org/c-sharp-delegates/
https://www.c-sharpcorner.com/article/a-basic-introduction-of-unit-test-for-beginners/
https://learn.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest



