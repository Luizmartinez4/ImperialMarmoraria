using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Orcamentos;
public interface IOrcamentosUpdateOnlyRepository
{
    Task<Orcamento?> GetById(long id);
    void Update(Orcamento orcamento);
}
