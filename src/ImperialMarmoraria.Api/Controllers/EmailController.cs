using ImperialMarmoraria.Application.UseCases.Email;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailUseCase _useCase;

        public EmailController(IEmailUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send()
        {
            var receiver = "cofes39489@inkight.com";
            var subject = "Bem-vindo!";
            var message = "Email enviado automaticamente pela view.";

            await _useCase.SendEmailAsync(receiver, subject, message);
            return Ok("Email enviado");
        }
    }
}
