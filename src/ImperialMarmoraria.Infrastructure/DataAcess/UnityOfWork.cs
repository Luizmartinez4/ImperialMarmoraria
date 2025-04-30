using ImperialMarmoraria.Domain.Repositories;

namespace ImperialMarmoraria.Infrastructure.DataAcess;
internal class UnityOfWork : IUnityOfWork
{
    private readonly ImperialMarmorariaDbContext _context;

    public UnityOfWork(ImperialMarmorariaDbContext context)
    {
        _context = context;
    }

    public async Task Commit() => await _context.SaveChangesAsync();
}
