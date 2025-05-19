
using ImperialMarmoraria.Communication.Requests.Email;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using System.Net;
using System.Net.Mail;

namespace ImperialMarmoraria.Application.UseCases.Email
{
    public class EmailUseCase : IEmailUseCase
    {
        public Task SendEmailAsync(RequestEmailJson email, string subject, string message)
        {
            var mail = "neamgames@gmail.com";
            var pw = "izrc ijta wjjj njrh";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email.Email,
                                subject,
                                message));
        }
    }
}
