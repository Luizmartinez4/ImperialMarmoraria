using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Services.LoggedUser
{
    public interface ILoggedUser
    {
        Task<User> Get();
    }
}
