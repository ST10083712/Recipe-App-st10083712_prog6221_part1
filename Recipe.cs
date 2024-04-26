using Recipe_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    class Recipe
    {
        private Ingredient[] ingredients;
        private Step[] steps;

        public Recipe()
        {
            ingredients = null;
            steps = null;
        }

        public void InputRecipeDetails()
        {
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());
            ingredients = new Ingredient[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter the name of the ingredient {i + 1}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter the quantity of the ingredient {i + 1}:");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter the quantity of measurement for the ingredient {i + 1}:");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());
            steps = new Step[stepCount];

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter description for step {i + 1}:");
                string description = Console.ReadLine();
                steps[i] = new Step { Description = description };
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Obtain the initial quantities of ingredients
            double[] originalQuantities = GetOriginalQuantities();

            //Restore each ingredient's quantity to its initial value.
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }
        }

        private double[] GetOriginalQuantities()
        {


            double[] originalQuantities = new double[ingredients.Length];
            for (int i = 0; i < ingredients.Length; i++)
            {

                originalQuantities[i] = ingredients[i].Quantity;
            }

            return originalQuantities;
        }


        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
        }
    }
}
