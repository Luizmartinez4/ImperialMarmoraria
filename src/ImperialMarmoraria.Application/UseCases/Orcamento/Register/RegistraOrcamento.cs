using AutoMapper;
using ImperialMarmoraria.Application.AutoMapper;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using OrcamentoEntity = ImperialMarmoraria.Domain.Entities.Orcamento;
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Exception.ExceptionBase;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Registra;
public class RegistraOrcamento : IRegistraOrcamento
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IOrcamentosWriteOnlyRepository _repository;
    private readonly IMapper _mapper;

    public RegistraOrcamento(
        IUnityOfWork unityOfWork,
        IOrcamentosWriteOnlyRepository orcamentosRepository,
        IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _repository = orcamentosRepository;
        _mapper = mapper;
    }

    public async Task<ReponseRegistraOrcamentoJson> Execute(RequestRegistraOrcamentoJson request)
    {
        Validate(request);

        var entity = _mapper.Map<OrcamentoEntity>(request);

        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ReponseRegistraOrcamentoJson>(entity);
    }

    private void Validate(RequestRegistraOrcamentoJson request)
    {
        var validator = new RegistraOrcamentoValidator();

        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
