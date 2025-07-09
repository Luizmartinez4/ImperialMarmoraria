using AutoMapper;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetByStatus;
public class GetOrcamentoByStatusUseCase : IGetOrcamentoByStatusUseCase
{
    private readonly IOrcamentosReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetOrcamentoByStatusUseCase(IOrcamentosReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseOrcamentosJson> Execute(int status)
    {
        var result = await _repository.GetByStatus(status);

        return new ResponseOrcamentosJson
        {
            Orcamentos = _mapper.Map<List<ResponseGetOrcamentoJson>>(result)
        };
    }
}
