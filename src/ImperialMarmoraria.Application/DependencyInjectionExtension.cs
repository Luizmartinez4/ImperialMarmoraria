using ImperialMarmoraria.Application.AutoMapper;
using ImperialMarmoraria.Application.UseCases.Email;
using ImperialMarmoraria.Application.UseCases.Login;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetByName;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetByStatus;
using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
using ImperialMarmoraria.Application.UseCases.Orcamento.Remove;
using ImperialMarmoraria.Application.UseCases.Orcamento.Update;
using ImperialMarmoraria.Application.UseCases.User.Delete;
using ImperialMarmoraria.Application.UseCases.User.GetAll;
using ImperialMarmoraria.Application.UseCases.User.Register;
using ImperialMarmoraria.Application.UseCases.User.Update;
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
        services.AddScoped<IRemoveOrcamentoUseCase, RemoveOrcamentoUseCase>();
        services.AddScoped<IGetOrcamentoByStatusUseCase, GetOrcamentoByStatusUseCase>();
        services.AddScoped<IGetOrcamentoByNameUseCase, GetOrcamentoByNameUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IRemoveUserUseCase, RemoveUserUseCase>();
        services.AddTransient<IEmailUseCase, EmailUseCase>();
    }
}
