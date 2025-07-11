using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
using ImperialMarmoraria.Application.UseCases.User.Register;
using ImperialMarmoraria.Communication.Requests.Login;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterUserUseCase useCase,
        [FromBody] RequestRegisterUserJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty ,response);
    }
}
