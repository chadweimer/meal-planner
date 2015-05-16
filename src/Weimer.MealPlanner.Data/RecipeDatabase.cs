using NDatabase.Api;
using System;

namespace Weimer.MealPlanner.Data
{
    /// <summary>
    /// Represents the underlying database behind the application.
    /// </summary>
    public sealed class RecipeDatabase : IDisposable
    {
        private const string DATABASE_FILE_NAME = "RecipeDb.ndb";
        private readonly IOdb _odb;

        private RecipeDatabase()
        {
            _odb = NDatabase.OdbFactory.Open(DATABASE_FILE_NAME);
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
            return new RecipeDatabase();
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
