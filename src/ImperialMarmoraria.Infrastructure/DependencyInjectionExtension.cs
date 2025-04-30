using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Infrastructure.DataAcess;
using ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImperialMarmoraria.Infrastructure;
public static class DependencyInjectionExtension
{   public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IOrcamentosRepository, OrcamentosRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
    }


    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 41);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<ImperialMarmorariaDbContext>(
            config => config.UseMySql(connectionString, serverVersion));
    }
}
