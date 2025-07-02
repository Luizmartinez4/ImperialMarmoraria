using ImperialMarmoraria.Communication.Responses.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
public interface IGetAllOrcamentos
{
    Task<ResponseOrcamentosJson> Execute();
}