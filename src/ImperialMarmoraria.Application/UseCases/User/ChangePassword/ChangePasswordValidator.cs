using FluentValidation;
using ImperialMarmoraria.Application.UseCases.User.Register;
using ImperialMarmoraria.Communication.Requests.User;

namespace ImperialMarmoraria.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
        }
    }
}
