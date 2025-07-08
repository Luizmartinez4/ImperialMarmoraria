using AutoMapper;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Exception.ExceptionBase;
using OrcamentoEntity = ImperialMarmoraria.Domain.Entities.Orcamento;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Update;
public class UpdateOrcamentoUseCase : IUpdateOrcamentoUseCase
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IOrcamentosUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;

    public UpdateOrcamentoUseCase(
        IUnityOfWork unityOfWork,
        IOrcamentosUpdateOnlyRepository orcamentosRepository,
        IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _repository = orcamentosRepository;
        _mapper = mapper;
    }

    public async Task Execute(long id ,RequestUpdateOrcamentoJson request)
    {
        Validate(request);

        var response = await _repository.GetById(id);

        if(response is null)
        {
            throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_EXCEPTION);
        }

        _mapper.Map(request, response);

        if(response.Status == 2)
        {
            response.DataFim = DateOnly.FromDateTime(DateTime.UtcNow);
        } else
        {
            response.DataFim = null;
        }

        _repository.Update(response);

        await _unityOfWork.Commit();

    }

    private void Validate(RequestUpdateOrcamentoJson request)
    {
        var validator = new UpdateOrcamentoValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
