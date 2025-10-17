using ImperialMarmoraria.Application.UseCases.Orcamento.Remove;
using ImperialMarmoraria.Application.UseCases.User.ChangePassword;
using ImperialMarmoraria.Application.UseCases.User.Delete;
using ImperialMarmoraria.Application.UseCases.User.GetAll;
using ImperialMarmoraria.Application.UseCases.User.Register;
using ImperialMarmoraria.Application.UseCases.User.Update;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize(Roles = Roles.ADMIN)]
    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetUsersJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllUsersUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response is null)
        {
            return NoContent();
        }

        return Created(string.Empty, response);
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseUpdatedUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateUserUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestUpdateUserJson request)
    {
        var response = await useCase.Execute(request, id);

        return Created(string.Empty, response);
    }

    [Authorize]
    [HttpPut("change-password")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePassword(
        [FromServices] IChangePasswordUseCase useCase,
        [FromBody] RequestChangePasswordJson request)
    {
        await useCase.Execute(request);

        return NoContent();
    }

    [Authorize(Roles = Roles.ADMIN)]
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove(
        [FromServices] IRemoveUserUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }
}
