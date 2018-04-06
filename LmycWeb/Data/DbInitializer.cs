using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Boats.
            if (context.Boats.Any())
            {
                return;   // DB has been seeded
            }
        }
    }
}
