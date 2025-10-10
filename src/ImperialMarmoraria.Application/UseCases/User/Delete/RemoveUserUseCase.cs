
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Exception.ExceptionBase;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using ImperialMarmoraria.Domain.Repositories.Users;

namespace ImperialMarmoraria.Application.UseCases.User.Delete
{
    internal class RemoveUserUseCase : IRemoveUserUseCase
    {
        private readonly IUserWriteOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;

        public RemoveUserUseCase(IUserWriteOnlyRepository repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.Remove(id);

            if (result is false)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_EXCEPTION);
            }

            await _unityOfWork.Commit();
        }
    }
}
