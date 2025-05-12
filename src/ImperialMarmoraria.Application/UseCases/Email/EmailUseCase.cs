
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using System.Net;
using System.Net.Mail;

namespace ImperialMarmoraria.Application.UseCases.Email
{
    public class EmailUseCase : IEmailUseCase
    {
        private readonly IOrcamentosRepository _repository;

        public EmailUseCase(IOrcamentosRepository repository)
        {
            _repository = repository;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "leonardo.tonetto@sou.fae.br";
            var pw = "";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message));
        }
    }
}
