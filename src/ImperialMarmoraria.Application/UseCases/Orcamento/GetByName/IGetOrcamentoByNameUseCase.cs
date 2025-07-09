using ImperialMarmoraria.Communication.Responses.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetByName;
public interface IGetOrcamentoByNameUseCase
{
    Task<ResponseOrcamentosJson> Execute(string name);
}