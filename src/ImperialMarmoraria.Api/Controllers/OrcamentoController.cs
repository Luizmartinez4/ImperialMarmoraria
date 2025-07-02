using ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
using ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
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
    public async Task<IActionResult> Register(
        [FromServices] IGetAllOrcamentos useCase)
    {
        var response = await useCase.Execute();

        if(response.Orcamentos.Count  != 0)
        {
            return Ok(response);
        }

        return NoContent();
    }

}
