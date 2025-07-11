using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Domain.Repositories.Users;
using ImperialMarmoraria.Domain.Security.Cryptography;
using ImperialMarmoraria.Domain.Security.Tokens;
using ImperialMarmoraria.Infrastructure.DataAcess;
using ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
using ImperialMarmoraria.Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImperialMarmoraria.Infrastructure;
public static class DependencyInjectionExtension
{   public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        addToken(services, configuration);

        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
    }

    private static void addToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IOrcamentosWriteOnlyRepository, OrcamentosRepository>();
        services.AddScoped<IOrcamentosReadOnlyRepository, OrcamentosRepository>();
        services.AddScoped<IOrcamentosUpdateOnlyRepository, OrcamentosRepository>();
        services.AddScoped<IUsersReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
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
