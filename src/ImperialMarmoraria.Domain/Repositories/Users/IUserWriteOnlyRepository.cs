using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Users;
public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
