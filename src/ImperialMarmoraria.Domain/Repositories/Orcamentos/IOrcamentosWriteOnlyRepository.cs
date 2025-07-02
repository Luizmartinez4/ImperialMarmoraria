using ImperialMarmoraria.Domain.Entities;

namespace ImperialMarmoraria.Domain.Repositories.Orcamentos;
public interface IOrcamentosWriteOnlyRepository
{
    Task Add(Orcamento orcamento);
}
