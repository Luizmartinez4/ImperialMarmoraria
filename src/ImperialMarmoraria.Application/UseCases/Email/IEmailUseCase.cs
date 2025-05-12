namespace ImperialMarmoraria.Application.UseCases.Email
{
    public interface IEmailUseCase
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
