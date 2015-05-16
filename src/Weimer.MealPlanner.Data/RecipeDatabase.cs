using NDatabase;
using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using Weimer.MealPlanner.Core.Model;

namespace Weimer.MealPlanner.Data
{
    /// <summary>
    /// Represents the underlying database behind the application.
    /// </summary>
    public sealed class RecipeDatabase : IDisposable
    {
        private const string DATABASE_FILE_NAME = "RecipeDb.ndb";
        private readonly IOdb _odb;

        private RecipeDatabase(IOdb odb)
        {
            _odb = odb;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RecipeDatabase"/> class.
        /// </summary>
        ~RecipeDatabase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Opens a connection to the database.
        /// </summary>
        /// <returns>An instance of <see cref="RecipeDatabase"/> that is ready to be queried.</returns>
        public static RecipeDatabase Open()
        {
            var db = new RecipeDatabase(OdbFactory.Open(DATABASE_FILE_NAME));
            db.Initialize();

            return db;
        }

        /// <summary>
        /// Opens a new database in memory.
        /// </summary>
        /// <returns>An instance of <see cref="RecipeDatabase"/> that is ready to be queried.</returns>
        public static RecipeDatabase OpenInMemory()
        {
            var db = new RecipeDatabase(OdbFactory.OpenInMemory());
            db.Initialize();

            return db;
        }

        private void Initialize()
        {
            if (!_odb.IndexManagerFor<Recipe>().ExistIndex("nameIndex"))
            {
                _odb.IndexManagerFor<Recipe>().AddUniqueIndexOn("nameIndex", new[] { "Name" });
            }
        }

        /// <summary>
        /// Gets all recipes.
        /// </summary>
        /// <returns>A collection of all <see cref="Recipe"/> objects stored in the database.</returns>
        public IList<Recipe> GetAllRecipes()
        {
            return _odb.AsQueryable<Recipe>().ToList();
        }

        /// <summary>
        /// Add or update the specified <see cref="Recipe"/> in the database.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public void SaveRecipe(Recipe recipe)
        {
            _odb.Store(recipe);
        }

        /// <summary>
        /// Deletes the specified <see cref="Recipe"/> from the database.
        /// </summary>
        /// <param name="recipe">The recipe.</param>
        public void DeleteRecipe(Recipe recipe)
        {
            _odb.Delete(recipe);
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_odb != null)
                {
                    _odb.Dispose();
                }
            }
        }
    }
}
