
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
            var mail = "luiz.martinez@sou.fae.br";
            var pw = "mjne ebdl mshq seqj";

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
