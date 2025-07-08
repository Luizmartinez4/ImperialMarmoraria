using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Update;
public interface IUpdateOrcamentoUseCase
{
    Task Execute(long id ,RequestUpdateOrcamentoJson request);
}