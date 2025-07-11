using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.User;

namespace ImperialMarmoraria.Application.UseCases.User.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseUserJson> Execute(RequestRegisterUserJson request);
}