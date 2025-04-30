using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Orcamentos;
public interface IOrcamentosRepository
{
    Task Add(Orcamento orcamento);
}
