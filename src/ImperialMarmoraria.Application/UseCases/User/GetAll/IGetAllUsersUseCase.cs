using ImperialMarmoraria.Communication.Responses.User;

namespace ImperialMarmoraria.Application.UseCases.User.GetAll
{
    public interface IGetAllUsersUseCase
    {
        Task<ResponseGetUsersJson> Execute();
    }
}
