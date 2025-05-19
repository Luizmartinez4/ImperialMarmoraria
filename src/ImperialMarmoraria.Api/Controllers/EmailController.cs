using ImperialMarmoraria.Application.UseCases.Email;
using ImperialMarmoraria.Communication.Requests.Email;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> Send([FromServices] IEmailUseCase useCase,
            [FromBody] RequestEmailJson receiver)
        {
            var subject = "Não responda este email";
            var message = "Sua solicitação foi recebida e será analisada, responderemos sua solicitação via whatsapp ou email em breve! Agradecemos a sua preferência!";

            await useCase.SendEmailAsync(receiver, subject, message);
            return Ok("Email enviado");

        }
    }
}
