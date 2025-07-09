using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Orcamentos;
public interface IOrcamentosReadOnlyRepository
{
    Task<List<Orcamento>> GetAll();
    Task<List<Orcamento>> GetByStatus(int status);
    Task<List<Orcamento>> GetByName(string name);
}