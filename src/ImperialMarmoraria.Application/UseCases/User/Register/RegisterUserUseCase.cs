using AutoMapper;
using FluentValidation.Results;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Enums;
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Repositories.Users;
using ImperialMarmoraria.Domain.Security.Cryptography;
using ImperialMarmoraria.Domain.Security.Tokens;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Exception.ExceptionBase;

namespace ImperialMarmoraria.Application.UseCases.User.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IUsersReadOnlyRepository _repository;
    private readonly IUserWriteOnlyRepository _repositoryWriteOnly;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IMapper _mapper;
    private readonly IAccessTokenGenerator _tokenGenerator;

    public RegisterUserUseCase(
        IUnityOfWork unityOfWork,
        IUsersReadOnlyRepository orcamentosRepository,
        IMapper mapper,
        IPasswordEncripter passwordEncripter,
        IUserWriteOnlyRepository repositoryWriteOnly,
        IAccessTokenGenerator tokenGenerator)
    {
        _unityOfWork = unityOfWork;
        _repository = orcamentosRepository;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _repositoryWriteOnly = repositoryWriteOnly;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResponseUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);

        user.Password = _passwordEncripter.Encrypt(request.Password);
        user.UserId = Guid.NewGuid();

        await _repositoryWriteOnly.Add(user);

        await _unityOfWork.Commit();

        return new ResponseUserJson
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user),
            Role = user.Role
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        var emailExists = await _repository.ExistActiveUserWithEmail(request.Email);

        if (emailExists)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_JA_EXISTE));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
