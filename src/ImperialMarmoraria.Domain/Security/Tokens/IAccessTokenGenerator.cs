using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
