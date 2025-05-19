using ImperialMarmoraria.Communication.Requests.Email;

namespace ImperialMarmoraria.Application.UseCases.Email
{
    public interface IEmailUseCase
    {
        Task SendEmailAsync(RequestEmailJson email, string subject, string message);
    }
}
