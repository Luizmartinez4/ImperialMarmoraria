using AutoMapper;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Exception.ExceptionBase;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Domain.Repositories;

namespace ImperialMarmoraria.Application.UseCases.Orcamento.Remove;
public class RemoveOrcamentoUseCase : IRemoveOrcamentoUseCase
{
    private readonly IOrcamentosWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;

    public RemoveOrcamentoUseCase(IOrcamentosWriteOnlyRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Remove(id);

        if(result is false)
        {
            throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_EXCEPTION);
        }

        await _unityOfWork.Commit();
    }
}
