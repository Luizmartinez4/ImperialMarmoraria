using AutoMapper;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Requests.User;
using ImperialMarmoraria.Communication.Responses.Orcamento;
using ImperialMarmoraria.Communication.Responses.User;
using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegistraOrcamentoJson, Orcamento>();
        CreateMap<RequestUpdateOrcamentoJson, Orcamento>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Orcamento, ReponseRegistraOrcamentoJson>();
        CreateMap<Orcamento, ResponseGetOrcamentoJson>();
        CreateMap<User, ResponseGetUserJson>();
    }
}
