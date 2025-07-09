using ImperialMarmoraria.Communication.Responses.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetByStatus;
public interface IGetOrcamentoByStatusUseCase
{
    Task<ResponseOrcamentosJson> Execute(int status);
}