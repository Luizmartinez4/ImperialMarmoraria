using ImperialMarmoraria.Domain.Entities;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;

namespace ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
internal class OrcamentosRepository : IOrcamentosRepository
{
    private readonly ImperialMarmorariaDbContext _context;

    public OrcamentosRepository(ImperialMarmorariaDbContext context)
    {
        _context = context;
    }

    public async Task Add(Orcamento orcamento)
    {
        await _context.Orcamentos.AddAsync(orcamento);
    }
}
