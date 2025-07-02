using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Orcamentos;
public interface IOrcamentosReadOnlyRepository
{
    Task<List<Orcamento>> GetAll();
}