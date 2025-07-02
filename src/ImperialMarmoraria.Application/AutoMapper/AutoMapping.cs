using AutoMapper;
using ImperialMarmoraria.Communication.Requests.Orcamento;
using ImperialMarmoraria.Communication.Responses.Orcamento;
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
    }

    private void EntityToResponse()
    {
        CreateMap<Orcamento, ReponseRegistraOrcamentoJson>();
        CreateMap<Orcamento, ResponseGetOrcamentoJson>();
    }
}
