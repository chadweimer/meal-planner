using NDatabase.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weimer.MealPlanner.Data
{
    public sealed class RecipeDatabase : IDisposable
    {
        private const string DATABASE_FILE_NAME = "RecipeDb.ndb";
        private readonly IOdb _odb;

        private RecipeDatabase()
        {
            _odb = NDatabase.OdbFactory.Open(DATABASE_FILE_NAME);
        }

        public static RecipeDatabase Open()
        {
            return new RecipeDatabase();
        }

        ~RecipeDatabase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }
        
        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_odb != null)
                {
                    _odb.Dispose();
                }
            }
        }
    }
}
