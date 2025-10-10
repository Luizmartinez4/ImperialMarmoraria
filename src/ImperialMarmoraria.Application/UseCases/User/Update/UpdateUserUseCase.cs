using AutoMapper;
using FluentValidation.Results;
using ImperialMarmoraria.Application.UseCases.User.Register;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Repositories.Users;
using ImperialMarmoraria.Domain.Repositories;
using ImperialMarmoraria.Domain.Security.Cryptography;
using ImperialMarmoraria.Domain.Security.Tokens;
using ImperialMarmoraria.Exception.ExceptionBase;
using ImperialMarmoraria.Exception;
using ImperialMarmoraria.Domain.Enums;

namespace ImperialMarmoraria.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IUsersReadOnlyRepository _repository;
        private readonly IUserUpdateOnlyRepository _updateRepository;
        private readonly IMapper _mapper;

        public UpdateUserUseCase(
            IUnityOfWork unityOfWork,
            IUsersReadOnlyRepository orcamentosRepository,
            IMapper mapper,
            IUserUpdateOnlyRepository updateRepository)
        {
            _unityOfWork = unityOfWork;
            _repository = orcamentosRepository;
            _mapper = mapper;
            _updateRepository = updateRepository;
        }

        public async Task<ResponseUpdatedUserJson> Execute(RequestUpdateUserJson request, long id)
        {
            var user = await _updateRepository.GetById(id);

            if (user == null)
            {
                throw new NotFoundException(ResourceErrorMessages.NOT_FOUND_EXCEPTION);
            }

            Validate(request);

            var updateUser = _mapper.Map(request, user);
            
            if(request.Role == 1)
            {
                updateUser!.Role = Roles.ADMIN;
            } else
            {
                updateUser!.Role = Roles.TEAM_MEMBER;
            }


            _updateRepository.Update(updateUser!);

            await _unityOfWork.Commit();

            return new ResponseUpdatedUserJson
            {
                Name = updateUser!.Name,
                Role = updateUser!.Role
            };
        }

        private void Validate(RequestUpdateUserJson request)
        {
            var validator = new UpdateUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
