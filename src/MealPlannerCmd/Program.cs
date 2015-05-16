using Ookii.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weimer.MealPlanner.Core.Model;
using Weimer.MealPlanner.Data;

namespace MealPlannerCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineArguments parsedArgs;
            var argsParser = new CommandLineParser(typeof(CommandLineArguments));
            try
            {
                parsedArgs = (CommandLineArguments)argsParser.Parse(args);
            }
            catch (CommandLineArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                argsParser.WriteUsageToConsole();
                return;
            }

            using (var db = RecipeDatabase.Open())
            {
                switch (parsedArgs.Operation)
                {
                    case CommandLineOperation.Add:
                        {
                            var recipes = db.GetAllRecipes();
                            var matchingRecipe = recipes.FirstOrDefault(r => r.Name == parsedArgs.RecipeName);
                            if (matchingRecipe == null)
                            {
                                db.SaveRecipe(new Recipe { Name = parsedArgs.RecipeName });
                            }
                            else
                            {
                                Console.WriteLine("There is already a recipe named {0}", parsedArgs.RecipeName);
                            }
                        }
                        break;
                    case CommandLineOperation.Rename:
                        {
                            var recipes = db.GetAllRecipes();
                            var matchingRecipe = recipes.FirstOrDefault(r => r.Name == parsedArgs.RecipeName);
                            if (matchingRecipe != null)
                            {
                                matchingRecipe.Name = parsedArgs.NewRecipeName;
                                db.SaveRecipe(matchingRecipe);
                            }
                            else
                            {
                                Console.WriteLine("Could not locate recipe named {0}", parsedArgs.RecipeName);
                            }
                        }
                        break;
                    case CommandLineOperation.Delete:
                        {
                            var recipes = db.GetAllRecipes();
                            var matchingRecipe = recipes.FirstOrDefault(r => r.Name == parsedArgs.RecipeName);
                            if (matchingRecipe != null)
                            {
                                db.DeleteRecipe(matchingRecipe);
                            }
                            else
                            {
                                Console.WriteLine("Could not locate recipe named {0}", parsedArgs.RecipeName);
                            }
                        }
                        break;
                    case CommandLineOperation.List:
                        {
                            var recipes = db.GetAllRecipes();
                            foreach(var recipe in recipes)
                            {
                                Console.WriteLine(recipe.ToString());
                            }
                        }
                        break;
                }
            }
        }
    }
}
