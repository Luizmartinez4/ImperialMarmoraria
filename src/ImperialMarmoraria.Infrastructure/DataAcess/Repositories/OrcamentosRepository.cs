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
        return await _context.Orcamentos.AsNoTracking().OrderBy(orcamento => orcamento.Status).ThenByDescending(orcamento => orcamento.DataInicio).ThenByDescending(orcamento => orcamento.Id).ToListAsync();
    }

    public async Task<Orcamento?> GetById(long id)
    {
        return await _context.Orcamentos.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<List<Orcamento>> GetByName(string name)
    {
        return await _context.Orcamentos.AsNoTracking().Where(o => o.Nome.Contains(name)).OrderBy(orcamento => orcamento.Status).ThenByDescending(orcamento => orcamento.DataInicio).ThenByDescending(orcamento => orcamento.Id).ToListAsync();
    }

    public async Task<List<Orcamento>> GetByStatus(int status)
    {
        return await _context.Orcamentos.AsNoTracking().Where(o => o.Status == status).OrderBy(orcamento => orcamento.DataInicio).ThenByDescending(orcamento => orcamento.Id).ToListAsync();
    }

    public async Task<bool> Remove(long id)
    {
        var result = await _context.Orcamentos.FirstOrDefaultAsync(o => o.Id == id);

        if(result is null)
        {
            return false;
        }

        _context.Orcamentos.Remove(result);

        return true;
    }

    public void Update(Orcamento orcamento)
    {
        _context.Orcamentos.Update(orcamento);
    }
}
