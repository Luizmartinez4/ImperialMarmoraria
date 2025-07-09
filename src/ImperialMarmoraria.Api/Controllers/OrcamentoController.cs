using ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetByName;
using ImperialMarmoraria.Application.UseCases.Orcamento.GetByStatus;
using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
using ImperialMarmoraria.Application.UseCases.Orcamento.Remove;
using ImperialMarmoraria.Application.UseCases.Orcamento.Update;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using Microsoft.AspNetCore.Mvc;

namespace ImperialMarmoraria.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrcamentoController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ReponseRegistraOrcamentoJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegistraOrcamento useCase,
        [FromBody] RequestRegistraOrcamentoJson request)
    {
         var response = await useCase.Execute(request);

         return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseOrcamentosJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllOrcamentos useCase)
    {
        var response = await useCase.Execute();

        if(response.Orcamentos.Count  != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }
    

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateOrcamentoUseCase useCase,
        [FromRoute] long id,
        [FromBody] RequestUpdateOrcamentoJson request)
    {
        await useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove(
        [FromServices] IRemoveOrcamentoUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpGet("Status")]
    [ProducesResponseType(typeof(ResponseOrcamentosJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetByStatus(
        [FromServices] IGetOrcamentoByStatusUseCase useCase,
        [FromQuery] int status)
    {
        var response = await useCase.Execute(status);

        if (response.Orcamentos.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

    [HttpGet("Name")]
    [ProducesResponseType(typeof(ResponseOrcamentosJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetByName(
        [FromServices] IGetOrcamentoByNameUseCase useCase,
        [FromQuery] string name)
    {
        var response = await useCase.Execute(name);

        if (response.Orcamentos.Count != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }
}
