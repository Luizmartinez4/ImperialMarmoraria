using ImperialMarmoraria.Domain.Entities;
using ImperialMarmoraria.Domain.Repositories.Orcamentos;
using Microsoft.EntityFrameworkCore;

namespace ImperialMarmoraria.Infrastructure.DataAcess.Repositories;
internal class OrcamentosRepository : IOrcamentosWriteOnlyRepository, IOrcamentosReadOnlyRepository, IOrcamentosUpdateOnlyRepository
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

    public async Task<List<Orcamento>> GetAll()
    {
        return await _context.Orcamentos.AsNoTracking().OrderBy(orcamento => orcamento.Status).ThenByDescending(orcamento => orcamento.Id).ToListAsync();
    }

    public async Task<Orcamento?> GetById(long id)
    {
        return await _context.Orcamentos.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
    }

    public void Update(Orcamento orcamento)
    {
        _context.Orcamentos.Update(orcamento);
    }
}
