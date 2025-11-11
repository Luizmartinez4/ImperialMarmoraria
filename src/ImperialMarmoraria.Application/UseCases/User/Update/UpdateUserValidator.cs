using FluentValidation;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Exception;

namespace ImperialMarmoraria.Application.UseCases.User.Update
{
    public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
    {
        public UpdateUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NOME_VAZIO);
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.NOME_VAZIO)
                .EmailAddress()
                .When(user => string.IsNullOrEmpty(user.Email) == false, ApplyConditionTo.CurrentValidator)
                .WithMessage(ResourceErrorMessages.EMAIL_INVALIDO);
        }
    }
}
