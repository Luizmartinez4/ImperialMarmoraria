using AutoMapper;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Repositories.Users;

namespace ImperialMarmoraria.Application.UseCases.User.GetAll
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUsersReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersUseCase(IUsersReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public Task<ResponseGetUsersJson> Execute()
        {
            return;
        }
    }
}
