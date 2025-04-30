using ImperialMarmoraria.Application.AutoMapper;
using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
using Microsoft.Extensions.DependencyInjection;

namespace ImperialMarmoraria.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    public static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistraOrcamento, RegistraOrcamento>();
    }
}
