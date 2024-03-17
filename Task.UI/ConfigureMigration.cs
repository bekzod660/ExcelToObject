using MarketManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Task.UI
{
    public static class ConfigureMigration
    {
        public static void AutoMigration(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            ApplicationDbContext? db = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if(db == null) 
            {
                throw new Exception("Database not found");
                
            }

            try
            {
                db.Database.Migrate();
            }

            catch(Exception ex)
            {
                throw new Exception($"Migration error: {ex.Message}", ex);   
            }
        }
           
    }
}
