using FluentValidation;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Exception;

namespace ImperialMarmoraria.Application.UseCases.User.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NOME_VAZIO)
            .EmailAddress()
            .When(user => string.IsNullOrEmpty(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}
