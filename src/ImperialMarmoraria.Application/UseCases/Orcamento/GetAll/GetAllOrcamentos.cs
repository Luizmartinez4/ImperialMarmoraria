using AutoMapper;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.GetAll;
public class GetAllOrcamentos : IGetAllOrcamentos
{
    private readonly IOrcamentosReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllOrcamentos(IOrcamentosReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseOrcamentosJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseOrcamentosJson {
            Orcamentos = _mapper.Map<List<ResponseGetOrcamentoJson>>(result)
        };
    }
}
