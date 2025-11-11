using ImperialMarmoraria.Application.UseCases.Login;
using ImperialMarmoraria.Communication.Requests.Login;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromServices] IDoLoginUseCase useCase,
        [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);

        return Redirect($"http://localhost:3000/login/callback?token={response.Token}");
    }
}
