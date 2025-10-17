using ImperialMarmoraria.Communication.Requests.User;

namespace ImperialMarmoraria.Application.UseCases.User.ChangePassword
{
    public interface IChangePasswordUseCase
    {
        Task Execute(RequestChangePasswordJson request);
    }
}
