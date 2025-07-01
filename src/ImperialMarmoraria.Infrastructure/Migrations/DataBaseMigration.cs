using ImperialMarmoraria.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ImperialMarmoraria.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public static async Task MigrationDataBase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<ImperialMarmorariaDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
