using AutoMapper;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetByName;
public class GetOrcamentoByNameUseCase : IGetOrcamentoByNameUseCase
{
    private readonly IOrcamentosReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetOrcamentoByNameUseCase(IOrcamentosReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseOrcamentosJson> Execute(string name)
    {
        var result = await _repository.GetByName(name);

        return new ResponseOrcamentosJson
        {
            Orcamentos = _mapper.Map<List<ResponseGetOrcamentoJson>>(result)
        };
    }
}
