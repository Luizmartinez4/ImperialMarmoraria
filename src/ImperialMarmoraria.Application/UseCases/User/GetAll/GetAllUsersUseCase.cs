using AutoMapper;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Entities;
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


        public async Task<ResponseGetUsersJson> Execute()
        {
            var user = await _repository.GetAllUsers();

            var responseList = _mapper.Map<List<ResponseGetUserJson>>(user);

            var response = new ResponseGetUsersJson
            {
                Users = responseList
            };

            return response;
        }
    }
}
