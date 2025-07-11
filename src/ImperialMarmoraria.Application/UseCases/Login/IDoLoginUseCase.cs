using ImperialMarmoraria.Communication.Requests.Login;
using ImperialMarmoraria.Communication.Responses.User;

namespace ImperialMarmoraria.Application.UseCases.Login;
public interface IDoLoginUseCase
{
    Task<ResponseUserJson> Execute(RequestLoginJson request);
}