using ImperialMarmoraria.Application.AutoMapper;
using ImperialMarmoraria.Application.UseCases.Email;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
using ImperialMarmoraria.Application.UseCases.Orcamento.Update;
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

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistraOrcamento, RegistraOrcamento>();
        services.AddScoped<IGetAllOrcamentos, GetAllOrcamentos>();
        services.AddScoped<IUpdateOrcamentoUseCase, UpdateOrcamentoUseCase>();
        services.AddTransient<IEmailUseCase, EmailUseCase>();
    }
}
