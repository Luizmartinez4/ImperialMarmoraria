using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.User;

namespace ImperialMarmoraria.Application.UseCases.User.Update
{
    public interface IUpdateUserUseCase
    {
        Task<ResponseUpdatedUserJson> Execute(RequestUpdateUserJson request, long id);
    }
}
