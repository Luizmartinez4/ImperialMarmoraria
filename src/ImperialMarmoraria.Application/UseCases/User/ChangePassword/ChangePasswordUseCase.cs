using FluentValidation.Results;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Domain.Repositories.Users;
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Security.Cryptography;
using ImperialMarmoraria.Domain.Services.LoggedUser;
using ImperialMarmoraria.Exception.ExceptionBase;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly IUnityOfWork _unitOfWork;
        private readonly IPasswordEncripter _passwordEncripter;

        public ChangePasswordUseCase(ILoggedUser loggedUser, IUserUpdateOnlyRepository repository, IUnityOfWork unitOfWork, IPasswordEncripter passwordEncripter)
        {
            _loggedUser = loggedUser;
            _repository = repository;
            _unitOfWork = unitOfWork;
            _passwordEncripter = passwordEncripter;
        }


        public async Task Execute(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var user = await _repository.GetById(loggedUser.Id);
            user!.Password = _passwordEncripter.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestChangePasswordJson request, ImperialMarmoraria.Domain.Entities.User loggedUser)
        {
            var validator = new ChangePasswordValidator();

            var result = validator.Validate(request);

            var passwordMatch = _passwordEncripter.Verify(request.Password, loggedUser.Password);

            if (passwordMatch is false)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORD_DIFERENT_CURRENT_PASSWORD));
            }

            if (request.Password != request.ConfirmPassword)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.PASSWORDS_DO_NOT_MATCH));
            }

            if (result.IsValid is false)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
