using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
public interface IRegistraOrcamento
{
    Task<ReponseRegistraOrcamentoJson> Execute(RequestRegistraOrcamentoJson request);
}
