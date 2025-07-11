using ImperialMarmoraria.Communication.Requests.Login;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Repositories.Users;
using ImperialMarmoraria.Domain.Security.Cryptography;
using ImperialMarmoraria.Domain.Security.Tokens;
using ImperialMarmoraria.Exception.ExceptionBase;

namespace ImperialMarmoraria.Application.UseCases.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUsersReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _tokenGenerator;

    public DoLoginUseCase(IUsersReadOnlyRepository repository, IPasswordEncripter passwordEncripter, IAccessTokenGenerator tokenGenerator)
    {
        _repository = repository;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if(user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if(passwordMatch is false)
        {
            throw new InvalidLoginException();
        }

        return new ResponseUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user),
            Role = user.Role
        };
    }
}
